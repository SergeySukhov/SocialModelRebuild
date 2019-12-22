using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SocialModelRebuild.Libraries;

namespace SocialModelRebuild.Models
{
    public class SavingCellModel
    {
        public string SaveCellModel(CellModel cellModel)
        {
            var strCells = new List<string>();
            foreach(var cell in cellModel.AllCells)
            {
                strCells.Add(SaveCell(cell));
            }
            var allcells = cellModel.AllCells;
            var matrix = cellModel.MatrixCell;
            var allsmi = cellModel.AllSmiCells;
            var calcInput = cellModel.CalculateInputImpact;
            var calcopinion = cellModel.CalculateOwnOpinion;
            var finfriends = cellModel.FindFriends;

            cellModel.AllCells = null;
            cellModel.MatrixCell = null;
            cellModel.AllSmiCells = null;
            cellModel.CalculateInputImpact = null;
            cellModel.CalculateOwnOpinion = null;
            cellModel.FindFriends = null;

            var tuple = new Tuple<CellModel, List<string>>(cellModel, strCells); 

            var saved = JsonConvert.SerializeObject(tuple);

            cellModel.FindFriends = finfriends;
            cellModel.CalculateOwnOpinion = calcopinion;
            cellModel.CalculateInputImpact = calcInput;
            cellModel.AllCells = allcells;
            cellModel.AllSmiCells = allsmi;
            cellModel.MatrixCell = matrix;

            return saved;
        }

        public CellModel LoadCellModel(string savingCellModel)
        {
            var cellModelWithStrings = JsonConvert.DeserializeObject<Tuple<CellModel, List<string>>>(savingCellModel);

            var cellModel = cellModelWithStrings.Item1;
            var allCellsString = cellModelWithStrings.Item2;

            cellModel.AllCells = LoadCells(allCellsString);
            cellModel.MatrixCell = CreateCellMatrix(cellModel);
            cellModel.AllSmiCells = new List<SmiCell>();

            cellModel.CalculateInputImpact = CellCalculateInputImpactLibrary.CalculateInputImpactSimple;
            cellModel.CalculateOwnOpinion = CellCalculateOwnOpinionLibrary.CalculateOwnOpinionSimple;
            cellModel.FindFriends = CellFrinedsFindingLibrary.FindFriendsSimple;

            if (cellModel.FirstIter == null)
            {
                cellModel.FirstIter = savingCellModel;
            }

            return cellModel;
        }

        private string SaveCell(Cell cell)
        {
            var friends = cell.friends;
            var friendsId = friends.Select(x => x.id);

            cell.friends = null;
            var o = new Tuple<Cell, IEnumerable<int>>(cell, friendsId);

            var result = JsonConvert.SerializeObject(o);
            cell.friends = friends;

            return result;
        }

        private List<Cell> LoadCells(List<string> cellStrings)
        {
            var allCellsWithFriendsId = new List<Tuple<Cell, IEnumerable<int>>>();
            foreach(var cellWithFriendsId in cellStrings)
            {
               allCellsWithFriendsId.Add(JsonConvert.DeserializeObject<Tuple<Cell, IEnumerable<int>>>(cellWithFriendsId));
            }

            foreach (var s in allCellsWithFriendsId)
            {
                s.Item1.friends = new List<Cell>();

                foreach (var friendId in s.Item2)
                {
                    s.Item1.friends.Add(allCellsWithFriendsId.Find(x => x.Item1.id == friendId).Item1);
                }
            }

            return allCellsWithFriendsId.Select(x => x.Item1).ToList();
        }

        private Cell[][] CreateCellMatrix(CellModel cellModel)
        {
            var matrix = new Cell[cellModel.N][];
            for(int i = 0; i< cellModel.N; i++)
            {
                matrix[i] = new Cell[cellModel.N];
                for(int j = 0; j < cellModel.N; j ++)
                {
                    matrix[i][j] = cellModel.AllCells[i * cellModel.N + j];
                }
            }

            return matrix;
        }
    }
}
