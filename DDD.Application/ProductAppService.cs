using DDD.Domain;
using DDD.Domain.Repository;
using DDD.Infrastructure;
using DDD.Repository;
using DDD.Repository.Repositories;
using DDD.TransferDTOS;

namespace DDD.Application
{
    public class ProductAppService
    {
        //EFRepositoryContext context = new EFRepositoryContext();
        IRepositoryContext context = ServiceLocator.Instance.GetService(typeof(IRepositoryContext)) as IRepositoryContext;

        Product product = new Product(new ProductRepository());

        //public void CreateProduct(string name, string color, string size, int count, decimal unitprice, string categoryName, string description)
        //{
        //    context.Committed = false;
        //    product.CreateProduct(name, color, size, count, unitprice, categoryName, description);
        //    context.Commit();
        //}

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
            return product.GetProductDTOByName(pName);
        }
    }
}
