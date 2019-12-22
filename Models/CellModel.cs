using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialModelRebuild.Models
{
    public class CellModel
    {
        public string Name = "";
        public Guid Guid;
        public int N = 1;
        public int Iteration = 0;
        public int LinkModel = 1; // 0 - matrix, 1 - sphere, 2- vertical torus, 3 - vert + hor torus
        public double UMax = 100;
        public Cell CurrentCell = null;

        public List<Cell> AllCells = new List<Cell>();
        public List<SmiCell> AllSmiCells = new List<SmiCell>();
        public Cell[][] MatrixCell;

        public List<int> LeftBorder = new List<int>();
        public List<int> RightBorder = new List<int>();
        public List<IterationInfoCellModel> cellModelHistory = new List<IterationInfoCellModel>();
        

        public delegate void findFriends(Cell[][] matrixCell, int linkModel, List<int> leftBorder, List<int> rightBorder);
        public delegate void calculateOwnOpinion(Cell cell);
        public delegate void calculateInputImpact(Cell cell);
        public delegate void iterationTick();

        public findFriends FindFriends;
        public calculateInputImpact CalculateInputImpact;
        public calculateOwnOpinion CalculateOwnOpinion;

        public List<IterationInfoCellModel> IterationInfoCellModels = new List<IterationInfoCellModel>();
        public string FirstIter;
        //////////////////////////////////////

        public CellModel(int N)
        {
            this.N = N;
            this.Guid = Guid.NewGuid();
        }

        public void SetupModel()
        {
            this.MatrixCell = new Cell[N][];

            for (int i = 0; i < N; i++)
            {
                MatrixCell[i] = new Cell[N];
                for (int j = 0; j < N; j++)
                {
                    var cell = new Cell();
                    cell.id = (i * N) + j;

                    this.MatrixCell[i][j] = cell;
                    this.AllCells.Add(cell);
                }
            }

        }

        public void CellsPosition(int width, int betweenCells, int shiftX, int shiftY)
        {

            for (int i = 0; i < this.MatrixCell.Length; i++)
            {
                for (int j = 0; j < MatrixCell[i].Length; j++)
                {
                    MatrixCell[i][j].x = j * (width + betweenCells) + shiftX;
                    MatrixCell[i][j].y = i * (width + betweenCells) + shiftY;
                }
            }
            foreach (var smi in AllSmiCells)
            {
                smi.x = AllCells[smi.id].x + 10;
                smi.y = AllCells[smi.id].y + 10;
            }
        }

        public void IterationTick()
        {
            if (CalculateInputImpact == null || CalculateOwnOpinion == null) return;

            foreach (var cell in AllCells)
            {
                this.CalculateInputImpact(cell);
            }

            foreach (var cell in AllCells)
            {
                this.CalculateOwnOpinion(cell);
            }

            this.cellModelHistory.Add(GetIterationInfo(this.Iteration));

            this.Iteration++;
        }

        public int CountCell(int d)
        {
            int result = 0;

            foreach (var cell in AllCells)
            {
                if (cell.d == d) result++;
            }

            return result;
        }
            
        public string GetModelInfo()
        {
            double redCells = 0, blueCells = 0, greyCells = 0, whiteCells = 0, redU = 0, blueU = 0, UPotential = 0;

            foreach (var cell in AllCells)
            {
                if (cell.d != 0) UPotential += UMax;
                if (cell.d == 1) { redCells++; redU += cell.U; }
                if (cell.d == -1) { blueCells++; blueU += Math.Abs(cell.U); }
                if (cell.d == 2) greyCells++;
                if (cell.d == 0) whiteCells++;
            }

            string resultInfo = $"Итерация: {Iteration}" + Environment.NewLine +
                $"Красных: {(int)(100 * redCells / AllCells.Count)}%" + Environment.NewLine +
                $"Синих: {(int)(100 * blueCells / AllCells.Count)}%" + Environment.NewLine +
                $"Серых: {(int)(100 * greyCells / AllCells.Count)}%" + Environment.NewLine +
                $"Белых: {(int)(100 * whiteCells / AllCells.Count)}%" + Environment.NewLine +
                Environment.NewLine +
                $"Красного влияния: {(int)(100 * redU / UPotential)}% ({redU} из {UPotential})" + Environment.NewLine +
                $"Синего влияния: {(int)(100 * blueU / UPotential)}% ({blueU} из {UPotential})" + Environment.NewLine +
                $"ID модели {this.Guid}";
            return resultInfo;
        }

        public IterationInfoCellModel GetIterationInfo(int iteration)
        {
            double redCells = 0, blueCells = 0, greyCells = 0, whiteCells = 0, redU = 0, blueU = 0, UPotential = 0;

            foreach (var cell in AllCells)
            {
                if (cell.d != 0) UPotential += UMax;
                if (cell.d == 1) { redCells++; redU += cell.U; }
                if (cell.d == -1) { blueCells++; blueU += Math.Abs(cell.U); }
                if (cell.d == 2) greyCells++;
                if (cell.d == 0) whiteCells++;
            }

            var iterationInfo = new IterationInfoCellModel
            {
                Iteration = iteration,
                RedPercent = redCells / AllCells.Count,
                BluePercent = blueCells / AllCells.Count,
                WhitePercent = whiteCells / AllCells.Count,
                GreyPercent = greyCells / AllCells.Count,
                RedU = redU / UPotential,
                BlueU = blueU / UPotential,
            };

            return iterationInfo;           
        }
    }
}
