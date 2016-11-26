using DDD.Domain.Repository;
using DDD.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.DomainService
{
    public class BAS_UserService
    {
        private IRepository<BAS_User> irepositoryuser;
        private IRepository<BAS_IdentityContainer> irepositoryidentitycontainer;
        private IRepository<BAS_Role> irepositoryrole;
        private IRepository<BAS_Department> irepositorydepartment;
        private IRepository<BAS_Post> irepositorypost;
        private IRepository<BAS_UR> irepositoryur;
        private IRepository<BAS_UDPSet> irepositoryudp;
        private IRepository<BAS_DR> irepositorydr;
        private IRepository<BAS_PR> irepositorypr;

        BAS_User bas_user;

        public BAS_UserService(IRepository<BAS_User> irepositoryuser,
        IRepository<BAS_IdentityContainer> irepositoryidentitycontainer,
        IRepository<BAS_Role> irepositoryrole,
        IRepository<BAS_Department> irepositorydepartment,
       IRepository<BAS_Post> irepositorypost,
        IRepository<BAS_UR> irepositoryur,
        IRepository<BAS_UDPSet> irepositoryudp,
        IRepository<BAS_DR> irepositorydr,
       IRepository<BAS_PR> irepositorypr)
        {
            this.irepositoryuser = irepositoryuser;
            this.irepositoryrole = irepositoryrole;
            this.irepositorydepartment = irepositorydepartment;
            this.irepositorypost = irepositorypost;
            this.irepositoryidentitycontainer = irepositoryidentitycontainer;
            this.irepositoryur = irepositoryur;
            this.irepositoryudp = irepositoryudp;
            this.irepositorydr = irepositorydr;
            this.irepositorypr = irepositorypr;

            bas_user = new BAS_User(irepositoryuser);
        }

        /// <summary>
        /// 创建用户
        /// </summary>
        /// <param name="no"></param>
        /// <param name="name"></param>
        /// <param name="mobile"></param>
        /// <param name="password"></param>
        public void CreateUser(string no, string name, string mobile, string password)
        {
            var con_id = Guid.NewGuid();
            bas_user.CreateUser(no, name, mobile, con_id, password);

            var bas_identitycontainer = new BAS_IdentityContainer(irepositoryidentitycontainer);
            bas_identitycontainer.CreateIdentityContainer(con_id);

        }

        public bool UserLogin(string no, string password)
        {
            var loginresult = bas_user.LoginVerify(no, password);
            if (loginresult)
            {
                SessionHelper.AddSession("UserNo", no);
                var conids = GetUserAllCon_Id(no);
                var sconids = new string[conids.Count];
                for (int i = 0; i < conids.Count; i++)
                {
                    sconids[i] = conids[i].ToString();
                }
                SessionHelper.AddSession("UserConId", sconids);
            }
            return loginresult;
        }

        private List<Guid> GetUserAllCon_Id(string no)
        {
            var userallcon_ids = new List<Guid>();
            //获取用户自身的Con_id
            userallcon_ids.Add(bas_user.GetUserByNo(no).Con_Id);

            var roleservice = new BAS_RoleService(irepositoryrole, irepositoryuser,
                irepositorydepartment, irepositorypost, irepositoryidentitycontainer, irepositoryur,
                irepositorydr, irepositorypr);
            //获取用户所属的角色
            var userroles = roleservice.GetRoleByUserNo(no);
            userallcon_ids.AddRange(userroles.Select(p => p.Con_Id));
            //获取用户所属的部门
            var departmentservice = new BAS_DepartmentService(irepositorydepartment,
                irepositoryidentitycontainer, irepositoryudp, irepositoryuser);
            var userdepartments = departmentservice.GetDepartmentByUserNo(no);
            userallcon_ids.AddRange(userdepartments.Select(p => p.Con_Id));
            //获取部门所属的角色
            foreach (var userdepartment in userdepartments)
            {
                var roles = roleservice.GetRoleByDepartmentName(userdepartment.Name);
                userallcon_ids.AddRange(roles.Select(p => p.Con_Id));
            }
            //获取用户所属的岗位
            var postservice = new BAS_PostService(irepositorypost,
                irepositoryuser, irepositoryudp, irepositoryidentitycontainer);
            var userposts = postservice.GetPostsByUserNo(no);
            userallcon_ids.AddRange(userposts.Select(p => p.Con_Id));
            //获取岗位所属的角色
            foreach (var post in userposts)
            {
                var roles = roleservice.GetRoleByPostName(post.Name);
                userallcon_ids.AddRange(roles.Select(p => p.Con_Id));
            }

            return userallcon_ids;
        }
    }
}
