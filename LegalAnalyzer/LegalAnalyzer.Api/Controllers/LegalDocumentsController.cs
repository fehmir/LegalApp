using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LegalAnalyzer.Application.Interfaces;
using LegalAnalyzer.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;

namespace LegalAnalyzer.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LegalDocumentsController : ControllerBase
    {
        private readonly ILegalDocumentService _documentService;
        private readonly IHttpClientFactory _httpClientFactory;

        public LegalDocumentsController(ILegalDocumentService documentService, IHttpClientFactory httpClientFactory)
        {
            _documentService = documentService;
            _httpClientFactory = httpClientFactory;
        }

        // GET: api/legaldocuments
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var documents = await _documentService.GetAllAsync();
            return Ok(documents);
        }

        // GET: api/legaldocuments/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var document = await _documentService.GetByIdAsync(id);
            if (document == null)
                return NotFound();

            return Ok(document);
        }

        // Update: api/legaldocuments/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] LegalDocument document)
        {
            if (id != document.Id)
                return BadRequest("Document ID mismatch.");

            var existingDocument = await _documentService.GetByIdAsync(id);
            if (existingDocument == null)
                return NotFound();

            await _documentService.UpdateAsync(document);
            return NoContent(); // 204 No Content
        }

        // DELETE: api/legaldocuments/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var document = await _documentService.GetByIdAsync(id);
            if (document == null)
                return NotFound();
            
            await _documentService.DeleteAsync(id);
            return NoContent(); // 204 No Content
            // Optionally, you can also delete the file from the file system or cloud storage here.

        }

        // POST: api/legaldocuments/upload
        [HttpPost("upload")]
        public async Task<IActionResult> UploadDocument([FromForm] IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file uploaded.");

            using var stream = file.OpenReadStream();
            using var content = new MultipartFormDataContent
            {
                { new StreamContent(stream), "file", file.FileName }
            };

            var client = _httpClientFactory.CreateClient();
            var pythonApiUrl = "http://localhost:8001/analyze"; // adresse de microservice Python

            var response = await client.PostAsync(pythonApiUrl, content);

            if (!response.IsSuccessStatusCode)
                return StatusCode((int)response.StatusCode, "Error from analyzer service.");

            var result = await response.Content.ReadFromJsonAsync<AnalysisResult>();

            if (result == null)
                return StatusCode((int)response.StatusCode, "Invalid response from analyzer service.");

            if (result.Entities == null || result.Clauses == null || result.Preview == null)
                return StatusCode((int)response.StatusCode, "Incomplete response from analyzer service.");

            var document = new LegalDocument
            {
                Id = Guid.NewGuid(),
                FileName = file.FileName,
                FileType = file.ContentType,
                EntitiesJson = System.Text.Json.JsonSerializer.Serialize(result.Entities),
                ClausesJson = System.Text.Json.JsonSerializer.Serialize(result.Clauses),
                PreviewText = result.Preview,
                UploadedAt = DateTime.UtcNow
            };

            await _documentService.AddAsync(document);

            return CreatedAtAction(nameof(Get), new { id = document.Id }, document);
        }
    }

    // Classe pour désérialiser la réponse du microservice Python
    public class AnalysisResult
    {
        public Dictionary<string, List<string>> Entities { get; set; } = new(); 
        public Dictionary<string, bool> Clauses { get; set; } = new(); 
        public string? Preview { get; set; } = string.Empty;
    }
}
