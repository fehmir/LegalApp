using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LegalAnalyzer.Domain.Interfaces
{
    public interface IDocumentAnalyzer
    {
        Task<string> AnalyzeAsync(Stream fileStream, string fileType);
    }
}