using AutoMapper;
using DDD.Domain;
using DDD.Domain.Repository;
using DDD.Infrastructure;
using DDD.Infrastructure.LamdaFilterConvert;
using DDD.Repository;
using DDD.Repository.Repositories;
using DDD.TransferDTOS;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DDD.Application
{
    public class ProductAppService
    {
        //EFRepositoryContext context = new EFRepositoryContext();
        IRepositoryContext context = ServiceLocator.Instance.GetService(typeof(IRepositoryContext)) as IRepositoryContext;
        IRepository<Product> productRepository = ServiceLocator.Instance.GetService(typeof(IRepository<Product>))
                as IRepository<Product>;
        Product product = null;

        //public void CreateProduct(string name, string color, string size, int count, decimal unitprice, string categoryName, string description)
        //{
        //    context.Committed = false;
        //    product.CreateProduct(name, color, size, count, unitprice, categoryName, description);
        //    context.Commit();
        //}

        public ProductAppService()
        {
            product = new Product(productRepository);
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

        public void CreateProduct(ProductDTO productdto)
        {
            product.CreateProduct(productdto);
        }
        
        public Product GetProductByName(string name)
        {
            return product.GetProductByName(name);
        }

        public ProductDTO GetProductDTOByName(string pName)
        {
            return this.productRepository.GetByCondition<ProductDTO>(p => p.ProductName == pName).FirstOrDefault();
        }

        public List<ProductDTO> GetProductDTOSByCondition(List<Conditions> conditions, RequestPage request, out int totalCount)
        {
            return this.productRepository.GetByConditionPages<ProductDTO>(conditions, request, out totalCount);
        }
    }
}
