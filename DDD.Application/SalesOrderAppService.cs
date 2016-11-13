using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDD.Domain;
using DDD.Repository;
using DDD.Domain.DomainService;
using DDD.Repository.Repositories;
using DDD.Domain.Repository;
using DDD.Infrastructure;
using Microsoft.Practices.Unity;

namespace DDD.Application
{
    public class SalesOrderAppService
    {
        //EFRepositoryContext context = new EFRepositoryContext();
        IRepositoryContext context = ServiceLocator.Instance.GetService(typeof(IRepositoryContext))
            as IRepositoryContext;
        IRepository<Product> productRepository = ServiceLocator.Instance.GetService(typeof(IRepository<Product>))
            as IRepository<Product>;
        IRepository<Customer> customerRepository = ServiceLocator.Instance.GetService(typeof(IRepository<Customer>))
           as IRepository<Customer>;
        IRepository<SalesOrder> salesOrderRepository = ServiceLocator.Instance.GetService(typeof(IRepository<SalesOrder>))
            as IRepository<SalesOrder>;
        ISalesOrderService salesOrderService = ServiceLocator.Instance.GetService(typeof(ISalesOrderService),
            new ParameterOverrides { { "irepositoryProduct", "productRepository" },
                { "irepositoryCustomer", "customerRepository" },
                { "irepositorySalesOrder","salesOrderRepository"} }) as ISalesOrderService;

        public void CreateSalesOrder(List<string> productNames, List<int> amounts, string customerName,
            string state, string city, string street)
        {
            //var salesOrderService = new SalesOrderService(new ProductRepository(),new CustomerRepository(),new SalesOrderRepository());
            salesOrderService.CreateSalesOrder(productNames, amounts, customerName, state, city, street);

            context.Commit();
        }
    }
}
