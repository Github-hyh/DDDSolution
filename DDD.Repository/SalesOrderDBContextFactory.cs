using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDD.Domain;
using System.Runtime.Remoting.Messaging;

namespace DDD.Repository
{
    public class SalesOrderDBContextFactory
    {
        public static SalesOrdersModelContainer Create()
        {
            var salesOrderDbContext = CallContext.GetData("salesorderdbcontext") as SalesOrdersModelContainer;
            if(salesOrderDbContext == null)
            {
                salesOrderDbContext = new SalesOrdersModelContainer();
                CallContext.SetData("salesorderdbcontext", salesOrderDbContext);
            }
            return salesOrderDbContext;
        }
    }
}
