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
                Id = p.Id,
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
            context.Commit();
        }
        
        public Product GetProductByName(string name)
        {
            return product.GetProductByName(name);
        }

        public ProductDTO GetProductDTOByName(string pName)
        {
            return this.productRepository.GetByCondition<ProductDTO>(p => p.ProductName == pName , p=>true).FirstOrDefault();
        }

        public List<ProductDTO> GetProductDTOSByCondition(List<Conditions> conditions, RequestPage request, out int totalCount)
        {
            return this.productRepository.GetByConditionPages<ProductDTO>(conditions, p=>true, request, out totalCount);
        }

        /// <summary>
        /// 根据用户权限返回用户需要访问的信息
        /// </summary>
        /// <param name="conditions"></param>
        /// <param name="request"></param>
        /// <param name="totalcount"></param>
        /// <returns></returns>
        public List<Product> GetProductByCondition(List<Conditions> conditions,
            RequestPage request, out int totalcount)
        {
            string selector;
            var query = productRepository.GetByConditionPages(conditions, new PermissionAssignAppService<Product>()
                .GetPermissionLamda(out selector, OperationType.Read), request, out totalcount)
                .AsQueryable();
            if (selector != null)
            {
                query = query.Select(selector);
            }

            return query.ToList();
        }

        /// <summary>
        /// 获取所有产品信息列表
        /// </summary>
        /// <returns></returns>
        public List<Product> GetAllProduct()
        {
            return product.GetAllProduct();
        }

        /// <summary>
        /// 获取所有产品DTO信息列表
        /// </summary>
        /// <returns></returns>
        public List<ProductDTO> GetAllProductDTO()
        {
            return product.GetAllProductDTO();
        }

        /// <summary>
        /// 修改产品DTO
        /// </summary>
        /// <param name="productdto"></param>
        public void ModifyProductDTO(ProductDTO productdto)
        {
            product.ModifyProductDTO(productdto);
            context.Commit();
        }

        /// <summary>
        /// 删除产品对象
        /// </summary>
        /// <param name="productname"></param>
        public void DropProduct(string productname)
        {
            product.DropProduct(productname);
            context.Commit();
        }
    }
}
