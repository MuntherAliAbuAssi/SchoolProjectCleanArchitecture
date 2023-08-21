using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolProject.Data.Models;

namespace SchoolProject.Infrastructure.Configrations
{
    public class InstractorSubjectCongirations : IEntityTypeConfiguration<Ins_Subject>
    {
        public void Configure(EntityTypeBuilder<Ins_Subject> builder)
        {

            builder.HasOne(sc => sc.Instractor)
            .WithMany(sc => sc.Ins_Subjects)
            .HasForeignKey(sc => sc.InsId);

            builder.HasOne(sc => sc.Subject)
            .WithMany(sc => sc.Ins_Subjects)
            .HasForeignKey(sc => sc.SubID);


        }
    }
}
