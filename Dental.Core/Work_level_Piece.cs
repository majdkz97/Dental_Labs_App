using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dental.Core
{
   public class Work_level_Piece
    {
        public int id { get; set; }
        public Work_level work_level { get; set; }
        public Piece_details piece_details { get; set; }

    }
}
