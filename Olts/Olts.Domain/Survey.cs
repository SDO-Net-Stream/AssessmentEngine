using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Olts.Domain
{
    [DataContract]
    public class Survey
    {
        [IgnoreDataMember]
        public Int32 Id { get; set; }

        public virtual List<Question> Questions { get; set; } 
        public virtual User Owner { get; set; }
        
        public String Name { get; set; }
        public String Description { get; set; }

        public override String ToString()
        {
            return String.Format("{{ Name: '{0}', Description: '{1}', Owner: '{2}' }}", Name, Description, Owner.Name);
        }
    }
}
