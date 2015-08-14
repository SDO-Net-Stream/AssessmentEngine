using System.Data.Entity.ModelConfiguration;
using Olts.Domain;

namespace Olts.DataAccess.DataMaps
{
    public sealed class AnswerOfferedAnswerMap : EntityTypeConfiguration<AnswerOfferedAnswer>
    {
        public AnswerOfferedAnswerMap()
        {
            ToTable("AnswersOfferedAnswers");
            HasKey(answerOfferedAnswer => answerOfferedAnswer.Id);
            Property(answerOfferedAnswer => answerOfferedAnswer.AnswerId).IsRequired();
            Property(answerOfferedAnswer => answerOfferedAnswer.OfferedAnswerId).IsRequired();
        }
    }
}
