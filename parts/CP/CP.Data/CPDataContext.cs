namespace CP.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using CP.Data.Models;

    public partial class CPDataContext : DbContext
    {
        public DbSet<Store> Stores { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Stocklot> Stocklots { get; set; }
        public DbSet<ItemImage> ItemImages { get; set; }
       
        public CPDataContext()
            : base("name=CPDataContext")
        {
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
