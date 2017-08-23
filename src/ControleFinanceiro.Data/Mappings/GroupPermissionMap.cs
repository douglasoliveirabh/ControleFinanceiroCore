using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using ControleFinanceiro.Data.Extensions;
using ControleFinanceiro.Domain.Models;

namespace ControleFinanceiro.Data.Mappings
{
    public class GroupPermissionMap : EntityTypeConfiguration<GroupPermission>
    {
        public override void Map(EntityTypeBuilder<GroupPermission> builder)
        {
            builder.ToTable("GroupPermission");

            builder
                .HasKey(gp => new { gp.GroupId, gp.PermissionId });

            builder
                .HasOne(gp => gp.Permission)
                .WithMany(g => g.Groups)
                .HasForeignKey(gp => gp.PermissionId);

            builder
                .HasOne(gp => gp.Group)
                .WithMany(p => p.Permissions)
                .HasForeignKey(gp => gp.GroupId);
        }
    }
}
