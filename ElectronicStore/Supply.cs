using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicStore
{
    class Supply
    {
        public int Id { get; set; }
        public int ProviderId { get; set; }
        public Provider Provider { get; set; }
        public uint Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
