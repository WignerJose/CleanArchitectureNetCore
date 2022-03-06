
using CleanArchitecture.Domain;
using CleanArchitecture.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Persistence
{
    public class StreamerDbContext : DbContext
    {
        public StreamerDbContext(DbContextOptions<StreamerDbContext> options) : base(options)
        {
        }


        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Streamer;Integrated Security=True;")
        //                                .LogTo(Console.WriteLine, new[] {DbLoggerCategory.Database.Name},
        //                                Microsoft.Extensions.Logging.LogLevel.Information)
        //                                .EnableSensitiveDataLogging();
        //}

        public override Task<int> SaveChangesAsync(CancellationToken cancellation = default)
        {
            foreach(var entry in ChangeTracker.Entries<BaseDomainModel>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreateAt = DateTime.Now;
                        entry.Entity.CreateBy = "system";
                        break;
                    case EntityState.Modified:
                        entry.Entity.UpdateAt = DateTime.Now;
                        entry.Entity.LastUpdateBy = "system";
                        break;
                }

            }
            return base.SaveChangesAsync(cancellation);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Streamer>()
                .HasMany(m => m.Videos)
                .WithOne(m => m.Streamer)
                .HasForeignKey(m => m.StreamerId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Video>()
                .HasMany(p => p.Actors)
                .WithMany(t => t.Videos)
                .UsingEntity<VideoActor>
                (
                 pt => pt.HasKey(e => new { e.ActorId, e.VideoId })
                );
        }
        public DbSet<Streamer>? Streamers { get; set; }
        public DbSet<Video>? Videos { get; set; }
    }
}
