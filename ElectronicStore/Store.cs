using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicStore
{
    class Store
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Destination { get; set; }
        public List<Personnel> Personnels { get; set; }
    }
}
