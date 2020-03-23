using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4TSP.Model
{
    public class ModelContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-E56VA36;Database=EfCore2020;Trusted_Connection=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AlbumArtist>()
                .HasKey(aa => new { aa.AlbumId, aa.ArtistId });

            modelBuilder.Entity<AlbumArtist>()
                .HasOne(aa => aa.Artist)
                .WithMany(ar => ar.AlbumArtists)
                .HasForeignKey(aa => aa.ArtistId);

            modelBuilder.Entity<AlbumArtist>()
                .HasOne(aa => aa.Album)
                .WithMany(al => al.AlbumArtists)
                .HasForeignKey(aa => aa.AlbumId);
        }

        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Customer> CustomerSet { get; set; }
        public virtual DbSet<Order> OrderSet { get; set; }
        public virtual DbSet<Album> AlbumSet { get; set; }
        public virtual DbSet<Artist> ArtistSet { get; set; }
    }
}
