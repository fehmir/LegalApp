using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LegalAnalyzer.Application.DTOs
{
    public class LegalDocumentDto
    {
        public Guid Id { get; set; }
        public string? FileName { get; set; }
        public string? FileType { get; set; }
        public string? EntitiesJson { get; set; }
        public string? ClausesJson { get; set; }
        public string? PreviewText { get; set; }
        public DateTime UploadedAt { get; set; }
    }
}