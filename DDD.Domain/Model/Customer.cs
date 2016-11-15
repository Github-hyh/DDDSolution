using DDD.Domain.Model;
using DDD.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain
{
    public partial class Customer:AggreateRoot
    {
        private IRepository<Customer> _IRepository;

        public Customer(IRepository<Customer> irepository)
        {
            _IRepository = irepository;
        }

        public void CreateCustomer(string name,string mobile,string state,string city,string street)
        {
            Customer customer = new Customer();
            customer.Id = base.Id;
            customer.Name = name;
            customer.Mobile = mobile;
            customer.Address.Add(new Address(state, city, street));
            this._IRepository.Create(customer);
        }

        private void AddCustomerAddress(Customer customer,string state,string city,string street)
        {
            customer.Address.Add(new Address(state, city, street));
            this._IRepository.Update(customer);
        }

        public Customer GetCustomerByName(string name)
        {
            return this._IRepository.GetByCondition(c => c.Name == name, p=>true).FirstOrDefault();
        }
    }
}
