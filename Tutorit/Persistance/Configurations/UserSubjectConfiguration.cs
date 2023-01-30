using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tutorit.Models;

namespace Tutorit.Persistance.Configurations;

public class UserSubjectConfiguration : IEntityTypeConfiguration<UserSubject>
{
    public void Configure(EntityTypeBuilder<UserSubject> builder)
    {
        builder.HasKey(x => new {x.SubjectId, x.UserId});

        builder.HasOne(x => x.User)
            .WithMany(u => u.UserSubjects)
            .HasForeignKey(x => x.UserId);

        builder.HasOne(x => x.Subject)
            .WithMany(s => s.UserSubjects)
            .HasForeignKey(x => x.SubjectId);
    }
}