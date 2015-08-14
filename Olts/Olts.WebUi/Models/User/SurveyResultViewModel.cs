using System;
using System.Collections.Generic;

namespace Olts.WebUi.Models.User
{
    public sealed class SurveyResultViewModel
    {
        public Int32 SurveyId { get; set; }

        public List<AnswerViewModel> Answers { get; set; } 
    }

    public sealed class AnswerViewModel
    {
        public Int32 QuestionId { get; set; }

        public List<Int32> OfferedAnswers { get; set; } 

        public String OtherText { get; set; }
    }
}