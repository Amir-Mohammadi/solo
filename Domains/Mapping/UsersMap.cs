using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Solo.Domains
{
    public class UserMap : IEntityTypeConfiguration<Users>
    {
        public void Configure(EntityTypeBuilder<Users> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("Users");

            builder.Property(x => x.Id);
            builder.Property(x => x.UserName);
            builder.Property(x => x.BirthDate).HasColumnType("smalldatetime");
            builder.Property(x => x.RowVersion).IsRowVersion();


        }
    }
}