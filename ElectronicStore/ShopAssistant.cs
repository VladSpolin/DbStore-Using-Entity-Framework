using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicStore
{
    class ShopAssistant: Personnel
    {
        public List<Order> Orders { get; set; }
    }
}
