using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.Repository
{
    public class RequestPage
    {
        public RequestPage(int pageSize,int currentPage,string orderProperty,string order)
        {
            this.PageSize = pageSize;
            this.CurrentPage = currentPage;
            this.OrderProperty = orderProperty;
            this.Order = order;
        }

        public int PageSize { get; }
        public int CurrentPage { get; }
        public string OrderProperty { get; }
        public string Order { get; }
    }
}
