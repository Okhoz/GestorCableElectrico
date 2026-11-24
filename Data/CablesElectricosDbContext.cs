using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Model;

namespace Data
{
    public class CablesElectricosDbContext : DbContext
    {

        public virtual DbSet<CableElectrico> CablesElectricos { get; set; }
        public CablesElectricosDbContext() : base ("BDCablesElectricosEF")
        {
            var instance =  System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CableElectrico>()
                .ToTable("CablesElectricos");

            modelBuilder.Entity<CableElectrico>()
                .HasKey(c => c.NumeroDeSerie);

            modelBuilder.Entity<CableElectrico>().Ignore(c => c.SeccionDelCable);

            modelBuilder.Entity<CableElectrico>().Property(c => c.SeccionDelCableAxu)
                .HasColumnType("char")
                .IsFixedLength()
                .HasMaxLength(1);

        }

    }
}
