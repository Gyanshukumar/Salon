//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Salon_and_Spa
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SalonEntities : DbContext
    {
        public SalonEntities()
            : base("name=SalonEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<General_User> General_User { get; set; }
        public virtual DbSet<Salon_Owner> Salon_Owner { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        public System.Data.Entity.DbSet<Salon_and_Spa.Models.BookingSystem> BookingSystems { get; set; }

        public System.Data.Entity.DbSet<Salon_and_Spa.Models.User> Users { get; set; }
    }
}
