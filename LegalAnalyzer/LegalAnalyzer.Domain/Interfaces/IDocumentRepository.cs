using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LegalAnalyzer.Domain.Entities;

namespace LegalAnalyzer.Domain.Interfaces
{
    public interface IDocumentRepository
    {
        Task AddAsync(LegalDocument legalDocument);
        Task<LegalDocument?> GetByIdAsync(Guid id);
    }
}