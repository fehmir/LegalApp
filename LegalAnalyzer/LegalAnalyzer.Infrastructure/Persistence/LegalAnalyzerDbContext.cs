using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LegalAnalyzer.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LegalAnalyzer.Infrastructure.Persistence
{
    public class LegalAnalyzerDbContext : DbContext
    {
        public LegalAnalyzerDbContext(DbContextOptions<LegalAnalyzerDbContext> options)
            : base(options)
        {
        }

        public DbSet<LegalDocument> LegalDocuments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<LegalDocument>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.FileName)
                      .IsRequired()
                      .HasMaxLength(255);

                entity.Property(e => e.FileType)
                      .IsRequired()
                      .HasMaxLength(500);

                entity.Property(e => e.EntitiesJson)
                      .HasColumnType("nvarchar(max)");

                entity.Property(e => e.ClausesJson)
                      .HasColumnType("nvarchar(max)");

                entity.Property(e => e.PreviewText)
                      .HasColumnType("nvarchar(max)");

                entity.Property(e => e.UploadedAt)
                      .IsRequired();
            });
        }
    }
}