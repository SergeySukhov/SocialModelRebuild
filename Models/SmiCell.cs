using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialModelRebuild.Models
{
    public class SmiCell: Cell
    {
        public int MatrixX = 0, MatrixY = 0;
        

        public SmiCell(int id)
        {
            this.id = id;
        }
    }
}
