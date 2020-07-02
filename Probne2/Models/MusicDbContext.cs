using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Probne2.Models
{
    public class MusicDbContext : DbContext
    {
        public DbSet<Album> Albums { get; set; }
        public DbSet<Musician> Musicians { get; set; }
        public DbSet<MusicianTrack> MusicianTracks { get; set; }
        public DbSet<MusicLabel> MusicLabels { get; set; }
        public DbSet<Track> Tracks { get; set; }

        public MusicDbContext() { }

        public MusicDbContext(DbContextOptions options)
        : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MusicLabel>(opt => 
            {
                opt.HasKey(p => p.IdMusicLabel); //klucz główny
                opt.Property(p => p.IdMusicLabel)
                    .ValueGeneratedOnAdd(); //automatycznie generowany przy wstawianiu
                opt.Property(p => p.Name)
                    .HasMaxLength(50)
                    .IsRequired();
                opt.HasMany(p => p.Albums)
                    .WithOne(p => p.MusicLabel)
                    .HasForeignKey(p => p.IdMusicLabel);
            });

            modelBuilder.Entity<MusicianTrack>(opt =>
            {
                opt.HasKey(p => p.IdMusicianTrack); //klucz główny
                opt.Property(p => p.IdMusicianTrack)
                    .ValueGeneratedOnAdd(); //automatycznie generowany przy wstawianiu              
                opt.HasOne(p => p.Track)
                    .WithMany(p => p.MusicianTracks)
                    .HasForeignKey(p => p.IdTrack);
                opt.HasOne(p => p.Musician)
                    .WithMany(p => p.MusicianTracks)
                    .HasForeignKey(p => p.IdMusician);
            });

            modelBuilder.Entity<Track>(opt =>
            {
                opt.HasKey(p => p.IdTrack); //klucz główny
                opt.Property(p => p.IdTrack)
                    .ValueGeneratedOnAdd(); //automatycznie generowany przy wstawianiu              
                opt.Property(p => p.TrackName)
                    .HasMaxLength(20)
                    .IsRequired();
                opt.HasOne(p => p.Album)
                    .WithMany(p => p.Tracks)
                    .HasForeignKey(p => p.IdMusicAlbum);
            });

            modelBuilder.Entity<Album>(opt =>
            {
                opt.HasKey(p => p.IdAlbum); //klucz główny
                opt.Property(p => p.IdAlbum)
                    .ValueGeneratedOnAdd(); //automatycznie generowany przy wstawianiu              
                opt.Property(p => p.AlbumName)
                    .HasMaxLength(30)
                    .IsRequired();
                
            });

            modelBuilder.Entity<Musician>(opt =>
            {
                opt.HasKey(p => p.IdMusician); //klucz główny
                opt.Property(p => p.IdMusician)
                    .ValueGeneratedOnAdd(); //automatycznie generowany przy wstawianiu              
                opt.Property(p => p.FirstName)
                    .HasMaxLength(30)
                    .IsRequired();
                opt.Property(p => p.LastName)
                   .HasMaxLength(50)
                   .IsRequired();
                opt.Property(p => p.NickName)
                   .HasMaxLength(20);
                  
            });

            Seed(modelBuilder);

        }

        private void Seed(ModelBuilder modelBuilder) {

            //musicLabels
            List<MusicLabel> musicLabels = new List<MusicLabel>();
            musicLabels.Add(new MusicLabel { IdMusicLabel = 1, Name = "Sony"});
            musicLabels.Add(new MusicLabel { IdMusicLabel = 2, Name = "Dux" });

            modelBuilder.Entity<MusicLabel>().HasData(musicLabels);

            //albums
            List<Album> albums = new List<Album>();
            albums.Add(new Album { IdAlbum = 1, AlbumName = "Sonaty skrzypcowe", PublichDate = new DateTime(2020, 7, 10), IdMusicLabel = 1 });
            albums.Add(new Album { IdAlbum = 2, AlbumName = "Muzyka klubowa", PublichDate = new DateTime(2021, 7, 4), IdMusicLabel = 1 });
            albums.Add(new Album { IdAlbum = 3, AlbumName = "Hip-hop", PublichDate = new DateTime(2011, 3, 10), IdMusicLabel = 2 });

            modelBuilder.Entity<Album>().HasData(albums);
        }
            
    }
}
