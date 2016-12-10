using DDD.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.DomainService
{
    public class BAS_PermissionService
    {
        private IRepository<BAS_Permission> irepositorypermission;
        private IRepository<BAS_PermissionContainer> irepositorypermissioncontainer;

        public BAS_PermissionService(IRepository<BAS_Permission> irepositorypermission,
            IRepository<BAS_PermissionContainer> irepositorypermissioncontainer)
        {
            this.irepositorypermission = irepositorypermission;
            this.irepositorypermissioncontainer = irepositorypermissioncontainer;
        }

        public void CreatePermission(string name,string codeproperty,OperationType 
            operationtype,string value,string description)
        {
            var bas_permission = new BAS_Permission(irepositorypermission);
            var per_id = Guid.NewGuid();
            bas_permission.CreatePermission(name, codeproperty, operationtype, value, description,
                per_id);

            var bas_permissioncontainer = new BAS_PermissionContainer(irepositorypermissioncontainer);
            bas_permissioncontainer.CreatePermissionContainer(per_id);
        }
    }
}
