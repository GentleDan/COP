using FurnitureFactoryDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace FurnitureFactoryDatabaseImplement
{
    public class FurnitureFactoryDatabase : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=FurnitureFactoryDatabase;Integrated Security=True;MultipleActiveResultSets=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }
        public virtual DbSet<Supplier> Suppliers { set; get; }
        public virtual DbSet<Manager> Managers { set; get; }
        public virtual DbSet<SupplierDates> SupplierDates { get; set; }
    }
}
