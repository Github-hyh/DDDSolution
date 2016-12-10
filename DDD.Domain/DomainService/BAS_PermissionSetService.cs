using DDD.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.DomainService
{
    public class BAS_PermissionSetService
    {
        private IRepository<BAS_PermissionSet> irepositorypermissionset;
        private IRepository<BAS_Permission> irepositorypermission;
        private IRepository<BAS_PPSet> irepositoryppset;
        private IRepository<BAS_PermissionContainer> irepositorypermissioncontainer;
        BAS_PermissionSet bas_permissionset;
        BAS_PPSet bas_ppset;

        public BAS_PermissionSetService(IRepository<BAS_PermissionSet> irepositorypermissionset,
        IRepository<BAS_Permission> irepositorypermission,
        IRepository<BAS_PPSet> irepositoryppset,
        IRepository<BAS_PermissionContainer> irepositorypermissioncontainer)
        {
            this.irepositorypermission = irepositorypermission;
            this.irepositorypermissioncontainer = irepositorypermissioncontainer;
            this.irepositorypermissionset = irepositorypermissionset;
            this.irepositoryppset = irepositoryppset;

            bas_permissionset = new BAS_PermissionSet(irepositorypermissionset);
            bas_ppset = new BAS_PPSet(irepositoryppset);
        }

        /// <summary>
        /// 创建权限集
        /// </summary>
        /// <param name="name"></param>
        /// <param name="description"></param>
        public void CreatePermissionSet(string name,string description)
        {
            var per_id = Guid.NewGuid();
            bas_permissionset.CreatePermissionSet(name, description, per_id);

            var permissioncontainer = new BAS_PermissionContainer(irepositorypermissioncontainer);
            permissioncontainer.CreatePermissionContainer(per_id);
        }

        /// <summary>
        /// 将多个权限添加到权限集中
        /// </summary>
        /// <param name="permissionnames"></param>
        /// <param name="permissionsetname"></param>
        public void AddPermissionToPermissionSet(List<string> permissionnames,
            string permissionsetname)
        {
            var permissionset = bas_permissionset.GetPermissionSetByName(permissionsetname);
            var permissions =new List<BAS_Permission>();
            foreach(var permissionname in permissionnames)
            {
                var bas_permission =
                    new BAS_Permission(irepositorypermission);
                var permission = bas_permission.GetPermissionByName(permissionname);
                permissions.Add(permission);
            }

            bas_ppset.CreateBAS_PPS(permissions, permissionset);
        }

        /// <summary>
        /// 根据权限名获取权限集的信息
        /// </summary>
        /// <param name="permissionname"></param>
        /// <returns></returns>
        public List<BAS_PermissionSet> GetPermissionSetByPermissionName(string permissionname)
        {
            var ppsets = new BAS_PPSetService(irepositorypermission, irepositorypermissionset, irepositoryppset)
                .GetppsetbyPermissionName(permissionname);
            var listpermissionset = new List<BAS_PermissionSet>();
            foreach(var ppset in ppsets)
            {
                var permissionset = irepositorypermissionset.GetByCondition
                    (p => p.Id == ppset.BAS_PermissionSet.Id, p => true).SingleOrDefault();
                listpermissionset.Add(permissionset);
            }
            return listpermissionset;
        }

        /// <summary>
        /// 判断某个权限是否在某个权限集中
        /// </summary>
        /// <param name="permissionname"></param>
        /// <param name="permissionsetname"></param>
        /// <returns></returns>
        public bool IsPermissionSetContainPermission(string permissionname,
            string permissionsetname)
        {
            return GetPermissionSetByPermissionName(permissionname).
                Contains(bas_permissionset.GetPermissionSetByName(permissionsetname));
        }
    }
}
