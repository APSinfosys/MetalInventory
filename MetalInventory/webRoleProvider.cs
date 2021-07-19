using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using InventoryDal;

namespace MetalInventory
{
    public class webRoleProvider : RoleProvider
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
            using(var context = new MetalInventoryEntities())
            {

                //                select CV.CommonValue
                //from[dbo].[Master_UserMaster] UM
                //inner join[dbo].[Master_RoleMaster] RM on Rm.UserId = UM.UserId
                //inner join[dbo].[Master_CommonValue] CV on CV.Id = RM.RoleId
                //where[UserName] = 'abhi'

                var result = (from User in context.Master_UserMaster
                              join Role in context.Master_RoleMaster on User.UserId equals Role.UserId
                              join CV in context.Master_CommonValue on Role.RoleId equals CV.Id
                              where User.UserName == username
                              select CV.CommonValue).ToArray();
                return result;
            }
           // throw new NotImplementedException();
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