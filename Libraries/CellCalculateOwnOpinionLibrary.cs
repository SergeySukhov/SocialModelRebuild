using SocialModelRebuild.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialModelRebuild.Libraries
{
    public static class CellCalculateOwnOpinionLibrary
    {
        const int GreyFrame = 20;

        public static void CalculateOwnOpinionSimple(Cell cell)
        {
            if (cell.d == 0) return;
            cell.U += cell.V;
			if (Math.Abs(cell.U) > 100) cell.U = Math.Sign(cell.U) * 100;
            if (cell.U > GreyFrame) cell.d = 1;
            if (cell.U < GreyFrame) cell.d = -1;
            if (Math.Abs(cell.U) <= GreyFrame) cell.d = 2;
        }

        public static void CalculateOwnOpinionWithForgetting(Cell cell)
        {
            cell.U += cell.V;
            cell.U *= cell.S;
            if (cell.U > GreyFrame) cell.d = 1;
            if (cell.U < GreyFrame) cell.d = -1;
            if (Math.Abs(cell.U) <= GreyFrame) cell.d = 2;
        }
    }
}
