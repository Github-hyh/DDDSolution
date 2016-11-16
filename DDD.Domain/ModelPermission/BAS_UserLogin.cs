using DDD.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain
{
    public partial class BAS_UserLogin:ValueObject
    {
        public BAS_UserLogin(string password)
        {
            Id = base.Id;
            Password = password;
        }
    }
}
