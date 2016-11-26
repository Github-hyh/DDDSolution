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
    public class RoleAppService
    {
        IRepositoryContext context = ServiceLocator.Instance.GetService(typeof(IRepositoryContext))
            as IRepositoryContext;
        IRepository<BAS_Department> departmentrepository = ServiceLocator.Instance.GetService(typeof(IRepository<BAS_Department>))
            as IRepository<BAS_Department>;
        IRepository<BAS_IdentityContainer> identitycontainerrepository = ServiceLocator.Instance.GetService(typeof(IRepository<BAS_IdentityContainer>))
            as IRepository<BAS_IdentityContainer>;
        IRepository<BAS_Role> rolerepository = ServiceLocator.Instance.GetService(typeof(IRepository<BAS_Role>))
            as IRepository<BAS_Role>;
        IRepository<BAS_User> userrepository = ServiceLocator.Instance.GetService(typeof(IRepository<BAS_User>))
            as IRepository<BAS_User>;
        IRepository<BAS_Post> postrepository = ServiceLocator.Instance.GetService(typeof(IRepository<BAS_Post>))
            as IRepository<BAS_Post>;
        IRepository<BAS_UR> urrepository = ServiceLocator.Instance.GetService(typeof(IRepository<BAS_UR>))
            as IRepository<BAS_UR>;
        IRepository<BAS_DR> drrepository = ServiceLocator.Instance.GetService(typeof(IRepository<BAS_DR>))
            as IRepository<BAS_DR>;
        IRepository<BAS_PR> prrepository = ServiceLocator.Instance.GetService(typeof(IRepository<BAS_PR>))
            as IRepository<BAS_PR>;

        BAS_RoleService roleserivice;
        BAS_Role bas_role;
        public RoleAppService()
        {
            roleserivice =
                new BAS_RoleService(rolerepository, userrepository, departmentrepository,
                postrepository, identitycontainerrepository, urrepository,
                drrepository, prrepository);
            bas_role = new BAS_Role(rolerepository);
        }

        /// <summary>
        /// 角色创建
        /// </summary>
        /// <param name="name"></param>
        /// <param name="description"></param>
        public void CreateRole(string name,string description)
        {
            roleserivice.CreateRole(name, description);
            context.Commit();
        }
        /// <summary>
        /// 根据角色名返回角色
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public BAS_Role GetRoleByName(string name)
        {
            return bas_role.GetRoleByName(name);
        }

        /// <summary>
        /// 添加用户到角色
        /// </summary>
        /// <param name="usernos"></param>
        /// <param name="rolename"></param>
        public void AddUserToRole(string [] usernos,string rolename)
        {
            roleserivice.AddUserToRole(usernos.ToList(), rolename);
            context.Commit();
        }

        /// <summary>
        /// 添加部门到角色
        /// </summary>
        /// <param name="departmentnames"></param>
        /// <param name="rolename"></param>
        public void AddDepartmentToRole(string [] departmentnames,string rolename)
        {
            roleserivice.AddDepartmentToRole(departmentnames.ToList(), rolename);
            context.Commit();
        }

        /// <summary>
        /// 添加岗位到角色
        /// </summary>
        /// <param name="postnames"></param>
        /// <param name="rolename"></param>
        public void AddPostToRole(string [] postnames,string rolename)
        {
            roleserivice.AddPostToRole(postnames.ToList(), rolename);
            context.Commit();
        }

        /// <summary>
        /// 角色是否包含某个用户
        /// </summary>
        /// <param name="userno"></param>
        /// <param name="rolename"></param>
        /// <returns></returns>
        public bool IsRoleContainUser(string userno,string rolename)
        {
            return roleserivice.IsRoleContainUser(userno, rolename);
        }
        /// <summary>
        /// 角色是否包含某个部门
        /// </summary>
        /// <param name="departmentname"></param>
        /// <param name="rolename"></param>
        /// <returns></returns>
        public bool IsRoleContainDepartment(string departmentname,string rolename)
        {
            return roleserivice.IsRoleContainDepartment(departmentname, rolename);
        }
        /// <summary>
        /// 角色是否包含某个岗位
        /// </summary>
        /// <param name="postname"></param>
        /// <param name="rolename"></param>
        /// <returns></returns>
        public bool IsRoleContainPost(string postname,string rolename)
        {
            return roleserivice.IsRoleContainPost(postname, rolename);
        }
    }
}
