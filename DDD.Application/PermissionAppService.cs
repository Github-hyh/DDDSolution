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
    public class PermissionAppService
    {
        IRepositoryContext context = ServiceLocator.Instance.GetService(typeof(IRepositoryContext))
            as IRepositoryContext;
        IRepository<BAS_Permission> permissionrepository = ServiceLocator.Instance.GetService(typeof(IRepository<BAS_Permission>))
            as IRepository<BAS_Permission>;
        IRepository<BAS_PermissionContainer> permissioncontainerrepository = ServiceLocator.Instance.GetService(typeof(IRepository<BAS_PermissionContainer>))
            as IRepository<BAS_PermissionContainer>;

        BAS_PermissionService bas_permissionservice;
        BAS_Permission bas_permission;

        public PermissionAppService()
        {
            bas_permissionservice = new BAS_PermissionService
                (permissionrepository, permissioncontainerrepository);
            bas_permission = new BAS_Permission(permissionrepository);
        }

        /// <summary>
        /// 权限的创建
        /// </summary>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="codeproperty"></param>
        /// <param name="codevalue"></param>
        /// <param name="operationtype"></param>
        public void CreatePermission(string name,string description,string codeproperty,
            string codevalue,OperationType operationtype)
        {
            bas_permissionservice.CreatePermission(name, codeproperty, operationtype, codevalue, description);
            context.Commit();
        }

        /// <summary>
        /// 根据权限名获取权限信息
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public BAS_Permission GetPermissionByName(string name)
        {
            return bas_permission.GetPermissionByName(name);
        }

        public void CreatePermission(string v1, string v2, string v3, string v4, object operationType)
        {
            throw new NotImplementedException();
        }
    }
}
