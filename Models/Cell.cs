using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialModelRebuild.Models
{
    public class Cell
    {
        public int id { get; set; }
        public int x { get; set; }
        public int y { get; set; }

        public double U { get; set; }  // личное мнение
        public double L { get; set; } // личные характеристики - сопротивление
        public double Q { get; set; } // личные характеристики - коэф. активности
        public int M { get; set; } // радиус распространнения влияния
        public int d { get; set; } // направленность влияния
        public double K { get; set; } // собственное исходящее влияние
        public double S { get; set; } // коэф. забывания
        public double u_index { get; set; } // индекс укоренненности
        public double V; // входящее итоговое влияние

        public List<Cell> friends = new List<Cell>(); // список клеток , КОТОРЫЕ влияют на данную (изначально только рядовые клетки: type = 1)


        public Cell copyCellParams(Cell a)
        {
            var cell = new Cell();
            cell.d = this.d;
            cell.U = this.U;
            cell.Q = this.Q;
            cell.S = this.S;
            cell.M = this.M;
            cell.K = this.K;
            cell.L = this.L;
            cell.u_index = this.u_index;
            return cell;
        }

        public string getInfo()
        {
            return ("Накопленное мнение U: " + ((int)U).ToString()
                + Environment.NewLine + "Коэф. восприимчивости L: " + String.Format("{0:F2}", L)
                + Environment.NewLine + "Коэф. активности Q: " + String.Format("{0:F2}", Q)
                + Environment.NewLine + "Исходящее влияние К: " + String.Format("{0:F2}", K)
                + Environment.NewLine + "Направленность d: " + (d).ToString());
        }
    }
}
