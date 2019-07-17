using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dental.Core
{
   public class Work_level
    {
        public int id { get; set; }
        public Employee employee { get; set; }
        public Level level { get; set; }

        public int price { get; set; }
    }
}
