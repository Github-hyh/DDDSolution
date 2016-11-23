using DDD.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.DomainService
{
    public class BAS_PRService
    {
        private IRepository<BAS_Post> irepositorypost;
        private IRepository<BAS_Role> irepositoryrole;
        private IRepository<BAS_PR> irepositorypr;

        BAS_PR bas_pr;

        public BAS_PRService(IRepository<BAS_Post> irepositorypost,
         IRepository<BAS_Role> irepositoryrole,
         IRepository<BAS_PR> irepositorypr)
        {
            this.irepositorypost = irepositorypost;
            this.irepositoryrole = irepositoryrole;
            this.irepositorypr = irepositorypr;

            bas_pr = new BAS_PR(irepositorypr);
        }

        /// <summary>
        /// 将多个岗位添加到角色中
        /// </summary>
        /// <param name="postnames"></param>
        /// <param name="rolename"></param>
        public void CreateBAS_PR(string[] postnames,string rolename)
        {
            var listpost = new List<BAS_Post>();
            for(int i=0;i<postnames.Length;i++)
            {
                var post =
                    irepositorypost.GetByCondition(p => p.Name == postnames[i], p => true)
                    .SingleOrDefault();
                listpost.Add(post);
            }

            var role = irepositoryrole.GetByCondition(p => p.Name == rolename, p => true).SingleOrDefault();
            bas_pr.CreateBAS_PR(listpost, role);
        }

        /// <summary>
        /// 根据岗位名获取PR信息
        /// </summary>
        /// <param name="postname"></param>
        /// <returns></returns>
        public List<BAS_PR> GetPRSByPostName(string postname)
        {
            var post = irepositorypost.GetByCondition(p => p.Name == postname, p => true).
                SingleOrDefault();
            return bas_pr.GetPRSByPost(post);
        }

        public List<BAS_PR> GetPRSByRoleName(string rolename)
        {
            var role = irepositoryrole.GetByCondition(p => p.Name == rolename, p => true)
                .SingleOrDefault();
            return bas_pr.GetPRSByRole(role);
        }
    }
}
