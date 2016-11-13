using DDD.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain
{
    public partial class ProductCategory:ValueObject
    {
        public ProductCategory(string categoryName, string description)
        {
            this.Id = base.Id;
            this.CategoryName = categoryName;
            this.Description = description;
        }

        public ProductCategory()
        { }
    }
}
