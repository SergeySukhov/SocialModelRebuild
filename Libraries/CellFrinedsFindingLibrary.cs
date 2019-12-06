using SocialModelRebuild.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialModelRebuild.Libraries
{
    public static class CellFrinedsFindingLibrary
    {
        public static void FindFriendsSimple(Cell[][] matrixCell, int linkModel, List<int> leftBorder, List<int> rightBorder)
        {
            int N = matrixCell.Length;
            var friends = new List<Cell>();

            foreach (var cellRow in matrixCell)
                foreach (var cell in cellRow)
                {
                    int t = 0, l = 0;
                    int i = (int)cell.id / N, j = cell.id % N;

                    for (int q = -cell.M; q <= cell.M; q++) // --
                    {
                        l = i - q;
                        for (int k = -cell.M; k <= cell.M; k++) // |
                        {
                            t = j - k;

                            if (k == 0 && q == 0) continue;
                            if (l < 0) l += N;
                            if (t < 0) t += N;
                            if (l >= N) l -= N;
                            if (t >= N) t -= N;

                            matrixCell[i][j].friends.Add(matrixCell[l][t]);
                        }
                    }
                }
        }

        public static void AddSmi(SmiCell smi, CellModel cellModel)
        {

            int N = cellModel.MatrixCell.Length;
            var matrixCell = cellModel.MatrixCell;

            int t = 0, l = 0;
            int i = (int)smi.id / N, j = smi.id % N;
            
            for (int q = -smi.M; q <= smi.M; q++) // --
            {
                l = i - q;
                for (int k = -smi.M; k <= smi.M; k++) // |
                {
                    t = j - k;

                    if (k == 0 && q == 0) continue;
                    if (l < 0) l += N;
                    if (t < 0) t += N;
                    if (l >= N) l -= N;
                    if (t >= N) t -= N;

                    matrixCell[l][t].friends.Add(smi);
                }
            }
        }

    }
}
