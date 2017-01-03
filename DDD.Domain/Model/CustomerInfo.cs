using DDD.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain
{
    public partial class CustomerInfo:ValueObject
    {
        public CustomerInfo() { }

        public CustomerInfo(Customer customer, Address address)
        {
            this.Id = base.Id;
            this.Name = customer.Name;
            this.Mobile = customer.Mobile;
            this.State = address.State;
            this.City = address.City;
            this.Street = address.Street;
        }
    }
}
