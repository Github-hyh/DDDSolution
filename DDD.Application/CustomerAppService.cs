using DDD.Domain;
using DDD.Domain.Repository;
using DDD.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Application
{
    public class CustomerAppService
    {
        IRepositoryContext context = ServiceLocator.Instance.GetService(typeof(IRepositoryContext))
          as IRepositoryContext;
        IRepository<Customer> customerrepository = ServiceLocator.Instance.GetService(typeof(IRepository<Customer>))
            as IRepository<Customer>;

        Customer customer;

        public CustomerAppService()
        {
            customer = new Customer(customerrepository);
        }

        public void CreateCustomer(string name,string mobile,
            string state,string city,string street)
        {
            customer.CreateCustomer(name, mobile, state, city, street);
            context.Commit();
        }

        public Customer GetCustomerByName(string customername)
        {
            return customer.GetCustomerByName(customername);
        }

        /// <summary>
        /// 获取所有客户信息列表
        /// </summary>
        /// <returns></returns>
        public List<Customer> GetAllCustomer()
        {
            return customer.GetAllCustomer();
        }
    }
}
