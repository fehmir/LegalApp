using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LegalAnalyzer.Domain.Entities;

namespace LegalAnalyzer.Application.Interfaces
{
    public interface ILegalDocumentRepository
    {
        Task<IEnumerable<LegalDocument>> GetAllAsync();
        Task<LegalDocument?> GetByIdAsync(Guid id);
        Task AddAsync(LegalDocument document);
        Task DeleteAsync(Guid id);
        Task UpdateAsync(LegalDocument document);
    }
}