using DDD.Domain;
using DDD.Domain.Aggreate;
using DDD.Domain.DomainService;
using DDD.Domain.Repository;
using DDD.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Application
{
    public class PermissionAssignAppService<TAggreateRoot> where TAggreateRoot : class,
        IAggreateRoot
    {
        IRepositoryContext context = ServiceLocator.Instance.GetService(typeof(IRepositoryContext))
            as IRepositoryContext;
        IRepository<BAS_PermissionAssign> permissionassignrepository = ServiceLocator.Instance.GetService(typeof(IRepository<BAS_PermissionAssign>))
            as IRepository<BAS_PermissionAssign>;
        IRepository<BAS_IdentityContainer> identitycontainerrepository = ServiceLocator.Instance.GetService(typeof(IRepository<BAS_IdentityContainer>))
            as IRepository<BAS_IdentityContainer>;
        IRepository<BAS_ObjectContainer> objectcontainerrepository = ServiceLocator.Instance.GetService(typeof(IRepository<BAS_ObjectContainer>))
            as IRepository<BAS_ObjectContainer>;
        IRepository<BAS_PermissionContainer> permissioncontainerrepository = ServiceLocator.Instance.GetService(typeof(IRepository<BAS_PermissionContainer>))
            as IRepository<BAS_PermissionContainer>;
        IRepository<BAS_User> userrepository = ServiceLocator.Instance.GetService(typeof(IRepository<BAS_User>))
            as IRepository<BAS_User>;
        IRepository<BAS_Department> departmentrepository = ServiceLocator.Instance.GetService(typeof(IRepository<BAS_Department>))
            as IRepository<BAS_Department>;
        IRepository<BAS_Post> postrepository = ServiceLocator.Instance.GetService(typeof(IRepository<BAS_Post>))
            as IRepository<BAS_Post>;
        IRepository<BAS_Role> rolerepository = ServiceLocator.Instance.GetService(typeof(IRepository<BAS_Role>))
            as IRepository<BAS_Role>;

        IRepository<BAS_Object> objectrepository = ServiceLocator.Instance.GetService(typeof(IRepository<BAS_Object>))
            as IRepository<BAS_Object>;
        IRepository<BAS_ObjectSet> objectsetrepository = ServiceLocator.Instance.GetService(typeof(IRepository<BAS_ObjectSet>))
            as IRepository<BAS_ObjectSet>;
        IRepository<BAS_Permission> permissionrepository = ServiceLocator.Instance.GetService(typeof(IRepository<BAS_Permission>))
            as IRepository<BAS_Permission>;

        IRepository<BAS_PermissionSet> permissionsetrepository = ServiceLocator.Instance.GetService(typeof(IRepository<BAS_PermissionSet>))
            as IRepository<BAS_PermissionSet>;

        IRepository<BAS_OOSet> oosetrepository = ServiceLocator.Instance.GetService(typeof(IRepository<BAS_OOSet>))
            as IRepository<BAS_OOSet>;
        BAS_PermissionAssignService<TAggreateRoot> bas_permissionservice;

        public PermissionAssignAppService()
        {
            bas_permissionservice =
                new BAS_PermissionAssignService<TAggreateRoot>(permissionassignrepository,
                identitycontainerrepository, objectcontainerrepository, permissioncontainerrepository,
                userrepository, departmentrepository, postrepository, rolerepository, objectrepository,
                objectsetrepository, permissionrepository, permissionsetrepository, oosetrepository);
        }

        /// <summary>
        /// 角色分配创建
        /// </summary>
        /// <param name="userno"></param>
        /// <param name="departmentname"></param>
        /// <param name="postname"></param>
        /// <param name="rolename"></param>
        /// <param name="objectname"></param>
        /// <param name="objectsetname"></param>
        /// <param name="permissionname"></param>
        /// <param name="permissionsetname"></param>
        public void CreatePermissionAssgin(string userno, string departmentname, string postname,
            string rolename, string objectname, string objectsetname, string permissionname,
            string permissionsetname)
        {
            bas_permissionservice.CreatePermissionAssgin(userno, departmentname, postname,
                rolename, objectname, objectsetname, permissionname, permissionsetname);
            context.Commit();
        }

        /// <summary>
        /// 查找权限，返回lamda表达式
        /// </summary>
        /// <param name="selector"></param>
        /// <param name="operation"></param>
        /// <returns></returns>
        public Expression<Func<TAggreateRoot, bool>> GetPermissionLamda(out string selector,
            OperationType operation)
        {
            return bas_permissionservice.GetPermissionLamda(out selector, operation);
        }

    }
}
