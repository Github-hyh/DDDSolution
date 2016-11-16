using DDD.Domain.Model;
using DDD.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain
{
    public partial class BAS_Post:AggreateRoot
    {
        private IRepository<BAS_Post> _irepository;

        public BAS_Post(IRepository<BAS_Post> irepository)
        {
            _irepository = irepository;
        }

        /// <summary>
        /// 创建岗位对象
        /// </summary>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="con_id"></param>
        public void CreatePost(string name, string description, Guid con_id)
        {
            BAS_Post post = new BAS_Post();
            post.Id = base.Id;
            post.Name = name;
            post.Description = description;
            post.Con_Id = con_id;
            _irepository.Create(post);
        }

        /// <summary>
        /// 根据岗位名返回岗位对象
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public BAS_Post GetPostByName(string name)
        {
            return _irepository.GetByCondition(p => p.Name == name, p => true).SingleOrDefault();
        }
    }
}
