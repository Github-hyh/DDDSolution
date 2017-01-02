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
        private IRepository<Product> irepository;

        public Product(IRepository<Product> irepository)
        {
            this.irepository = irepository;
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
            this.irepository.Create(productDTO);
        }

        public void ModifyCount(Product p, int amount, IRepository<Product> irepository)
        {
            p.Count = this.Count - amount;
            irepository.Update(p);
        }

        public Product GetProductByName(string pName)
        {
            return this.irepository.GetByCondition(p => p.ProductName == pName, p=>true).FirstOrDefault();
        }

        public List<Product> GetAllProduct()
        {
            return irepository.GetByCondition(p => true, p => true);
        }

        public List<ProductDTO> GetAllProductDTO()
        {
            return irepository.GetByCondition<ProductDTO>(p => true, p => true);
        }

        public void ModifyProductDTO(ProductDTO productdto)
        {
            irepository.Update<ProductDTO>(productdto);
        }

        public void DropProduct(string productname)
        {
            var product = irepository.GetByCondition(p => p.ProductName == productname, p => true).SingleOrDefault();
            List<ProductCategory> pcs = new List<ProductCategory>();
            var productcategory = product.ProductCategory;
            pcs.Add(productcategory);
            irepository.Remove(product,pcs);
        }
    }
}
