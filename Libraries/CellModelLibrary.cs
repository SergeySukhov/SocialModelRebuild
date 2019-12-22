using SocialModelRebuild.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialModelRebuild.Libraries
{
    public static class CellModelLibrary
    {
        public static CellModel CreateCalssicModel(int N)
        {
            var cellModel = new CellModel(N);

            cellModel.FindFriends = CellFrinedsFindingLibrary.FindFriendsSimple;
            cellModel.CalculateInputImpact = CellCalculateInputImpactLibrary.CalculateInputImpactSimple;
            cellModel.CalculateOwnOpinion = CellCalculateOwnOpinionLibrary.CalculateOwnOpinionSimple;

            cellModel.SetupModel();


            SetModelParams(cellModel, 35, 35, 30);

            cellModel.FindFriends(cellModel.MatrixCell, cellModel.LinkModel, cellModel.LeftBorder, cellModel.RightBorder);
            cellModel.FirstIter = new SavingCellModel().SaveCellModel(cellModel);
            return cellModel;
        }

        private static void SetModelParams(CellModel cellModel, int redPercent, int bluePercent, int greyPercent)
        {
            Random random = new Random();

            for (int i = 0; i < cellModel.AllCells.Count; i++)
            {
                double randomNum = random.NextDouble();

                if (redPercent > randomNum * 100)
                {
                    SetCellParams(cellModel.AllCells[i], 1, 2);
                    continue;
                }
                if (redPercent + bluePercent > randomNum * 100)
                {
                    SetCellParams(cellModel.AllCells[i], -1, 2);
                    continue;
                }
                if (redPercent + bluePercent + greyPercent > randomNum * 100)
                {
                    SetCellParams(cellModel.AllCells[i], 2, 2);
                    continue;
                }
                SetCellParams(cellModel.AllCells[i], 0, 0);
            }


        }
        private static void SetCellParams(Cell cell, int d, int M)
        {
            cell.d = d;
            cell.U = d * 30;
            if (d == 2) cell.U = 0;
            cell.K = 1;
            cell.S = 1;
            cell.L = 0;
            cell.M = M;
            if (d == 0) M = 0;
        }

        private static void SetCellParams(Cell cell, double? U, double? K, double? S, int d, int M)
        {
            cell.d = d;

            cell.U = U.HasValue ? U.Value : d * 30;
            if (d == 2) cell.U = 0;

            cell.K = K.HasValue ? K.Value : 1;
            cell.S = S.HasValue ? S.Value : 1;

            cell.M = M;
            if (d == 0) M = 0;
        }
    }
}
