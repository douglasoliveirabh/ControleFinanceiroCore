using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using ControleFinanceiro.Data.Extensions;
using ControleFinanceiro.Domain.Models;

namespace ControleFinanceiro.Data.Mappings
{
    public class PermissionMap : EntityTypeConfiguration<Permission>
    {
        public override void Map(EntityTypeBuilder<Permission> builder)
        {
            builder.ToTable("Permissions");

            builder.HasKey(g => g.PermissionId);

            builder.Property(g => g.ConstantName)
                   .HasColumnType("varchar(30)")
                   .HasMaxLength(30)
                   .IsRequired();

            builder.Property(g => g.Title)
                   .HasColumnType("varchar(50)")
                   .HasMaxLength(50)
                   .IsRequired();
        }
    }
}
