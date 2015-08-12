using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Objects;
using Olts.DataAccess.DataMaps;
using Olts.Domain;

namespace Olts.DataAccess
{
    public class OltsContext : DbContext
    {
        static OltsContext()
        {
#if DEBUG
            Database.SetInitializer(new DropCreateDatabaseAlways<OltsContext>());
#endif
        }

        public OltsContext()//String name)
            : base("Olts")
        {
            ObjectContext.ObjectMaterialized += OnObjectMaterialized;
        }

        public IDbSet<Survey> Surveys { get; set; }

        public IDbSet<User> Users { get; set; }

        public IDbSet<Question> Questions { get; set; }

        public IDbSet<Answer> Answers { get; set; }

        public IDbSet<OfferedAnswer> OfferedAnswers { get; set; }

        public ObjectContext ObjectContext
        {
            get { return ((IObjectContextAdapter)this).ObjectContext; }
        }
        
        protected override void Dispose(Boolean disposing)
        {
            if (disposing)
            {
                ObjectContext.ObjectMaterialized -= OnObjectMaterialized;
            }
            base.Dispose(disposing);
        }

        protected void OnObjectMaterialized(Object sender, ObjectMaterializedEventArgs args)
        {
            //
        }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new SurveyMap());
            modelBuilder.Configurations.Add(new QuestionMap());
            modelBuilder.Configurations.Add(new OfferedAnswerMap());
            modelBuilder.Configurations.Add(new AnswerMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
