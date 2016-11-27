using DDD.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.DomainService
{
    public class BAS_ObjectSetService
    {
        private IRepository<BAS_ObjectSet> irepositoryobjectset;
        private IRepository<BAS_Object> irepositoryobject;
        private IRepository<BAS_ObjectContainer> irepositoryobjectcontainer;
        private IRepository<BAS_OOSet> irepositoryooset;

        BAS_ObjectSet bas_objectset;
        BAS_OOSet bas_ooset;
        BAS_OOSetService bas_oosetservice;
        public BAS_ObjectSetService(IRepository<BAS_ObjectSet> irepositoryobjectset,
        IRepository<BAS_Object> irepositoryobject,
        IRepository<BAS_ObjectContainer> irepositoryobjectcontainer,
        IRepository<BAS_OOSet> irepositoryooset)
        {
            this.irepositoryobject = irepositoryobject;
            this.irepositoryobjectset = irepositoryobjectset;
            this.irepositoryobjectcontainer = irepositoryobjectcontainer;
            this.irepositoryooset = irepositoryooset;
            bas_objectset = new BAS_ObjectSet(irepositoryobjectset);
            bas_ooset = new BAS_OOSet(irepositoryooset);
            bas_oosetservice = new BAS_OOSetService(irepositoryobject, irepositoryobjectset, irepositoryooset);
        }
        /// <summary>
        /// 创建对象集
        /// </summary>
        /// <param name="name"></param>
        /// <param name="description"></param>
        public void CreateObjectSet(string name,string description)
        {
            var obj_id = Guid.NewGuid();
            bas_objectset.CreateObjectSet(name, description, obj_id);

            var objectcontainer = new BAS_ObjectContainer(irepositoryobjectcontainer);
            objectcontainer.CreateObjectContainer(obj_id);
        }

        /// <summary>
        /// 添加多个对象到对象集
        /// </summary>
        /// <param name="objectnames"></param>
        /// <param name="objectsetname"></param>
        public void AddObjectsToObjectSet(List<string> objectnames,string objectsetname)
        {
            var objectset = bas_objectset.GetObjectSetByName(objectsetname);

            var objects = new List<BAS_Object>();

            foreach(var objectname in objectnames)
            {
                var bas_object = new BAS_Object(irepositoryobject);
                var obj = bas_object.GetObjectByName(objectname);
                objects.Add(obj);
            }
            bas_ooset.CreateBAS_OOSet(objects, objectset);
        }

        /// <summary>
        /// 根据对象名获取所属对象集
        /// </summary>
        /// <param name="objectname"></param>
        /// <returns></returns>
        public List<BAS_ObjectSet> GetObjectSetByObjectName(string objectname)
        {
            var oosets = bas_oosetservice.GetoosetByObjectName(objectname);
            var objectsets = new List<BAS_ObjectSet>();
            foreach(var ooset in oosets)
            {
                var objectset =
                    irepositoryobjectset.GetByCondition(p => p.Id == ooset.BAS_ObjectSet.Id,
                    p => true).SingleOrDefault();
                objectsets.Add(objectset);
            }

            return objectsets;
        }
        /// <summary>
        /// 根据对象CODE获取所属对象集
        /// </summary>
        /// <param name="objectcode"></param>
        /// <returns></returns>
        public List<BAS_ObjectSet> GetObjectSetByObjectCode(string objectcode)
        {
            var oosets = bas_oosetservice.GetoosetByObjectCode(objectcode);
            var objectsets = new List<BAS_ObjectSet>();
            foreach (var ooset in oosets)
            {
                var objectset =
                    irepositoryobjectset.GetByCondition(p => p.Id == ooset.BAS_ObjectSet.Id,
                    p => true).SingleOrDefault();
                objectsets.Add(objectset);
            }

            return objectsets;
        }

        /// <summary>
        /// 判断某个对象是否在某个对象集中
        /// </summary>
        /// <param name="objectname"></param>
        /// <param name="objectsetname"></param>
        /// <returns></returns>
        public bool IsObjectSetContainObject(string objectname,string objectsetname)
        {
            return GetObjectSetByObjectName(objectname).Contains
                (bas_objectset.GetObjectSetByName(objectsetname));
        }
    }
}
