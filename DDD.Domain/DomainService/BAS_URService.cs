using DDD.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.DomainService
{
    public class BAS_URService
    {
        private IRepository<BAS_User> irepositoryuser;
        private IRepository<BAS_Role> irepositoryrole;
        private IRepository<BAS_UR> irepositoryur;
        BAS_UR bas_ur;
        public BAS_URService(IRepository<BAS_User> irepositoryuser,
        IRepository<BAS_Role> irepositoryrole,
        IRepository<BAS_UR> irepositoryur)
        {
            this.irepositoryuser = irepositoryuser;
            this.irepositoryrole = irepositoryrole;
            this.irepositoryur = irepositoryur;
            bas_ur = new BAS_UR(irepositoryur);
        }

        /// <summary>
        /// 将多个用户添加到角色
        /// </summary>
        /// <param name="usernos"></param>
        /// <param name="rolename"></param>
        public void CreateBAS_UR(string[] usernos,string rolename)
        {
            var listuser = new List<BAS_User>();
            for(int i=0;i<usernos.Length;i++)
            {
                var user = irepositoryuser.GetByCondition(p => p.No == usernos[i], p => true)
                    .SingleOrDefault();
                listuser.Add(user);
            }

            var role = irepositoryrole.GetByCondition(p => p.Name == rolename, p => true).SingleOrDefault();

            bas_ur.CreateBAS_UR(listuser, role);

        }

        /// <summary>
        /// 根据用户No获取UR
        /// </summary>
        /// <param name="userno"></param>
        /// <returns></returns>
        public List<BAS_UR> GetURSByUserNo(string userno)
        {
            var user = irepositoryuser.GetByCondition(p => p.No == userno, p => true).SingleOrDefault();
            return bas_ur.GetURSByUser(user);
        }

        /// <summary>
        /// 根据角色名获取UR
        /// </summary>
        /// <param name="rolename"></param>
        /// <returns></returns>
        public List<BAS_UR> GetURsByRoleName(string rolename)
        {
            var role = irepositoryrole.GetByCondition(p => p.Name == rolename, p => true)
                .SingleOrDefault();
            return bas_ur.GetURSByRole(role);
        }
    }
}
