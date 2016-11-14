using AutoMapper;
using DDD.Domain.Model;
using DDD.Domain.Repository;
using DDD.TransferDTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain
{
    public partial class Product:AggreateRoot
    {
        private IRepository<Product> _IRepository;

        public Product(IRepository<Product> irepository)
        {
            _IRepository = irepository;
            //ProductMapping();
        }

        public Product()
        { }

        //public void CreateProduct(string name, string color, string size, int count, decimal unitPrice, string categoryName, string description)
        //{
        //    var product = new Product();
        //    product.Id = base.Id;
        //    product.ProductName = name;
        //    product.Color = color;
        //    product.Size = size;
        //    product.Count = count;
        //    product.UnitPrice = unitPrice;
        //    product.ProductCategory = new ProductCategory(categoryName, description);
        //    this._IRepository.Create(product);
        //}

        public void CreateProduct(ProductDTO productDTO)
        {
            productDTO.Id = Guid.NewGuid();
            this._IRepository.Create(productDTO);
        }

        public void ModifyCount(Product p, int amount, IRepository<Product> irepository)
        {
            p.Count = this.Count - amount;
            irepository.Update(p);
        }

        public Product GetProductByName(string pName)
        {
            return this._IRepository.GetByCondition(p => p.ProductName == pName).FirstOrDefault();
        }
    }
}
