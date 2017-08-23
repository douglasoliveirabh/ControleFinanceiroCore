using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using ControleFinanceiro.Data.Extensions;
using ControleFinanceiro.Domain.Models;
using ControleFinanceiro.Domain.ValueObjects;

namespace ControleFinanceiro.Data.Mappings
{
    public class PersonMap : EntityTypeConfiguration<Person>
    {
        public override void Map(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("Persons");

            builder
                .HasKey(g => g.Id);

            builder
                .Property(g => g.Name)
                .HasColumnType("varchar(30)")
                .HasMaxLength(30)
                .IsRequired();

            builder.OwnsOne(p => p.Address, ad => {


                ad
                .Property(p => p.City)
                .HasColumnName("City")
                 .HasColumnType("varchar(50)")
                .HasMaxLength(50);

                ad
                    .Property(p => p.Complement)
                    .HasColumnName("Complement")
                     .HasColumnType("varchar(100)")
                    .HasMaxLength(100);

                ad
                   .Property(p => p.Country)
                   .HasColumnName("Country")
                    .HasColumnType("varchar(50)")
                   .HasMaxLength(50);

                ad
                   .Property(p => p.NeighborHood)
                   .HasColumnName("NeighborHood")
                   .HasColumnType("varchar(50)")
                   .HasMaxLength(50);

                ad
                   .Property(p => p.Number)
                   .HasColumnName("Number");

                ad
                   .Property(p => p.PostalCode)
                   .HasColumnName("PostalCode")
                   .HasColumnType("varchar(10)")
                   .HasMaxLength(10);

                ad
                   .Property(p => p.State)
                   .HasColumnName("State")
                   .HasColumnType("varchar(50)")
                   .HasMaxLength(50);

                ad
                  .Property(p => p.Street)
                  .HasColumnName("Street")
                  .HasColumnType("varchar(100)")
                  .HasMaxLength(100);
            });            
        }
    }

}
