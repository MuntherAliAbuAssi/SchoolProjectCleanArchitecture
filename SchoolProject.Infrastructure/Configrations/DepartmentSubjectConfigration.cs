using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolProject.Data.Models;

namespace SchoolProject.Infrastructure.Configrations
{
    public class DepartmentSubjectConfigration : IEntityTypeConfiguration<DepartmetSubject>
    {
        public void Configure(EntityTypeBuilder<DepartmetSubject> builder)
        {

            builder.HasOne(sc => sc.Department)
            .WithMany(sc => sc.DepartmentSubjects)
            .HasForeignKey(sc => sc.DID);

            builder.HasOne(sc => sc.Subject)
            .WithMany(sc => sc.DepartmetsSubjects)
            .HasForeignKey(sc => sc.SubID);

        }
    }
}
