using DDD.Domain.Aggreate;
using DDD.Domain.Repository;
using DDD.Infrastructure;
using DDD.Infrastructure.LamdaFilterConvert;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.DomainService
{
    public class BAS_PermissionAssignService<TAggreateRoot> where TAggreateRoot : class,
        IAggreateRoot
    {
        private IRepository<BAS_PermissionAssign> irepositorypermissionassign;
        private IRepository<BAS_IdentityContainer> irepositoryidentitycontainer;
        private IRepository<BAS_ObjectContainer> irepositoryobjectcontainer;
        private IRepository<BAS_PermissionContainer> irepositorypermissioncontainer;

        private IRepository<BAS_User> irepositoryuser;
        private IRepository<BAS_Department> irepositorydepartment;
        private IRepository<BAS_Post> irepositorypost;
        private IRepository<BAS_Role> irepositoryrole;

        private IRepository<BAS_Object> irepositoryobject;
        private IRepository<BAS_ObjectSet> irepositoryobjectset;
        private IRepository<BAS_Permission> irepositorypermission;
        private IRepository<BAS_PermissionSet> irepositorypermissionset;

        private IRepository<BAS_OOSet> irepositoryooset;

        public BAS_PermissionAssignService(
            IRepository<BAS_PermissionAssign> irepositorypermissionassign,
            IRepository<BAS_IdentityContainer> irepositoryidentitycontainer,
            IRepository<BAS_ObjectContainer> irepositoryobjectcontainer,
            IRepository<BAS_PermissionContainer> irepositorypermissioncontainer,

            IRepository<BAS_User> irepositoryuser,
            IRepository<BAS_Department> irepositorydepartment,
            IRepository<BAS_Post> irepositorypost,
            IRepository<BAS_Role> irepositoryrole,

            IRepository<BAS_Object> irepositoryobject,
            IRepository<BAS_ObjectSet> irepositoryobjectset,
            IRepository<BAS_Permission> irepositorypermission,
            IRepository<BAS_PermissionSet> irepositorypermissionset,
            IRepository<BAS_OOSet> irepositoryooset)
        {
            this.irepositorydepartment = irepositorydepartment;
            this.irepositoryidentitycontainer = irepositoryidentitycontainer;
            this.irepositoryobject = irepositoryobject;
            this.irepositoryobjectcontainer = irepositoryobjectcontainer;
            this.irepositoryobjectset = irepositoryobjectset;
            this.irepositoryooset = irepositoryooset;
            this.irepositorypermission = irepositorypermission;
            this.irepositorypermissionassign = irepositorypermissionassign;
            this.irepositorypermissioncontainer = irepositorypermissioncontainer;
            this.irepositorypermissionset = irepositorypermissionset;
            this.irepositorypost = irepositorypost;
            this.irepositoryrole = irepositoryrole;
            this.irepositoryuser = irepositoryuser;
        }

        public void CreatePermissionAssgin(string userno, string departmentname,
            string postname, string rolename, string objectname, string objectsetname,
            string permissionname, string permissionsetname)
        {
            BAS_IdentityContainer identitycontainer = null;
            BAS_ObjectContainer objectcontainer = null;
            BAS_PermissionContainer permissioncontainer = null;

            if (!string.IsNullOrEmpty(userno))
            {
                var conid = irepositoryuser.GetByCondition(p => p.No == userno, p => true).SingleOrDefault().Con_Id;
                identitycontainer =
                    irepositoryidentitycontainer.GetByCondition(p => p.Id == conid, p => true).SingleOrDefault();
            }
            if (!string.IsNullOrEmpty(departmentname))
            {
                var conid = irepositorydepartment.GetByCondition(p => p.Name == departmentname, p => true).SingleOrDefault().Con_Id;
                identitycontainer =
                    irepositoryidentitycontainer.GetByCondition(p => p.Id == conid, p => true).SingleOrDefault();
            }
            if (!string.IsNullOrEmpty(postname))
            {
                var conid = irepositorypost.GetByCondition(p => p.Name == postname, p => true).SingleOrDefault().Con_Id;
                identitycontainer =
                    irepositoryidentitycontainer.GetByCondition(p => p.Id == conid, p => true).SingleOrDefault();
            }

            if (!string.IsNullOrEmpty(rolename))
            {
                var conid = irepositoryrole.GetByCondition(p => p.Name == rolename, p => true).SingleOrDefault().Con_Id;
                identitycontainer =
                    irepositoryidentitycontainer.GetByCondition(p => p.Id == conid, p => true).SingleOrDefault();
            }

            if (!string.IsNullOrEmpty(objectname))
            {
                var objid = irepositoryobject.GetByCondition(p => p.Name == objectname, p => true).SingleOrDefault().Obj_Id;
                objectcontainer =
                    irepositoryobjectcontainer.GetByCondition(p => p.Id == objid, p => true).SingleOrDefault();
            }

            if (!string.IsNullOrEmpty(objectsetname))
            {
                var objid = irepositoryobjectset.GetByCondition(p => p.Name == objectsetname, p => true).SingleOrDefault().Obj_Id;
                objectcontainer =
                    irepositoryobjectcontainer.GetByCondition(p => p.Id == objid, p => true).SingleOrDefault();
            }

            if (!string.IsNullOrEmpty(permissionname))
            {
                var perid = irepositorypermission.GetByCondition(p => p.Name == permissionname, p => true).SingleOrDefault().Per_Id;
                permissioncontainer =
                    irepositorypermissioncontainer.GetByCondition(p => p.Id == perid, p => true).SingleOrDefault();
            }

            if (!string.IsNullOrEmpty(permissionsetname))
            {
                var perid = irepositorypermissionset.GetByCondition(p => p.Name == permissionsetname, p => true).SingleOrDefault().Per_Id;
                permissioncontainer =
                    irepositorypermissioncontainer.GetByCondition(p => p.Id == perid, p => true).SingleOrDefault();
            }

            var permissionassign = new BAS_PermissionAssign(irepositorypermissionassign);
            permissionassign.CreatePermissionAssign(identitycontainer, objectcontainer, permissioncontainer);
        }

        /// <summary>
        /// 通过凭据容器ID与对象容器ID获取对应的权限容器ID
        /// </summary>
        /// <param name="obj_id"></param>
        /// <param name="con_id"></param>
        /// <returns></returns>
        private List<Guid> GetPer_idByObjAndIdentityId(Guid obj_id, Guid con_id)
        {
            return irepositorypermissionassign.GetByCondition(p => p.BAS_ObjectContainer.Id == obj_id
            && p.BAS_IdentityContainer.Id == con_id, p => true).Select(p => p.BAS_PermissionContainer.Id).ToList();
        }

        /// <summary>
        /// 根据凭据容器ID与对象容器ID和操作获取对应的所有权限
        /// </summary>
        /// <param name="obj_id"></param>
        /// <param name="con_id"></param>
        /// <param name="operation"></param>
        /// <returns></returns>
        private List<BAS_Permission> GetPermissionRuleByObjAndIdentityId(Guid obj_id, Guid con_id, OperationType operation)
        {
            var perids = GetPer_idByObjAndIdentityId(obj_id, con_id);
            var permissions = new List<BAS_Permission>();
            foreach (var perid in perids)
            {
                var permission =
                    irepositorypermission.GetByCondition(p => p.Per_Id == perid && p.Operation == operation, p => true).SingleOrDefault();
                permissions.Add(permission);
            }
            return permissions;
        }

        /// <summary>
        /// 将权限中的Value装换成Lamda表达式
        /// </summary>
        /// <param name="perlist"></param>
        /// <returns></returns>
        private Expression<Func<TAggreateRoot, bool>> GetExpressionByPermisson(List<BAS_Permission> perlist)
        {
            if (perlist.Count == 1)
            {
                List<Conditions> conditions = Utils.JsonDeserialize<List<Conditions>>(perlist[0].CodeValue);
                return WhereLamdaConverter.Where<TAggreateRoot>(conditions);
            }
            if (perlist.Count > 1)
            {
                var express = WhereLamdaConverter.Where<TAggreateRoot>
                    (Utils.JsonDeserialize<List<Conditions>>(perlist[0].CodeValue));
                for (var i = 1; i < perlist.Count; i++)
                {
                    express.Or(WhereLamdaConverter.Where<TAggreateRoot>
                    (Utils.JsonDeserialize<List<Conditions>>(perlist[i].CodeValue)));
                }
                return express;
            }

            return p => true;
        }

        /// <summary>
        /// 将[ProductName,UnitPrice]转换成 new(ProductName,UnitPrice)
        /// </summary>
        /// <param name="perlist"></param>
        /// <returns></returns>
        private string GetSelectByPermission(List<BAS_Permission> perlist)
        {
            if (perlist.Count == 1)
            {
                if (!string.IsNullOrEmpty(perlist[0].CodeProperty))
                {
                    var selectstring = "New" + perlist[0].CodeProperty.Replace("[", "(").Replace("]", ")");
                    return selectstring;
                }
                return null;
            }
            if (perlist.Count > 1)
            {
                var start = perlist[0].CodeProperty.Substring(1, perlist[0].CodeProperty.Length - 2).Split(',');
                if (start.Any())
                {
                    for (int i = 1; i < perlist.Count; i++)
                    {
                        var start1 = perlist[i].CodeProperty;
                        string[] startnew = start1.Substring(1, start1.Length - 2).Split(',');
                        start = start.Union(startnew).ToArray();
                    }
                    var starts = string.Join(",", start);
                    var selectstring = "New" + "(" + starts + ")";
                    return selectstring;
                }
                return null;
            }
            return null;
        }

        public Expression<Func<TAggreateRoot, bool>> GetPermissionLamda(out string selector, OperationType operation)
        {
            var objectfullname = typeof(TAggreateRoot).ToString();
            var objectcode = objectfullname.Substring(objectfullname.LastIndexOf(".") + 1);
            var obj_ids = new List<Guid>();
            var obj = new BAS_ObjectService(irepositoryobject, irepositoryobjectcontainer)
                .GetObjectByCode(objectcode);
            if (obj != null)
            {
                var objisexists = new BAS_PermissionAssign(irepositorypermissionassign)
                    .GetPermissionAssignObjectIsExists(obj.Obj_Id);
                if (objisexists)
                {
                    obj_ids.Add(obj.Obj_Id);
                }
            }

            var objsets = new BAS_ObjectSetService(irepositoryobjectset, irepositoryobject,
                irepositoryobjectcontainer, irepositoryooset)
                .GetObjectSetByObjectCode(objectcode);
            if (objsets != null)
            {
                foreach (var objset in objsets)
                {
                    var objisexists = new BAS_PermissionAssign(irepositorypermissionassign)
                        .GetPermissionAssignObjectIsExists(objset.Obj_Id);
                    if (objisexists)
                    {
                        obj_ids.Add(objset.Obj_Id);
                    }
                }
            }

            if (obj_ids.Count < 1)
            {
                selector = null;
                return p => true;
            }

            var permissions = new List<BAS_Permission>();

            var con_idstrings = SessionHelper.Gets("UserConId");
            var con_ids = new List<Guid>();
            for (int i = 0; i < con_idstrings.Count(); i++)
            {
                con_ids.Add(Guid.Parse(con_idstrings[i]));
            }

            foreach (var obj_id in obj_ids)
            {
                foreach (var con_id in con_ids)
                {
                    var permissionlist = GetPermissionRuleByObjAndIdentityId(obj_id, con_id, operation);
                    permissions.AddRange(permissionlist);
                }
            }

            if (permissions.Count < 1)
            {
                selector = null;
                return p => true;
            }

            selector = GetSelectByPermission(permissions);
            return GetExpressionByPermisson(permissions);

        }
    }
}
