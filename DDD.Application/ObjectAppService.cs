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
    public class ObjectAppService
    {
        IRepositoryContext context = ServiceLocator.Instance.GetService(typeof(IRepositoryContext))
            as IRepositoryContext;
        IRepository<BAS_Object> objectrepository = ServiceLocator.Instance.GetService(typeof(IRepository<BAS_Object>))
            as IRepository<BAS_Object>;
        IRepository<BAS_ObjectContainer> objectcontainerrepository = ServiceLocator.Instance.GetService(typeof(IRepository<BAS_ObjectContainer>))
            as IRepository<BAS_ObjectContainer>;

        BAS_ObjectService BAS_Objectservice;
        BAS_Object bas_object;

        public ObjectAppService()
        {
            BAS_Objectservice = new BAS_ObjectService(objectrepository,
                objectcontainerrepository);
            bas_object = new BAS_Object(objectrepository);
        }

        /// <summary>
        /// 对象创建
        /// </summary>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="code"></param>
        public void CreateObject(string name,string description,string code)
        {
            BAS_Objectservice.CreateObject(name, description, code);
            context.Commit();
        }

        /// <summary>
        /// 根据对象名获取对象
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public BAS_Object GetObjectByName(string name)
        {
            return bas_object.GetObjectByName(name);
        }
    }
}
