using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Olts.Domain;

namespace Olts.DataAccess.DataMaps
{
    internal sealed class SurveyMap : EntityTypeConfiguration<Survey>
    {
        public SurveyMap()
        {
            ToTable("Surveys");
            HasKey(survey => survey.Id);
            Property(survey => survey.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(survey => survey.Name).IsRequired().HasMaxLength(64);
            Property(survey => survey.Description).IsOptional().HasMaxLength(256);
            HasMany(survey => survey.Questions).WithRequired(question => question.Survey);
        }
    }
}
