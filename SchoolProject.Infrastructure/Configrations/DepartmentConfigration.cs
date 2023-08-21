using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolProject.Data.Models;

namespace SchoolProject.Infrastructure.Configrations
{
    public class DepartmentConfigration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {

            builder.HasKey(x => x.DID);
            builder.Property(x => x.DNameAr).HasMaxLength(500);

            builder.HasMany(x => x.Students)
            .WithOne(x => x.Department)
            .HasForeignKey(x => x.DID)
            .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Instractor)
           .WithOne(x => x.DepartmentManager)
           .HasForeignKey<Department>(x => x.InsManager)
           .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
