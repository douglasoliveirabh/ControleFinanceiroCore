using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using ControleFinanceiro.Data.Extensions;
using ControleFinanceiro.Domain.Models;

namespace ControleFinanceiro.Data.Mappings
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public override void Map(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(u => u.UserId);

            builder.Property(u => u.Email)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100);

            builder.Property(u => u.Username)
                    .HasColumnType("varchar(20)")
                    .HasMaxLength(20)
                    .IsRequired();

            builder.Property(u => u.Password)
                    .HasColumnType("varchar(20)")
                    .HasMaxLength(20)
                    .IsRequired();
        }
    }
}
