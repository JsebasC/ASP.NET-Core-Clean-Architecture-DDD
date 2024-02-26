using CleanArchitecture.Domain;
using CleanArchitecture.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Persistence
{
    public class StreamerDbContext : DbContext
    {
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Data Source=DESKTOP-AGLSFFL\\SQLEXPRESS; Initial Catalog=Streamer; user id=DESKTOP-AGLSFFL\\Johan Sebastian Cuel; password=''; TrustServerCertificate=True; Integrated Security=True")
        //        .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information)
        //        .EnableSensitiveDataLogging();
        //}

        public StreamerDbContext(DbContextOptions<StreamerDbContext> options) : base(options)
        {
        }

        //Se va a utilizar despues de un guardar o actualizar
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseDomainModel>())
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        entry.Entity.LastModifiedBy = "system";
                        break;
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        entry.Entity.CreatedBy = "system";
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        //Utilizar, cuando requiera hacerlo manual Ejemplo : Alguien no sigue la convencion de entity framework
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Streamer>()
                .HasMany(model => model.Videos)
                .WithOne(model => model.Streamer)
                .HasForeignKey(model => model.StreamerId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Video>()
                .HasMany(model => model.Actores)
                .WithMany(model => model.Videos)
                .UsingEntity<VideoActor>(
                    pt => pt.HasKey(e => new { e.ActorId, e.VideoId })
                );

        }

        public DbSet<Streamer>? Streamers { get; set; }
        public DbSet<Video>? Videos { get; set; }
        public DbSet<Actor>? Actores { get; set; }
    }
}
