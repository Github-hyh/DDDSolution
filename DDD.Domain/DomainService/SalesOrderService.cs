using DDD.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;

namespace DDD.Domain.DomainService
{
    public class SalesOrderService:ISalesOrderService
    {
        private IRepository<Product> _IRepositoryProduct;
        private IRepository<Customer> _IRepositoryCustomer;
        private IRepository<SalesOrder> _IRepositorySalesOrder;

        [InjectionConstructor]
        public SalesOrderService(IRepository<Product> irepositoryProduct, 
            IRepository<Customer> irepositoryCustomer,
            IRepository<SalesOrder> irepositorySalesOrder)
        {
            _IRepositoryProduct = irepositoryProduct;
            _IRepositoryCustomer = irepositoryCustomer;
            _IRepositorySalesOrder = irepositorySalesOrder;
        }

        public void CreateSalesOrder(List<string> productNames, List<int> amounts, string customerName,
            string state, string city, string street)
        {
            var products =new List<Product>();
            for(int i = 0; i < productNames.Count; i++)
            {
                var product = new Product(_IRepositoryProduct).GetProductByName(productNames[i]);
                product.ModifyCount(product, amounts[i], _IRepositoryProduct);
                products.Add(product);
            }

            var customer = new Customer(_IRepositoryCustomer).GetCustomerByName(customerName);
            var order = new SalesOrder(_IRepositorySalesOrder);
            order.CreateOrder(products, customer, amounts, state, city, street);
        }
    }
}
