using LegalAnalyzer.Application.Interfaces;
using LegalAnalyzer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LegalAnalyzer.Infrastructure.Persistence.Repositories
{
    public class LegalDocumentRepository : ILegalDocumentRepository
    {
        private readonly Infrastructure.Persistence.LegalAnalyzerDbContext _context;

        public LegalDocumentRepository(Infrastructure.Persistence.LegalAnalyzerDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<LegalDocument>> GetAllAsync()
        {
            return await _context.LegalDocuments.ToListAsync();
        }

        public async Task<LegalDocument?> GetByIdAsync(Guid id)
        {
            return await _context.LegalDocuments.FindAsync(id);
        }

        public async Task AddAsync(LegalDocument document)
        {
            await _context.LegalDocuments.AddAsync(document);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Guid id)
        {
            var document = await _context.LegalDocuments.FindAsync(id);
            if (document != null)
            {
                _context.LegalDocuments.Remove(document);
                await _context.SaveChangesAsync();
            }
        }
        public async Task UpdateAsync(LegalDocument document)
        {
            _context.LegalDocuments.Update(document);
            await _context.SaveChangesAsync();
    }
    }
}