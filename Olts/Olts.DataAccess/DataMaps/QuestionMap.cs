using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Olts.Domain;

namespace Olts.DataAccess.DataMaps
{
    internal sealed class QuestionMap : EntityTypeConfiguration<Question>
    {
        public QuestionMap()
        {
            ToTable("Questions");
            HasKey(question => question.Id);
            Property(question => question.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(question => question.Text).IsRequired();
            Property(question => question.QuestionType).IsRequired();
            HasMany(question => question.OfferedAnswers).WithRequired(offeredAnswer => offeredAnswer.Question);
        }
    }
}
