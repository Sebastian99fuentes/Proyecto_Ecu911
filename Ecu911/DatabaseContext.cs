
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore;
using Ecu911.Modelos;
using System.Data.Entity;

namespace Ecu911
{
    public partial class DatabaseContext : IdentityDbContext<User>
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        //public virtual DbSet<AlertaDSPPP> Alertas { get; set; } = null!;
        //public virtual DbSet<Contractual> Contractuales { get; set; } = null!;
        //public virtual DbSet<Estado> Estados { get; set; } = null!;
        //public virtual DbSet<Etapa> Etapas { get; set; } = null!;
        //public virtual DbSet<Observacion> Observaciones { get; set; } = null!;
        //public virtual DbSet<PlantaUnidadArea> PlantaUnidadAreas { get; set; } = null!;
        //public virtual DbSet<Precontractual> Precontractuales { get; set; } = null!;
        //public virtual DbSet<Preparatoria> Preparatorias { get; set; } = null!;
        //public virtual DbSet<ProcedimientoContratacion> ProcedimientoContrataciones { get; set; } = null!;
        //public virtual DbSet<ProcesoCompra> ProcesoCompras { get; set; } = null!;
        //public virtual DbSet<User> Usuarios { get; set; } = null!;
        //public virtual DbSet<FechaReasignacionIda> FechaReasignacionIdas { get; set; } = null!;
        //public virtual DbSet<FechaReasignacionVuelta> FechaReasignacionVueltas { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //Relaciones 1-1
            builder.HasPostgresExtension("uuid-ossp");
            builder.Entity<Preparatoria>()
                .HasIndex(x => x.IdProcesoCompra)
                .IsUnique();
            builder.Entity<Precontractual>()
                .HasIndex(x => x.IdPreparatoria)
                .IsUnique();
            builder.Entity<Contractual>()
                .HasIndex(x => x.IdPrecontractual)
                .IsUnique();


            //Generación uuid tablas modelo
            builder.Entity<AlertaDSPPP>(o =>
                o.Property(x => x.AlertaDSPPPId)
                .HasDefaultValue("uuid_generate_v4()")
                .ValueGeneratedOnAdd());

            builder.Entity<Contractual>(o =>
                o.Property(x => x.IdPrecontractual)
                .HasDefaultValue("uuid_generate_v4()")
                .ValueGeneratedOnAdd());

            builder.Entity<Estado>(o =>
                o.Property(x => x.EstadoId)
                .HasDefaultValue("uuid_generate_v4()")
                .ValueGeneratedOnAdd());

            builder.Entity<Etapa>(o =>
                o.Property(x => x.EtapaId)
                .HasDefaultValue("uuid_generate_v4()")
                .ValueGeneratedOnAdd());

            builder.Entity<FechaReasignacionIda>(o =>
                o.Property(x => x.IdIda)
                .HasDefaultValue("uuid_generate_v4()")
                .ValueGeneratedOnAdd());

            builder.Entity<FechaReasignacionVuelta>(o =>
                o.Property(x => x.IdVuelta)
                .HasDefaultValue("uuid_generate_v4()")
                .ValueGeneratedOnAdd());

            builder.Entity<Observacion>(o =>
                o.Property(x => x.ObservacionId)
                .HasDefaultValue("uuid_generate_v4()")
                .ValueGeneratedOnAdd());

            builder.Entity<PlantaUnidadArea>(o =>
                o.Property(x => x.PlantaUnidadAreaId)
                .HasDefaultValue("uuid_generate_v4()")
                .ValueGeneratedOnAdd());

            builder.Entity<Precontractual>(o =>
                o.Property(x => x.IdPrecontractual)
                .HasDefaultValue("uuid_generate_v4()")
                .ValueGeneratedOnAdd());

            builder.Entity<Preparatoria>(o =>
                o.Property(x => x.PreparatoriaId)
                .HasDefaultValue("uuid_generate_v4()")
                .ValueGeneratedOnAdd());

            builder.Entity<ProcedimientoContratacion>(o =>
                o.Property(x => x.ProcedimientoContratacionId)
                .HasDefaultValue("uuid_generate_v4()")
                .ValueGeneratedOnAdd());

            builder.Entity<ProcesoCompra>(o =>
                o.Property(x => x.ProcesoCompraId)
                .HasDefaultValue("uuid_generate_v4()")
                .ValueGeneratedOnAdd());


            base.OnModelCreating(builder);
        }
    }
}
