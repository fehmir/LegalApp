using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LegalAnalyzer.Domain.Entities
{
    public class LegalDocument
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FileName { get; set; } = string.Empty;
        [MaxLength(500)]
        public string FileType { get; set; } = string.Empty;
        public string EntitiesJson { get; set; } = string.Empty; // Store entity results as JSON
        public string ClausesJson { get; set; } = string.Empty; // Store clause detection results
        public string PreviewText { get; set; } = string.Empty; // First 1000 characters of the document

        public DateTime UploadedAt { get; set; } = DateTime.UtcNow;
    }
}