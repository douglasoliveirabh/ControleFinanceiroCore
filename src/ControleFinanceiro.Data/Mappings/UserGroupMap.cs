using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using ControleFinanceiro.Data.Extensions;
using ControleFinanceiro.Domain.Models;

namespace ControleFinanceiro.Data.Mappings
{
    public class UserGroupMap : EntityTypeConfiguration<UserGroup>
    {
        public override void Map(EntityTypeBuilder<UserGroup> builder)
        {
            builder.ToTable("UserGroup");

            builder
                .HasKey(ug => new { ug.GroupId, ug.UserId });

            builder
                .HasOne(ug => ug.User)
                .WithMany(u => u.Groups)
                .HasForeignKey(ug => ug.UserId);

            builder
                .HasOne(ug => ug.Group)
                .WithMany(g => g.Users)
                .HasForeignKey(ug => ug.GroupId);


        }
    }
}
