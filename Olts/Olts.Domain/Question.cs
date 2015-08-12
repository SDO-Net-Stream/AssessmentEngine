using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Olts.Domain.Enums;

namespace Olts.Domain
{
    [DataContract]
    public class Question
    {
        [IgnoreDataMember]
        public Int32 Id { get; set; }

        public virtual Survey Survey { get; set; }
        public virtual List<OfferedAnswer> OfferedAnswers { get; set; } 
        
        public String Text { get; set; }
        public QuestionType QuestionType { get; set; }

        public override String ToString()
        {
            return String.Format("{{ Text: '{0}', QuestionType: '{1}', Survey: '{2}' }}", Text, QuestionType, Survey.Name);
        }
    }
}
