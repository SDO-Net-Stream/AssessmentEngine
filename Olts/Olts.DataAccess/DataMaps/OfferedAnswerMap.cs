using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Olts.Domain;

namespace Olts.DataAccess.DataMaps
{
    internal sealed class OfferedAnswerMap : EntityTypeConfiguration<OfferedAnswer>
    {
        public OfferedAnswerMap()
        {
            ToTable("OfferedAnswers");
            HasKey(offeredAnswer => offeredAnswer.Id);
            Property(offeredAnswer => offeredAnswer.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(question => question.AnswerText).IsRequired();
        }
    }
}
