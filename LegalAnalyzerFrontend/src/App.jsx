import React, { useState } from 'react';
import DocumentList from './components/DocumentList';
import DocumentDetails from './components/DocumentDetails';
import DocumentUpload from './components/DocumentUpload';

const App = () => {
  const [selectedDocumentId, setSelectedDocumentId] = useState(null);

  const handleDocumentSelect = (id) => {
    setSelectedDocumentId(id);
  };

  const handleUploadSuccess = (newDocument) => {
    alert(`Document uploaded successfully: ${newDocument.fileName}`);
    setSelectedDocumentId(newDocument.id);
  };

  return (
    <div className="container mx-auto p-4">
      <h1 className="text-2xl font-bold mb-4">Legal Document Analyzer</h1>
      <DocumentUpload onUploadSuccess={handleUploadSuccess} />
      <DocumentList onSelect={handleDocumentSelect} />
      {selectedDocumentId && <DocumentDetails documentId={selectedDocumentId} />}
    </div>
  );
};

export default App;
