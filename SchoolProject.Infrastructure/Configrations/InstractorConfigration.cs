using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolProject.Data.Models;

namespace SchoolProject.Infrastructure.Configrations
{
    public class InstractorConfigration : IEntityTypeConfiguration<Instractor>
    {
        public void Configure(EntityTypeBuilder<Instractor> builder)
        {
            builder.HasOne(x => x.Supervisor)
           .WithMany(x => x.Instractors)
           .HasForeignKey(x => x.SupervisorId)
           .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
