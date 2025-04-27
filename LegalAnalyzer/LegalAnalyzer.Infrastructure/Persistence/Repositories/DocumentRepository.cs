using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LegalAnalyzer.Domain.Entities;
using LegalAnalyzer.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LegalAnalyzer.Infrastructure.Persistence.Repositories
{
    /* public class DocumentRepository : IDocumentRepository
    {
    private readonly LegalAnalyzerDbContext _context;

    public DocumentRepository(LegalAnalyzerDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(LegalDocument legalDocument) 
    {
        _context.LegalDocuments.Add(legalDocument);
        await _context.SaveChangesAsync();
    }

    public async Task<Document?> GetByIdAsync(Guid id)
    {
        return await _context.LegalDocuments.FirstOrDefaultAsync(d => d.Id == id);
    } */
}