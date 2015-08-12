using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Olts.Domain;

namespace Olts.DataAccess.DataMaps
{
    internal sealed class AnswerMap : EntityTypeConfiguration<Answer>
    {
        public AnswerMap()
        {
            ToTable("Answer");
            HasKey(answer => answer.Id);
            Property(answer => answer.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(answer => answer.OtherText).IsOptional();
        }
    }
}
