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
            userappservice.CreateUser("10", "曹剑", "13458629365", "pass");
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
    }
}
