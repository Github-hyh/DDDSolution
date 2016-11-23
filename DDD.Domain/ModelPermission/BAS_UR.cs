using DDD.Domain.Model;
using DDD.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain
{
    public partial class BAS_UR:AggreateRoot
    {
        private IRepository<BAS_UR> irepository;
        public BAS_UR(IRepository<BAS_UR> irepository)
        {
            this.irepository = irepository;
        }
        public BAS_UR() { }

        /// <summary>
        /// 创建UR对象，将多个用户添加到角色中
        /// </summary>
        /// <param name="users"></param>
        /// <param name="role"></param>
        public void CreateBAS_UR(List<BAS_User> users,BAS_Role role)
        {
            foreach(var user in users)
            {
                var bas_ur = new BAS_UR();
                bas_ur.Id = base.Id;
                bas_ur.BAS_User = user;
                bas_ur.BAS_Role = role;
                irepository.Create(bas_ur);
            }
        }
        /// <summary>
        /// 根据用户对象获取对应的UR信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public List<BAS_UR> GetURSByUser(BAS_User user)
        {
            return irepository.GetByCondition(p => p.BAS_User.Id == user.Id, p => true);
        }

        public List<BAS_UR> GetURSByRole(BAS_Role role)
        {
            return irepository.GetByCondition(p => p.BAS_Role.Id == role.Id, p => true);
        }
    }
}
