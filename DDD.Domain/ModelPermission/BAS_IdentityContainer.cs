using DDD.Domain.Model;
using DDD.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain
{
    public partial class BAS_IdentityContainer:AggreateRoot
    {
        private IRepository<BAS_IdentityContainer> irepository;
        public BAS_IdentityContainer(IRepository<BAS_IdentityContainer> irepository)
        {
            this.irepository = irepository;
        }

        /// <summary>
        /// 创建标识容器对象
        /// </summary>
        /// <param name="con_id"></param>
        public void CreateIdentityContainer(Guid con_id)
        {
            var bas_identitycontainer = new BAS_IdentityContainer();
            bas_identitycontainer.Id = con_id;
            irepository.Create(bas_identitycontainer);
        }
    }
}
