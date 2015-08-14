using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using Olts.WebUi.Controllers.Base;
using Olts.WebUi.Models.Admin;
using WebMatrix.WebData;

namespace Olts.WebUi.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AdminController : OltsControllerBase
    {
        #region GET

        [HttpGet]
        public ActionResult Users()
        {
            var viewModel = new AdminViewModel();
            return View(viewModel);
        }
        
        #endregion

        #region POST

        [HttpPost]
        public ActionResult Users(AdminViewModel viewModel)
        {
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(UserViewModel user)
        {
            return new EmptyResult();   
        }
        
        [HttpPost]
        public ActionResult Update(UserViewModel user)
        {
            return new EmptyResult();
        }

        [HttpGet]
        public ActionResult Delete(String name)
        {
            var roles = Roles.GetRolesForUser(name);
            if (roles.Any())
            {
                Roles.RemoveUserFromRoles(name, roles);
            }
            var membershipProvider = (SimpleMembershipProvider) Membership.Provider;
            var isAccountDeleted = membershipProvider.DeleteAccount(name);
            var isUserDeleted = membershipProvider.DeleteUser(name, true);
            // TODO: Show appropriate message in case if user or account wasn't deleted successfully

            return RedirectToAction("Users");
        }

        #endregion
    }
}
