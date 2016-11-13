using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.DomainService
{
    public interface ISalesOrderService
    {
        void CreateSalesOrder(List<string> productNames, List<int> amounts, string customerName,
            string state, string city, string street);
    }
}
