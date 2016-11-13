using DDD.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain
{
    public partial class OrderItem:Entity
    {
        public OrderItem(Product product,int count)
        {
            this.Id = base.Id;
            this.Amount = count;
            this.LineTotal = product.UnitPrice * count;
        }
    }
}
