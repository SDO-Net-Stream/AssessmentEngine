using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Olts.Domain
{
    [DataContract]
    public class User
    {
        [IgnoreDataMember]
        public Int32 Id { get; set; }

        public virtual List<Answer> Answers { get; set; }
        public virtual List<Survey> Surveys { get; set; } 

        public String Name { get; set; }
        
        public override String ToString()
        {
            return Name;
        }
    }
}
