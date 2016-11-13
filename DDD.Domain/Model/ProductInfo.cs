using DDD.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain
{
    public partial class ProductInfo:ValueObject
    {
        public ProductInfo(Product product)
        {
            this.Id = base.Id;
            this.Name = product.ProductName;
            this.UnitPrice = product.UnitPrice;
        }
    }
}
