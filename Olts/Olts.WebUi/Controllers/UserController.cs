using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Olts.Domain;
using Olts.WebUi.Controllers.Base;
using Olts.WebUi.Models.User;

namespace Olts.WebUi.Controllers
{
    public class UserController : OltsControllerBase
    {
        #region GET

        public ActionResult Surveys()
        {
            IEnumerable<Survey> viewModel = Context.Surveys.ToList();
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Survey(Int32 id)
        {
            var viewModel = new SurveyViewModel { Id = id };
            return View(viewModel);
        }

        #endregion

        #region POST

        [HttpPost]
        public ActionResult Survey(SurveyViewModel viewModel)
        {
            return View(viewModel);
        }

        #endregion
    }
}
