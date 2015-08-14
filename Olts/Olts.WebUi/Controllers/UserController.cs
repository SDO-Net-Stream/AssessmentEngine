using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Olts.Domain;
using Olts.WebUi.Controllers.Base;
using Olts.WebUi.Models.User;
using WebMatrix.WebData;

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
            var viewModel = new SurveyViewModel { SurveyId = id };
            return View(viewModel);
        }

        #endregion

        #region POST

        [HttpPost]
        public JsonResult Survey(SurveyResultViewModel viewModel)
        {
            Int32 userId = WebSecurity.CurrentUserId;
            foreach (AnswerViewModel answerViewModel in viewModel.Answers)
            {
                var answer = new Answer
                {
                    User = Context.Users.Find(userId),
                    Survey = Context.Surveys.Find(viewModel.SurveyId),
                    Question = Context.Questions.Find(answerViewModel.QuestionId),
                    OtherText = answerViewModel.OtherText
                };
                if (answerViewModel.OfferedAnswers != null && answerViewModel.OfferedAnswers.Any())
                {
                    answer.AnswersOfferedAnswers = new List<AnswerOfferedAnswer>(answerViewModel.OfferedAnswers.Count);
                    answer.AnswersOfferedAnswers.AddRange(answerViewModel.OfferedAnswers.Select(id => new AnswerOfferedAnswer { OfferedAnswerId = id }));
                }
                Context.Answers.Add(answer);
                Context.SaveChanges();
            }

            return Json(Url.Action("Surveys"));
        }

        #endregion
    }
}
