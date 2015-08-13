using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Olts.DataAccess;
using Olts.Domain;

namespace Olts.WebUi.Controllers
{
    public class UserController : Controller
    {
        #region GET

        public ActionResult Surveys()
        {
            IEnumerable<Survey> viewModel;
            using (var context = new OltsContext())
            {
                viewModel = context.Surveys.ToList();
            }
            return View(viewModel);
        }

        public ActionResult Survey(Int32 id)
        {
            return View(new Survey());
        }

        #endregion

        #region POST

        #endregion
    }
}
