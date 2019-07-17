using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dental.Core
{
   public class Piece_details
    {
        public int id { get; set; }
        public int quintity { get; set; }
      
        public Order order { get; set; }
        public Piece_type item { get; set; }
    }
}
