using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using System.Web.Security;
using Olts.DataAccess;
using Olts.Domain;
using Olts.Domain.Enums;
using WebMatrix.WebData;

namespace Olts.WebUi.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public sealed class InitializeSimpleMembershipAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            LazyInitializer.EnsureInitialized(ref _initializer, ref _isInitialized, ref _initializerLock);
        }

        private class SimpleMembershipInitializer
        {
            public SimpleMembershipInitializer()
            {
                Database.SetInitializer<OltsContext>(null);
                try
                {
                    using (var context = new OltsContext())
                    {
                        if (!context.Database.Exists())
                        {
                            ((IObjectContextAdapter)context).ObjectContext.CreateDatabase();
                        }
                    }
                    WebSecurity.InitializeDatabaseConnection("Olts", "Users", "Id", "Name", true);
#if DEBUG
                    Seed();
#endif
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException("The ASP.NET Simple Membership database could not be initialized. For more information, please see http://go.microsoft.com/fwlink/?LinkId=256588", ex);
                }
            }
        }

        private static void Seed()
        {
            Roles.CreateRole("User");
            Roles.CreateRole("Administrator");
            Roles.CreateRole("Teacher");
            foreach (Int32 index in Enumerable.Range(1, 10))
            {
                var name = "user" + index + "@olts.com";
                WebSecurity.CreateUserAndAccount(name, name);
                if (index % 3 == 0)
                {
                    Roles.AddUserToRole(name, "Administrator");
                }
                else if (index % 2 == 0)
                {
                    Roles.AddUserToRole(name, "Teacher");
                }
                else
                {
                    Roles.AddUserToRole(name, "User");
                }
            }

            using (var context = new OltsContext())
            {
                foreach (Int32 index in Enumerable.Range(1, 3))
                {
                    var survey = new Survey
                    {
                        Name = "Survey Name" + index,
                        Description = "Survey Description" + index,
                        Owner = context.Users.First(),
                        Questions = new List<Question>
                        {
                            new Question { QuestionType = QuestionType.Checkbox, Text = "Question " + index },
                            new Question { QuestionType = QuestionType.Radio, Text = "Question " + index },
                            new Question { QuestionType = QuestionType.Textbox, Text = "Question " + index },
                            new Question { QuestionType = QuestionType.Textarea, Text = "Question " + index }
                        }
                    };
                    context.Surveys.Add(survey);
                }
                context.SaveChanges();
            }
        }

        private static SimpleMembershipInitializer _initializer;
        private static Object _initializerLock = new Object();
        private static Boolean _isInitialized;
    }
}
