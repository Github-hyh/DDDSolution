using DDD.Domain.Model;
using DDD.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain
{
    public partial class BAS_PPSet:AggreateRoot
    {
        private IRepository<BAS_PPSet> irepository;
        public BAS_PPSet(IRepository<BAS_PPSet> irepository)
        {
            this.irepository = irepository;
        }
        public BAS_PPSet() { }

        /// <summary>
        /// 添加多个权限到权限集中
        /// </summary>
        /// <param name="permissions"></param>
        /// <param name="permissionset"></param>
        public void CreateBAS_PPS(List<BAS_Permission> permissions,BAS_PermissionSet
            permissionset)
        {
            foreach(var permission in permissions)
            {
                var bas_ppset = new BAS_PPSet();
                bas_ppset.Id = base.Id;
                bas_ppset.BAS_Permission = permission;
                bas_ppset.BAS_PermissionSet = permissionset;
                irepository.Create(bas_ppset);
            }
        }

        /// <summary>
        /// 根据权限查找PPSET
        /// </summary>
        /// <param name="permission"></param>
        /// <returns></returns>
        public List<BAS_PPSet> GetppsetByPermission(BAS_Permission permission)
        {
            return irepository.GetByCondition(p => p.BAS_Permission.Id == permission.Id,
                p => true);
        }

        /// <summary>
        /// 根据权限集查找PPSET
        /// </summary>
        /// <param name="permission"></param>
        /// <returns></returns>
        public List<BAS_PPSet> GetppsetByPermissionSet(BAS_PermissionSet permissionset)
        {
            return irepository.GetByCondition(p => p.BAS_PermissionSet.Id == permissionset.Id,
                p => true);
        }
    }
}
