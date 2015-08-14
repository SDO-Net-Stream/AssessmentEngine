using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Olts.DataAccess;
using Olts.Domain;

namespace Olts.WebUi.Models.User
{
    public sealed class SurveyViewModel
    {
        public Int32 SurveyId { get; set; }

        public Survey Survey
        {
            get
            {
                if (_survey == null)
                {
                    using (var context = new OltsContext())
                    {
                        _survey = context.Surveys
                            .Include(s => s.Questions)
                            .Include("Questions.OfferedAnswers")
                            .Single(s => s.Id == SurveyId);
                    }
                }
                return _survey;
            }
        }

        public List<Answer> Answers { get; set; }

        private Survey _survey;
    }
}