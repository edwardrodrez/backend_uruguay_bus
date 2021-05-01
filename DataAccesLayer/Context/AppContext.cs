using DataAccesLayer.Entities;
using Share.Enums;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DataAccesLayer.Context
{
    class AppContext : DbContext
    {
        public AppContext()
           : base("name=AppContext")
        {

        }

        public DbSet<Asiento> Asiento { get; set; }
        public DbSet<Horario> Horario { get; set; }
        public DbSet<Linea> Linea { get; set; }
        public DbSet<Localizacion> Localizacion { get; set; }
        public DbSet<Parada> Parada { get; set; }
        public DbSet<Parada_linea> Paradalinea { get; set; }
        public DbSet<ParadaAnterior> ParadaAnterior { get; set; }
        public DbSet<Pasaje> Pasaje { get; set; }
        public DbSet<Precios> Precio { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Vehiculo> Vehiculo { get; set; }
        public DbSet<Viaje> Viaje { get; set; }
        public DbSet<Dia> Dia { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}
