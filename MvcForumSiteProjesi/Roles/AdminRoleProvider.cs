using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace MvcForumSiteProjesi.Roles
{
    public class AdminRoleProvider : RoleProvider
    {
        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            //Context context = new Context();
            //var userInfo = context.Admins.FirstOrDefault(x => x.AdminUserName == username);
            //return new string[] { userInfo.AdminRole };
            Context context = new Context();
            var userInfo = context.Admins.FirstOrDefault(x => x.AdminUserName == username);
            var resultWriter = context.Writers.FirstOrDefault(x => x.WriterMail == username);

            if (userInfo != null)
            {
                return new string[] { userInfo.AdminRole };
            }
            else if (resultWriter != null)
            {
                return new string[] { resultWriter.WriterRole };
            }
            return new string[] { };
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}