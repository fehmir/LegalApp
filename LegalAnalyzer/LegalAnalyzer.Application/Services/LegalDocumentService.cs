using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LegalAnalyzer.Application.DTOs;
using LegalAnalyzer.Application.Interfaces;
using LegalAnalyzer.Domain.Entities;

namespace LegalAnalyzer.Application.Services
{
    public class LegalDocumentService : ILegalDocumentService
    {
        private readonly ILegalDocumentRepository _repository;

        public LegalDocumentService(ILegalDocumentRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<LegalDocument>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<LegalDocument?> GetByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddAsync(LegalDocument document)
        {
            document.UploadedAt = DateTime.UtcNow;
            await _repository.AddAsync(document);
        }

        public async Task DeleteAsync(Guid id)
        {

            var document = await _repository.GetByIdAsync(id);

            if (document != null)
            {
                await _repository.DeleteAsync(document.Id);
                // Optionally, delete the file from the file system or cloud storage here.
            }
        }

        public async Task UpdateAsync(LegalDocument document)
        {
            var existingDocument = await _repository.GetByIdAsync(document.Id);
            if (existingDocument != null)
            {
                existingDocument.FileName = document.FileName;
                existingDocument.FileType = document.FileType;
                existingDocument.EntitiesJson = document.EntitiesJson;
                existingDocument.ClausesJson = document.ClausesJson;
                existingDocument.PreviewText = document.PreviewText;
                existingDocument.UploadedAt = DateTime.UtcNow; // Update the timestamp
                
                await _repository.UpdateAsync(existingDocument);
            }
        }
    }
}