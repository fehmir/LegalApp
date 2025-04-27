using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using LegalAnalyzer.Domain.Interfaces;

namespace LegalAnalyzer.Infrastructure.PythonClient
{
    public class PythonAnalyzerClient : IDocumentAnalyzer
    {
        private readonly HttpClient _httpClient;
        public PythonAnalyzerClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> AnalyzeAsync(Stream fileStream, string fileType)
    {
        using var content = new MultipartFormDataContent();
        var fileContent = new StreamContent(fileStream);
        fileContent.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

        content.Add(fileContent, "file", "document." + fileType);

        var response = await _httpClient.PostAsync("/analyze", content);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadAsStringAsync();
    }
    }
}