# Legal Document Analyzer

Legal Document Analyzer is a comprehensive application designed to analyze legal documents. It consists of three main components:

1. **Backend (LegalAnalyzer)**: A .NET-based API that handles document management and integrates with the Python microservice for document analysis.
2. **Frontend (LegalAnalyzerFrontend)**: A React-based user interface for uploading, viewing, and managing analyzed documents.
3. **Python Microservice (legal-analyzer-microservice)**: A FastAPI-based service that performs document analysis using NLP models.

## Features
- Upload and analyze legal documents (PDF and DOCX formats).
- Extract entities and clauses using NLP models.
- View document details, including extracted entities and clauses.
- Manage documents (view, delete) via the frontend.

## Project Structure
```
legal-analyzer-microservice/
    analyzer.py
    main.py
    requirements.txt
LegalAnalyzer/
    LegalAnalyzer.Api/
    LegalAnalyzer.Application/
    LegalAnalyzer.Domain/
    LegalAnalyzer.Infrastructure/
LegalAnalyzerFrontend/
    src/
    public/
    package.json
```

## Setup Instructions

### Backend (LegalAnalyzer)
1. Navigate to the `LegalAnalyzer` directory.
2. Open the solution file `LegalAnalyzer.sln` in Visual Studio.
3. Configure the database connection string in `appsettings.json`.
4. Run the following commands to apply migrations and start the API:
   ```bash
   dotnet ef database update
   dotnet run --project LegalAnalyzer.Api
   ```
5. The API will be available at `https://localhost:7214`.

### Frontend (LegalAnalyzerFrontend)
1. Navigate to the `LegalAnalyzerFrontend` directory.
2. Install dependencies:
   ```bash
   npm install
   ```
3. Start the development server:
   Note: Ensure you have Node.js and npm installed. (If you have an issue with Node version, 16.14.2 version worked for me)
   ```bash
   npm start
   ```
4. Access the frontend at `http://localhost:3000`.

### Python Microservice (legal-analyzer-microservice)
1. Navigate to the `legal-analyzer-microservice` directory.
2. Create a virtual environment and activate it:
   ```bash
   python -m venv venv
   source venv/bin/activate # On Windows: venv\Scripts\activate
   ```
3. Install dependencies:
   ```bash
   pip install -r requirements.txt
   ```
4. Start the FastAPI server:
   ```bash
   uvicorn main:app --reload --host 0.0.0.0 --port 8001
   ```
5. The microservice will be available at `http://localhost:8001`.

## Usage
1. Start all three components (backend, frontend, and microservice).
2. Use the frontend to upload legal documents.
3. View analyzed results, including extracted entities and clauses.

## Technologies Used
- **Backend**: .NET 9, Entity Framework Core, Swagger
- **Frontend**: React, TailwindCSS
- **Microservice**: FastAPI, Transformers, PDFMiner, python-docx

## Contributing
Contributions are welcome! Please fork the repository and submit a pull request.

## License
This project is licensed under the MIT License.