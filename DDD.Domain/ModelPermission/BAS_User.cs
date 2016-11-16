using DDD.Domain.Model;
using DDD.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain
{
    public partial class BAS_User:AggreateRoot
    {
        private IRepository<BAS_User> _irepository;

        public BAS_User(IRepository<BAS_User> irepository)
        {
            _irepository = irepository;
        }

        /// <summary>
        /// 在仓储中创建用户对象
        /// </summary>
        /// <param name="no"></param>
        /// <param name="name"></param>
        /// <param name="mobile"></param>
        /// <param name="con_id"></param>
        /// <param name="password"></param>
        public void CreateUser(string no, string name, string mobile, Guid con_id, string password)
        {
            BAS_User user = new BAS_User();
            user.Id = base.Id;
            user.No = no;
            user.Name = name;
            user.Mobile = mobile;
            user.Con_Id = con_id;
            var userlogin = new BAS_UserLogin(password);
            user.BAS_UserLogin = userlogin;
            _irepository.Create(user);
        }

        /// <summary>
        /// 根据用户NO返回用户对象
        /// </summary>
        /// <param name="no"></param>
        /// <returns></returns>
        public BAS_User GetUserByNo(string no)
        {
            return _irepository.GetByCondition(p => p.No == no, p => true).SingleOrDefault();
        }

        /// <summary>
        /// 用户登录验证
        /// </summary>
        /// <param name="no"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool LoginVerify(string no, string password)
        {
            return _irepository.GetByCondition(p => p.No == no && p.BAS_UserLogin.Password == password, p => true).Count == 1;
        }
    }
}
