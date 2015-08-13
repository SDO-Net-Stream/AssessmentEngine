using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Olts.DataAccess;
using Olts.Domain;

namespace Olts.WebUi.Models.Admin
{
    public sealed class AdminViewModel
    {
        [StringLength(256)]
        public String UserName { get; set; }

        public String Role { get; set; }

        public IEnumerable<String> Roles
        {
            get { return _roles ?? (_roles = System.Web.Security.Roles.GetAllRoles()); }
        }

        public IEnumerable<UserViewModel> Users
        {
            get
            {
                IEnumerable<UserViewModel> users;
                using (var context = new OltsContext())
                {
                    IQueryable<User> contextUsers = context.Users.AsQueryable();
                    if (!String.IsNullOrEmpty(UserName))
                    {
                        contextUsers = contextUsers.Where(user => user.Name.Contains(UserName));
                    }
                    if (!String.IsNullOrEmpty(Role))
                    {
                        contextUsers = contextUsers.Where(user => System.Web.Security.Roles.IsUserInRole(user.Name, Role));
                    }

                    users = contextUsers.Select(user => new UserViewModel(user));
                }
                return users;
            }
        }
        
        private String[] _roles;
    }
}