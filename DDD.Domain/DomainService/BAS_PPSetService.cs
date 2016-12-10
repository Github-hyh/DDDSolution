using DDD.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.DomainService
{
    public class BAS_PPSetService
    {
        private IRepository<BAS_Permission> irepositorypermission;
        private IRepository<BAS_PermissionSet> irepositorypermissionset;
        private IRepository<BAS_PPSet> irepositoryppset;
        BAS_PPSet bas_ppset;

        public BAS_PPSetService(IRepository<BAS_Permission> irepositorypermission,
            IRepository<BAS_PermissionSet> irepositorypermissionset,
            IRepository<BAS_PPSet> irepositoryppset)
        {
            this.irepositorypermission = irepositorypermission;
            this.irepositorypermissionset = irepositorypermissionset;
            this.irepositoryppset = irepositoryppset;
            bas_ppset = new BAS_PPSet(irepositoryppset);
        }

        /// <summary>
        /// 创建多个权限到权限集中
        /// </summary>
        /// <param name="permissionnames"></param>
        /// <param name="permissionsetname"></param>

        public void CreateBAS_PPS(string[] permissionnames,string permissionsetname)
        {
            var listpermission = new List<BAS_Permission>();
            for(int i=0;i<permissionnames.Length;i++)
            {
                var permission =
                    irepositorypermission.GetByCondition(p => p.Name == permissionnames[i],
                    p => true).SingleOrDefault();
                listpermission.Add(permission);
            }

            var permissionset = irepositorypermissionset.GetByCondition(p => p.Name ==
              permissionsetname, p => true).SingleOrDefault();
            bas_ppset.CreateBAS_PPS(listpermission, permissionset);
        }
        /// <summary>
        /// 根据权限名获取PPSET
        /// </summary>
        /// <param name="permissionname"></param>
        /// <returns></returns>
        public List<BAS_PPSet> GetppsetbyPermissionName(string permissionname)
        {
            var permission =
                irepositorypermission.GetByCondition(p => p.Name == permissionname, p => true)
                .SingleOrDefault();
            return bas_ppset.GetppsetByPermission(permission);
        }
        /// <summary>
        /// 根据权限集名获取PPSET
        /// </summary>
        /// <param name="permissionsetname"></param>
        /// <returns></returns>
        public List<BAS_PPSet> GEtppsetbyPermissionSetName(string permissionsetname)
        {
            var permissionset =
                irepositorypermissionset.GetByCondition(p => p.Name == permissionsetname, p => true)
                .SingleOrDefault();
            return bas_ppset.GetppsetByPermissionSet(permissionset);
        }
    }
}
