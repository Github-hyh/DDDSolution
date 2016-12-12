using DDD.Domain.Model;
using DDD.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain
{
    public partial class BAS_PermissionAssign:AggreateRoot
    {
        private IRepository<BAS_PermissionAssign> irepository;
        public BAS_PermissionAssign(IRepository<BAS_PermissionAssign> irepository)
        {
            this.irepository = irepository;
        }

        public BAS_PermissionAssign() { }
        /// <summary>
        /// 创建权限分配
        /// </summary>
        /// <param name="identitycontainer"></param>
        /// <param name="objectcontainer"></param>
        /// <param name="permissioncontainer"></param>
        public void CreatePermissionAssign(BAS_IdentityContainer identitycontainer,
            BAS_ObjectContainer objectcontainer,BAS_PermissionContainer permissioncontainer)
        {
            var bas_permissionassign = new BAS_PermissionAssign();
            bas_permissionassign.Id = base.Id;
            bas_permissionassign.BAS_IdentityContainer = identitycontainer;
            bas_permissionassign.BAS_ObjectContainer = objectcontainer;
            bas_permissionassign.BAS_PermissionContainer = permissioncontainer;
            irepository.Create(bas_permissionassign);
        }

        /// <summary>
        /// 判断某个对象ID是否进行了权限分配
        /// </summary>
        /// <param name="obj_id"></param>
        /// <returns></returns>
        public bool GetPermissionAssignObjectIsExists(Guid obj_id)
        {
            return irepository.GetByCondition(p => p.BAS_ObjectContainer.Id == obj_id,
                p => true).Count > 0;
        }

        /// <summary>
        /// 根据权限容器获取权限分配信息
        /// </summary>
        /// <param name="permissioncontainer"></param>
        /// <returns></returns>
        public List<BAS_PermissionAssign> GetPAByPermissionContainer(BAS_PermissionContainer permissioncontainer)
        {
            return irepository.GetByCondition(p => p.BAS_PermissionContainer.Id == permissioncontainer.Id, p => true);
        }

        /// <summary>
        /// 根据对象容器获取权限分配信息
        /// </summary>
        /// <param name="objectcontainer"></param>
        /// <returns></returns>
        public List<BAS_PermissionAssign> GetPAByObjectContainer(BAS_ObjectContainer objectcontainer)
        {
            return irepository.GetByCondition(p => p.BAS_ObjectContainer.Id == objectcontainer.Id, p => true);
        }

        /// <summary>
        /// 根据标识容器获取权限分配信息
        /// </summary>
        /// <param name="identitycontainer"></param>
        /// <returns></returns>
        public List<BAS_PermissionAssign> GetPAByIdentityContainer(BAS_IdentityContainer identitycontainer)
        {
            return irepository.GetByCondition(p => p.BAS_IdentityContainer.Id == identitycontainer.Id, p => true);
        }
    }
}
