using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LegalAnalyzer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LegalAnalyzer.Infrastructure.Persistence.Configurations
{
    public class LegalDocumentConfiguration : IEntityTypeConfiguration<LegalDocument>
    {
        public void Configure(EntityTypeBuilder<LegalDocument> builder)
        {
            builder.HasKey(d => d.Id);
            builder.Property(d => d.FileName).IsRequired();
            builder.Property(d => d.FileType).IsRequired();
            builder.Property(d => d.EntitiesJson).HasColumnType("text");
            builder.Property(d => d.ClausesJson).HasColumnType("text");
            builder.Property(d => d.PreviewText).HasColumnType("text");
            builder.Property(d => d.UploadedAt).IsRequired();
        }
    }
   
}