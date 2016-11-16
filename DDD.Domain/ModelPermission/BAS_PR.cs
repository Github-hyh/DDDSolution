using DDD.Domain.Model;
using DDD.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain
{
    public partial class BAS_PR:AggreateRoot
    {
        public IRepository<BAS_PR> _irepository;
        public  BAS_PR(IRepository<BAS_PR> irepository)
        {
            this._irepository = irepository;
        }

        public BAS_PR() { }

        /// <summary>
        /// 创建PR对象，将多个岗位添加到角色中
        /// </summary>
        /// <param name="posts"></param>
        /// <param name="role"></param>
        public void CreateBAS_PR(List<BAS_Post> posts,BAS_Role role)
        {
            foreach(var post in posts)
            {
                var bas_pr = new BAS_PR();
                bas_pr.Id = base.Id;
                bas_pr.BAS_Post = post;
                bas_pr.BAS_Role = role;
                _irepository.Create(bas_pr);
            }
        }

        /// <summary>
        /// 根据岗位对象获取PR信息
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        public List<BAS_PR> GetPRSByPost(BAS_Post post)
        {
            return _irepository.GetByCondition(p => p.BAS_Post.Id == post.Id, p => true);
        }

        /// <summary>
        /// 根据角色对象获取PR信息
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public List<BAS_PR> GetPRSByRole(BAS_Role role)
        {
            return _irepository.GetByCondition(p => p.BAS_Role.Id == role.Id, p => true);
        }
    }
}
