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
            ProductMapping();
        }

        private void ProductMapping()
        {
            var mapIn = Mapper.CreateMap<ProductDTO, Product>();
            mapIn.ConstructProjectionUsing(p => new Product
            {
                ProductName = p.Name,
                Size = p.Size,
                Color = p.Color,
                Count = p.Amount,
                UnitPrice = p.UnitPrice,
                ProductCategory = new ProductCategory
                {
                    Id = Guid.NewGuid(),
                    CategoryName = p.PCategoryName,
                    Description = p.PDescription
                }
            });

            var mapOut = Mapper.CreateMap<Product, ProductDTO>();
            mapOut.ConstructProjectionUsing(p => new ProductDTO
            {
                Name = p.ProductName,
                Size = p.Size,
                Color = p.Color,
                Amount = p.Count,
                UnitPrice = p.UnitPrice,
                PCategoryName = p.ProductCategory.CategoryName,
                PDescription = p.ProductCategory.Description
            });
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

        public ProductDTO GetProductDTOByName(string pName)
        {
            return this._IRepository.GetByCondition<ProductDTO>(p => p.ProductName == pName).FirstOrDefault();
        }
    }
}
