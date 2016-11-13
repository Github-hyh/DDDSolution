using DDD.Domain.Model;
using DDD.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain
{
    public partial class SalesOrder:AggreateRoot
    {
        private IRepository<SalesOrder> _IRepository;

        public SalesOrder(IRepository<SalesOrder> irepository)
        {
            this._IRepository = irepository;
        }

        public void CreateOrder(List<Product> products, Customer customer, List<int> amounts, string state, string city, string street)
        {
            SalesOrder order = new SalesOrder();
            order.Id = base.Id;
            order.DateTime = DateTime.Now;
            order.CustomerInfo = new CustomerInfo(customer, new Address(state, city, street));
            for(int i=0; i < products.Count; i++)
            {
                OrderItem orderItem = new OrderItem(products[i], amounts[i]);
                orderItem.ProductInfo = new ProductInfo(products[i]);
                order.OrderItem.Add(orderItem);
                order.TotalPrice += orderItem.LineTotal;
            }
            this._IRepository.Create(order);
        }
    }
}
