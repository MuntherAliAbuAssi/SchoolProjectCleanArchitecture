using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolProject.Data.Models;

namespace SchoolProject.Infrastructure.Configrations
{
    public class StudentSubjectConfigration : IEntityTypeConfiguration<StudentSubject>
    {
        public void Configure(EntityTypeBuilder<StudentSubject> builder)
        {

            builder.HasKey(x => x.StudSubID);

            builder.HasOne(sc => sc.Student)
                .WithMany(sc => sc.StudentSubjects)
                .HasForeignKey(sc => sc.StudID);

            builder.HasOne(sc => sc.Subject)
                .WithMany(sc => sc.StudentsSubjects)
                .HasForeignKey(sc => sc.SubID);




        }
    }
}
