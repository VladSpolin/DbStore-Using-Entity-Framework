using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicStore
{
    class Order
    {
        public int Id { get; set; }
        public int ShopAssistantId { get; set; }
        public ShopAssistant ShopAssistant { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public string Adress { get; set; }
        public DateTime Date { get; set; }
    }
}
