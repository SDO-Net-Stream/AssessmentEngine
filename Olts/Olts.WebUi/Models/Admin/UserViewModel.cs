using System;
using System.Collections.Generic;
using Olts.Domain;

namespace Olts.WebUi.Models.Admin
{
    public sealed class UserViewModel
    {
        public UserViewModel()
        {
            //
        }

        public UserViewModel(User user)
        {
            Name = user.Name;
            Roles = System.Web.Security.Roles.GetRolesForUser(user.Name);
        }

        public String Name { get; set; }

        public IEnumerable<String> Roles { get; set; }
    }
}