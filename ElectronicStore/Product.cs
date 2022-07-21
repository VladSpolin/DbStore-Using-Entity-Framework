using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicStore
{
    class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProductCategoryId { get; set; }
        public ProductCategory ThisProductCategory { get; set; }
        public int ProducerId { get; set; }
        public Producer ItsProducer { get; set; }
        public int ProviderId { get; set; }
        public Provider ItsProvider { get; set; }
    }
}
