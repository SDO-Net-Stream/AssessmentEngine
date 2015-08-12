using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Olts.Domain;

namespace Olts.DataAccess.DataMaps
{
    internal sealed class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            ToTable("User");
            HasKey(user => user.Id);
            Property(user => user.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(user => user.Name).IsRequired().HasMaxLength(256);
        }
    }
}
