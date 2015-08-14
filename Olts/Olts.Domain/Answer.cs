using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Olts.Domain
{
    [DataContract]
    public class Answer
    {
        [IgnoreDataMember]
        public Int32 Id { get; set; }

        public virtual Survey Survey { get; set; }
        public virtual Question Question { get; set; }
        public virtual User User { get; set; }
        public virtual List<AnswerOfferedAnswer> AnswersOfferedAnswers { get; set; }

        public String OtherText { get; set; }
    }
}
