using Microsoft.EntityFrameworkCore;

using ControleFinanceiro.Data.Extensions;
using ControleFinanceiro.Data.Mappings;
using ControleFinanceiro.Domain.Models;

namespace ControleFinanceiro.Data.Context
{
    public class ControleFinanceiroContext : DBContextBase
    {        

        public ControleFinanceiroContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Permission> Permissions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddConfiguration(new UserMap());
            modelBuilder.AddConfiguration(new GroupMap());
            modelBuilder.AddConfiguration(new PermissionMap());
            modelBuilder.AddConfiguration(new UserGroupMap());
            modelBuilder.AddConfiguration(new GroupPermissionMap());
            modelBuilder.AddConfiguration(new PersonMap());

            base.OnModelCreating(modelBuilder);
        }        
    }
}
