using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Olts.DataAccess;

namespace Olts.WebUi.Models.Admin
{
    public sealed class AdminViewModel
    {
        [StringLength(256)]
        public String UserName { get; set; }

        public String Role { get; set; }

        public IEnumerable<String> Roles
        {
            get { return _roles ?? (_roles = new List<String>(1) { AllRoles }.Concat(System.Web.Security.Roles.GetAllRoles())); }
        }

        public IEnumerable<UserViewModel> Users
        {
            get
            {
                IEnumerable<UserViewModel> users;
                using (var context = new OltsContext())
                {
                    IQueryable<Domain.User> contextUsers = context.Users.AsQueryable();
                    if (!String.IsNullOrEmpty(UserName))
                    {
                        contextUsers = contextUsers.Where(user => user.Name.Contains(UserName));
                    }
                    users = (!String.IsNullOrEmpty(Role) && Role != AllRoles ? 
                        contextUsers.AsEnumerable().Where(user => System.Web.Security.Roles.IsUserInRole(user.Name, Role)) : 
                        contextUsers.AsEnumerable())
                    .Select(user => new UserViewModel(user)).ToList();
                }
                return users;
            }
        }
        
        private IEnumerable<String> _roles;
        private const String AllRoles = "All";
    }
}