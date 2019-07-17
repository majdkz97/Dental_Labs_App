using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dental.Core
{
   public class Order
    {
        public int id { get; set; }
        public String date_register { get; set; }
        public String date_delivered { get; set; }
        public Doctor doctor { get; set; }
        public Patient patient { get; set; }
        public Bill bill { get; set; }


    }
}
