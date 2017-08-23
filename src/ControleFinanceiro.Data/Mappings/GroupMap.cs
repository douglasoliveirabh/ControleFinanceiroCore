using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using ControleFinanceiro.Data.Extensions;
using ControleFinanceiro.Domain.Models;


namespace ControleFinanceiro.Data.Mappings
{
    public class GroupMap : EntityTypeConfiguration<Group>
    {
        public override void Map(EntityTypeBuilder<Group> builder)
        {
            builder.ToTable("Groups");
            

            builder
                .HasKey(g => g.GroupId);

            builder
                .Property(g => g.Name)
                .HasColumnType("varchar(30)")
                .HasMaxLength(30)
                .IsRequired();
        }
    }
}
