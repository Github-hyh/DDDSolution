using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.TransferDTOS
{
    public class OrderItemDTO
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; }

        public decimal UnitPrice { get; set; }
        public int Amount { get; set; }
        public decimal LineTotal { get; set; }
    }
}
