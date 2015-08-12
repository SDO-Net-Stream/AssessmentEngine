using System;
using System.Runtime.Serialization;

namespace Olts.Domain
{
    [DataContract]
    public class OfferedAnswer
    {
        [IgnoreDataMember]
        public Int32 Id { get; set; }

        public virtual Question Question { get; set; }

        public String AnswerText { get; set; }
        
        public override String ToString()
        {
            return String.Format("{{ AnswerText: '{0}', Question: '{1}' }}", AnswerText, Question.Text);
        }
    }
}
