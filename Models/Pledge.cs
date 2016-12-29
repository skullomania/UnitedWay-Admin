namespace UWA.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Pledge : DbContext
    {
        public Pledge()
            : base("name=Pledge")
        {
        }

        public virtual DbSet<UnitedWay_KDMC2Pledges> UnitedWay_KDMC2Pledges { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
