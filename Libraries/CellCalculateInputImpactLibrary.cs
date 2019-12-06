using SocialModelRebuild.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialModelRebuild.Libraries
{
    public static class CellCalculateInputImpactLibrary
    {
        public static void CalculateInputImpactSimple(Cell cell)
        {
            if (cell.friends == null || cell.d == 0) return;
            double v = 0;

            foreach (var s in cell.friends)
            {
                if (s.d == 0 || s.d == 2) continue;
                v += s.d * s.K;
            }
            cell.V = v;
        }
    }
}
