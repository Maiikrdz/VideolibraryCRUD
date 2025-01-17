﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Videolibrary_CRUD.DataAccess
{
    public partial class VideolibraryContext : DbContext
    {
        public VideolibraryContext()
        {
        }

        public VideolibraryContext(DbContextOptions<VideolibraryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Movie> Movies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress; Database=Videolibrary;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Director)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("director");

                entity.Property(e => e.Genre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("genre");

                entity.Property(e => e.Rating)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("rating");

                entity.Property(e => e.ReleaseDate).HasColumnName("release_date");

                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("title");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
