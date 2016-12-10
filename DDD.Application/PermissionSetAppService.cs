using DDD.Domain;
using DDD.Domain.DomainService;
using DDD.Domain.Repository;
using DDD.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Application
{
    public class PermissionSetAppService
    {
        IRepositoryContext context = ServiceLocator.Instance.GetService(typeof(IRepositoryContext))
            as IRepositoryContext;
        IRepository<BAS_Permission> permissionrepository = ServiceLocator.Instance.GetService(typeof(IRepository<BAS_Permission>))
            as IRepository<BAS_Permission>;
        IRepository<BAS_PermissionContainer> permissioncontainerrepository = ServiceLocator.Instance.GetService(typeof(IRepository<BAS_PermissionContainer>))
            as IRepository<BAS_PermissionContainer>;
        IRepository<BAS_PermissionSet> permissionsetrepository = ServiceLocator.Instance.GetService(typeof(IRepository<BAS_PermissionSet>))
            as IRepository<BAS_PermissionSet>;
        IRepository<BAS_PPSet> ppsetrepository = ServiceLocator.Instance.GetService(typeof(IRepository<BAS_PPSet>))
            as IRepository<BAS_PPSet>;

        BAS_PermissionSetService bas_permissionsetservice;
        BAS_PermissionSet bas_permissionset;

        public PermissionSetAppService()
        {
            bas_permissionsetservice = new BAS_PermissionSetService(permissionsetrepository,
                permissionrepository, ppsetrepository, permissioncontainerrepository);
            bas_permissionset = new BAS_PermissionSet(permissionsetrepository);
        }
        /// <summary>
        /// 创建权限集
        /// </summary>
        /// <param name="name"></param>
        /// <param name="description"></param>
        public void CreatePermissionSet(string name,string description)
        {
            bas_permissionsetservice.CreatePermissionSet(name, description);
            context.Commit();
        }
        /// <summary>
        /// 根据权限集名获取权限集信息
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public BAS_PermissionSet GetPermissionSetByName(string name)
        {
            return bas_permissionset.GetPermissionSetByName(name);
        }

        /// <summary>
        /// 添加多个权限到权限集
        /// </summary>
        /// <param name="permissionnames"></param>
        /// <param name="permissionsetname"></param>
        public void AddPermissionToPermissionSet(string[] permissionnames,string 
            permissionsetname)
        {
            bas_permissionsetservice.AddPermissionToPermissionSet(permissionnames
                .ToList(), permissionsetname);
            context.Commit();
        }

        /// <summary>
        /// 判断某个权限是否在某个权限集中
        /// </summary>
        /// <param name="permissionname"></param>
        /// <param name="permissionsetname"></param>
        /// <returns></returns>
        public bool IsPermissionSetContainpermission(string permissionname,
            string permissionsetname)
        {
            return bas_permissionsetservice.IsPermissionSetContainPermission(permissionname,
                permissionsetname);
        }
    }
}
