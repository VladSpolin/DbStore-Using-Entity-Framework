using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicStore
{
    class Delivery
    {
        public int Id { get; set; }
        public int DeliveryManId { get; set; }
        public int OrderId { get; set; }
        public DateTime Date { get; set; }
    }
}
