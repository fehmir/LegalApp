import React, { useEffect, useState } from 'react';
import { fetchDocumentById } from '../services/api';

const DocumentDetails = ({ documentId }) => {
  const [document, setDocument] = useState(null);

  useEffect(() => {
    const loadDocument = async () => {
      try {
        const data = await fetchDocumentById(documentId);
        console.log('Fetched document:', data);
        setDocument(data);
      } catch (error) {
        console.error('Failed to fetch document details:', error);
      }
    };

    if (documentId) {
      loadDocument();
    }
  }, [documentId]);

  if (!document) {
    return <div>Loading document details...</div>;
  }

  return (
    <div className="mt-4">
      <h2 className="text-xl mb-2">Document Details</h2>
      <p><strong>File Name:</strong> {document.fileName}</p>
      <p><strong>File Type:</strong> {document.fileType}</p>
      <p><strong>Uploaded At:</strong> {new Date(document.uploadedAt).toLocaleString()}</p>
      <h3 className="text-lg mt-4">Preview</h3>
      <p>{document.previewText}</p>
      <h3 className="text-lg mt-4">Entities</h3>
      <pre>{JSON.stringify(document.entitiesJson, null, 2)}</pre>
      <h3 className="text-lg mt-4">Clauses</h3>
      <pre>{JSON.stringify(document.clausesJson, null, 2)}</pre>
    </div>
  );
};

export default DocumentDetails;
