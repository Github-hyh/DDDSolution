using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.TransferDTOS
{
    public class ProductDTO
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Color { get; set; }

        public string Size { get; set; }

        public int Amount { get; set; }

        public decimal UnitPrice { get; set; }

        public string PCategoryName { get; set; }

        public string PDescription { get; set; }
    }
}
