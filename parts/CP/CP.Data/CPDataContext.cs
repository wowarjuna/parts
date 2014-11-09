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
       
        public CPDataContext()
            : base("name=CPDataContext")
        {
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
