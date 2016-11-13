using DDD.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain
{
    public partial class Address:ValueObject
    {
        public Address(string state,string city,string street)
        {
            this.Id = base.Id;
            this.State = state;
            this.City = city;
            this.Street = street;
        }
    }
}
