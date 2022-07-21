using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicStore
{
    class Review
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public int DeliveryId { get; set; }
        public Delivery Delivery { get; set; }
        public string Comment { get; set; }
    }
}
