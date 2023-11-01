using DL___Web_Api.Model.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Contracts;
using System.Reflection.Emit;

namespace DL___Web_Api.Data
{
    public class ComcoMContext : DbContext
    {
       
        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);
            
            //ارتباط جدول deviced ba deviceh
            //builder.Entity<DeviceD>()
            //    .HasRequired(x => x.DeviceH)
            //    .WithMany(x => x.IColDevicesD)
            //    .HasForeignKey(x => x.HID);
            //builder.Entity<Contact>()
            //    .HasOptional(x => x.Customer)
            //    .WithMany(x => x.Contacts)
            //    .HasForeignKey<int?>(x => x.CustomerID)
            //    .WillCascadeOnDelete();
            //builder.Entity<Contract>()
            //    .HasRequired(x => x.ContractTemplate)
            //    .WithMany(x => x.Contracts)
            //    .HasForeignKey(x => x.ContractTemplateId);
            //builder.Entity<ContractLine>()
            //    .HasOptional(x => x.Contract)
            //    .WithMany(x => x.ContractLines)
            //    .HasForeignKey<int?>(x => x.ContractId)
            //    .WillCascadeOnDelete();
            //builder.Entity<Tariff>()
            //    .HasOptional(x => x.ContractTemplate)
            //    .WithMany(x => x.Tariffs)
            //    .HasForeignKey<int?>(x => x.ContractTemplateId)
            //    .WillCascadeOnDelete();

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Team> Teams { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=192.168.0.63; Initial Catalog=ComcoMNG;Integrated Security=False;User ID=sa;Password=123456;MultipleActiveResultSets=True""");
        }

    }
}
