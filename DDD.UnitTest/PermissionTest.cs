using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DDD.Application;

namespace DDD.UnitTest
{
    [TestClass]
    public class PermissionTest
    {
        [TestMethod]
        public void CreateUser()
        {
            UserAppService userappservice =
                new UserAppService();
            userappservice.CreateUser("10", "Hyh", "12345678901", "pass");
            Assert.IsNotNull(userappservice.GetUserByNo("10"));
        }

        [TestMethod]
        public void CreateDepartment()
        {
            DepartmentAppService departmentservice =
                new DepartmentAppService();
            departmentservice.CreateDepartment("财务中心", "进行财务核算与管理");
            Assert.IsNotNull(departmentservice.GetDepartmentByName("财务中心"));
        }

        [TestMethod]
        public void CreatePost()
        {
            PostAppService postservice = new PostAppService();
            postservice.CreatePost("高级会计师", "高级会计师");
            Assert.IsNotNull(postservice.GetPostByName("高级会计师"));
        }

        [TestMethod]
        public void CreateDepartmentPostToUser()
        {
            UserAppService userservice = new UserAppService();
            userservice.CreateDepartmentPostToUser("10", "财务中心", "高级会计师", true);
            Assert.IsNotNull(userservice.GetUDPByDepartmentUserPost("财务中心", "10", "高级会计师"));
        }

        [TestMethod]
        public void CreateRole()
        {
            RoleAppService roleservice =
                new RoleAppService();
            roleservice.CreateRole("角色1", "具有某些权限的角色");
            Assert.IsNotNull(roleservice.GetRoleByName("角色1"));
        }

        [TestMethod]
        public void AddUserToRole()
        {
            RoleAppService roleservice = new RoleAppService();
            string[] usernos = new string[1];
            usernos[0] = "10";
            roleservice.AddUserToRole(usernos, "角色1");
            Assert.IsTrue(roleservice.IsRoleContainUser("10", "角色1"));
        }

        [TestMethod]
        public void AddDepartmentToRole()
        {
            RoleAppService roleservice = new RoleAppService();
            string[] departmentnames = new string[1];
            departmentnames[0] = "财务中心";
            roleservice.AddDepartmentToRole(departmentnames, "角色1");
            Assert.IsTrue(roleservice.IsRoleContainDepartment("财务中心", "角色1"));
        }

        [TestMethod]
        public void AddPostToRole()
        {
            RoleAppService roleservice = new RoleAppService();
            string[] postnames = new string[1];
            postnames[0] = "高级会计师";
            roleservice.AddPostToRole(postnames, "角色1");
            Assert.IsTrue(roleservice.IsRoleContainPost("高级会计师", "角色1"));
        }

        [TestMethod]
        public void AddObject()
        {
            ObjectAppService objectservice = new ObjectAppService();
            objectservice.CreateObject("产品对象", "标识产品对象", "Product");
            Assert.IsNotNull(objectservice.GetObjectByName("产品对象"));
        }

        [TestMethod]
        public void AddObjectSet()
        {
            ObjectSetAppService objectsetservice = new ObjectSetAppService();
            objectsetservice.CreateobjectSet("订单对象集", "包含订单业务所有的对象");
            Assert.IsNotNull(objectsetservice.GetObjectSetByName("订单对象集"));
        }

        [TestMethod]
        public void AddObjectToObjectSet()
        {
            ObjectSetAppService objectsetservice =
                new ObjectSetAppService();
            string[] objects = new string[1];
            objects[0] = "产品对象";
            objectsetservice.AddObjectToObjectSet(objects, "订单对象集");
            Assert.IsTrue(objectsetservice.IsObjectSetContainObject("产品对象", "订单对象集"));
        }

        [TestMethod]
        public void AddPermission()
        {
            PermissionAppService permissionservice =
                new PermissionAppService();
            permissionservice.CreatePermission("产品信息权限", "代表一个产品权限信息", "[ProductName,UnitPrice]",
                "[{\"Field\":\"UnitPrice\",\"Operator\":\"Equal\",\"Value\":\"10\",\"Relation\":\"And\"}]",
                Domain.OperationType.Read);
            Assert.IsNotNull(permissionservice.GetPermissionByName("产品信息权限"));
        }

        [TestMethod]
        public void AddPermissionSet()
        {
            PermissionSetAppService permissionsetservice =
                new PermissionSetAppService();
            permissionsetservice.CreatePermissionSet("普通用户权限集", "代表普通用户的一个权限集");
            Assert.IsNotNull(permissionsetservice.GetPermissionSetByName("普通用户权限集"));
        }

        [TestMethod]
        public void AddPermissionToPermissionSet()
        {
            PermissionSetAppService permissionsetservice =
                new PermissionSetAppService();
            string[] permissionnames = new string[1];
            permissionnames[0] = "产品信息权限";
            permissionsetservice.AddPermissionToPermissionSet(permissionnames,
                "普通用户权限集");
            Assert.IsTrue(permissionsetservice.IsPermissionSetContainpermission("产品信息权限", "普通用户权限集"));
        }
    }
}
