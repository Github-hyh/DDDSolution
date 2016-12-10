using DDD.Domain.Model;
using DDD.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain
{
    public partial class BAS_PermissionContainer:AggreateRoot
    {
        private IRepository<BAS_PermissionContainer> irepository;
        public BAS_PermissionContainer(IRepository<BAS_PermissionContainer> irepository)
        {
            this.irepository = irepository;
        }
        public void CreatePermissionContainer(Guid per_id)
        {
            var bas_permissioncontainer = new BAS_PermissionContainer();
            bas_permissioncontainer.Id = per_id;
            irepository.Create(bas_permissioncontainer);
        }
    }
}
