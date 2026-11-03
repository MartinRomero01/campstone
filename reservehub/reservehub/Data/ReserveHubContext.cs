using Microsoft.EntityFrameworkCore;
using reservehub.Models;

namespace reservehub.Data
{
    public class ReserveHubContext : DbContext
    {
        public ReserveHubContext(DbContextOptions<ReserveHubContext> options)
            : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; } = null!;
        public DbSet<Carrera> Carreras { get; set; } = null!;
        public DbSet<Arancele> Aranceles { get; set; } = null!;
        public DbSet<Servicio> Servicios { get; set; } = null!;
        public DbSet<Solicitude> Solicitudes { get; set; } = null!;
        public DbSet<Reserva> Reservas { get; set; } = null!;
        public DbSet<Notificacione> Notificaciones { get; set; } = null!;
        public DbSet<ChatMensaje> ChatMensajes { get; set; } = null!;
        public DbSet<Role> Roles { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Relación Usuario - Carrera
            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.Carrera)
                .WithMany(c => c.Usuarios)
                .HasForeignKey(u => u.CarreraId)
                .OnDelete(DeleteBehavior.SetNull);

            // Relación Reserva - Usuario (Atención Presencial)
            modelBuilder.Entity<Reserva>()
                .HasOne(r => r.Usuario)
                .WithMany()
                .HasForeignKey(r => r.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade);

            // Relación Solicitude - Usuario (Atención Online)
            modelBuilder.Entity<Solicitude>()
                .HasOne(s => s.Usuario)
                .WithMany(u => u.Solicitudes)
                .HasForeignKey(s => s.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade);

            // Relación Solicitude - Servicio
            modelBuilder.Entity<Solicitude>()
                .HasOne(s => s.Servicio)
                .WithMany(serv => serv.Solicitudes)
                .HasForeignKey(s => s.ServicioId)
                .OnDelete(DeleteBehavior.SetNull);

            // Relación ChatMensaje - Usuario (Soporte / Chat)
            modelBuilder.Entity<ChatMensaje>()
                .HasOne(c => c.Usuario)
                .WithMany(u => u.ChatMensajes)
                .HasForeignKey(c => c.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}