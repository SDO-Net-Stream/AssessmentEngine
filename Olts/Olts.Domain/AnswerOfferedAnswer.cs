using System;

namespace Olts.Domain
{
    public class AnswerOfferedAnswer
    {
        public Int64 Id { get; set; }

        public Int32 AnswerId { get; set; }

        public Int32 OfferedAnswerId { get; set; }

        public virtual Answer Answer { get; set; }

        public virtual OfferedAnswer OfferedAnswer { get; set; } 
    }
}
