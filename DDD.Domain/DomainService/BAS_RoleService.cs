using DDD.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.DomainService
{
    public class BAS_RoleService
    {
        private IRepository<BAS_Role> irepositoryrole;
        private IRepository<BAS_User> irepositoryuser;
        private IRepository<BAS_Department> irepositorydepartment;
        private IRepository<BAS_Post> irepositorypost;
        private IRepository<BAS_IdentityContainer> irepositoryidentitycontainer;
        private IRepository<BAS_UR> irepositoryur;
        private IRepository<BAS_DR> irepositorydr;
        private IRepository<BAS_PR> irepositorypr;

        BAS_Role bas_role;

        public BAS_RoleService(IRepository<BAS_Role> irepositoryrole,
        IRepository<BAS_User> irepositoryuser,
       IRepository<BAS_Department> irepositorydepartment,
         IRepository<BAS_Post> irepositorypost,
        IRepository<BAS_IdentityContainer> irepositoryidentitycontainer,
         IRepository<BAS_UR> irepositoryur,
         IRepository<BAS_DR> irepositorydr,
         IRepository<BAS_PR> irepositorypr)
        {
            this.irepositoryrole = irepositoryrole;
            this.irepositoryidentitycontainer = irepositoryidentitycontainer;
            this.irepositoryuser = irepositoryuser;
            this.irepositorydepartment = irepositorydepartment;
            this.irepositorypost = irepositorypost;
            this.irepositoryur = irepositoryur;
            this.irepositorydr = irepositorydr;
            this.irepositorypr = irepositorypr;

            bas_role = new BAS_Role(irepositoryrole);
        }

        /// <summary>
        /// 创建角色
        /// </summary>
        /// <param name="name"></param>
        /// <param name="description"></param>
        public void CreateRole(string name,string description)
        {
            var con_id = Guid.NewGuid();
            bas_role.CreateRole(name, description, con_id);

            var bas_identitycontainer = new BAS_IdentityContainer(irepositoryidentitycontainer);
            bas_identitycontainer.CreateIdentityContainer(con_id);
        }

        /// <summary>
        /// 将多个用户添加到角色
        /// </summary>
        /// <param name="usernos"></param>
        /// <param name="rolename"></param>
        public void AddUserToRole(List<string> usernos,string rolename)
        {
            var role = bas_role.GetRoleByName(rolename);
            var users = new List<BAS_User>();
            foreach(var userno in usernos)
            {
                var user = new BAS_User(irepositoryuser).GetUserByNo(userno);
                users.Add(user);
            }
            new BAS_UR(irepositoryur).CreateBAS_UR(users, role);
        }

        /// <summary>
        /// 将多个部门添加到角色
        /// </summary>
        /// <param name="departmentnames"></param>
        /// <param name="rolename"></param>
        public void AddDepartmentToRole(List<string> departmentnames,string rolename)
        {
            var role = bas_role.GetRoleByName(rolename);
            var departments = new List<BAS_Department>();
            foreach(var departmentname in departmentnames)
            {
                var department = new BAS_Department(irepositorydepartment).GetDepartmentByName(departmentname);
                departments.Add(department);
            }

            new BAS_DR(irepositorydr).CreateBAS_DR(departments, role);
        }

        /// <summary>
        /// 将多个岗位添加到角色
        /// </summary>
        /// <param name="postnames"></param>
        /// <param name="rolename"></param>
        public void AddPostToRole(List<string> postnames,string rolename)
        {
            var role = bas_role.GetRoleByName(rolename);
            var posts = new List<BAS_Post>();
            foreach(var postname in postnames)
            {
                var post = new BAS_Post(irepositorypost).GetPostByName(postname);
                posts.Add(post);
            }

            new BAS_PR(irepositorypr).CreateBAS_PR(posts, role);
        }

        /// <summary>
        /// 根据用户NO获取用户所属角色
        /// </summary>
        /// <param name="no"></param>
        /// <returns></returns>
        public List<BAS_Role> GetRoleByUserNo(string no)
        {
            var urs =
                new BAS_URService(irepositoryuser, irepositoryrole, irepositoryur)
                .GetURSByUserNo(no);
            var roles = new List<BAS_Role>();
            foreach(var ur in urs)
            {
                var role =
                    irepositoryrole.GetByCondition(p => p.Id == ur.BAS_Role.Id, p => true).SingleOrDefault();
                roles.Add(role);
            }
            return roles;
        }

        public bool IsRoleContainUser(string no,string rolename)
        {
            return GetRoleByUserNo(no).Contains(bas_role.GetRoleByName(rolename));
        }

        /// <summary>
        /// 根据部门名获取所属的角色
        /// </summary>
        /// <param name="departmentname"></param>
        /// <returns></returns>
        public List<BAS_Role> GetRoleByDepartmentName(string departmentname)
        {
            var drs =
                new BAS_DRService(irepositorydepartment, irepositoryrole, irepositorydr)
                .GetDRSByDepartmentName(departmentname);
            var roles = new List<BAS_Role>();
            foreach(var dr in drs)
            {
                var role =
                    irepositoryrole.GetByCondition(p => p.Id == dr.BAS_Role.Id, p => true)
                    .SingleOrDefault();
                roles.Add(role);
            }

            return roles;
        }

        public bool IsRoleContainDepartment(string departmentname,string rolename)
        {
            return GetRoleByDepartmentName(departmentname).Contains(bas_role.GetRoleByName(rolename));
        }

        /// <summary>
        /// 根据岗位名获取所属角色信息
        /// </summary>
        /// <param name="postname"></param>
        /// <returns></returns>
        public List<BAS_Role> GetRoleByPostName(string postname)
        {
            var prs =
                new BAS_PRService(irepositorypost, irepositoryrole, irepositorypr)
                .GetPRSByPostName(postname);
            var roles = new List<BAS_Role>();
            foreach(var pr in prs)
            {
                var role =
                    irepositoryrole.GetByCondition(p => p.Id == pr.BAS_Role.Id, p => true)
                    .SingleOrDefault();
                roles.Add(role);
            }
            return roles;
        }

        public bool IsRoleContainPost(string postname,string rolename)
        {
            return GetRoleByPostName(postname).Contains(bas_role.GetRoleByName(rolename));
        }
    }
}
