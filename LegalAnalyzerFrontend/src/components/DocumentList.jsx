import React, { useEffect, useState } from 'react';
import { fetchDocuments, deleteDocument } from '../services/api';

const DocumentList = ({ onSelect }) => {
  const [documents, setDocuments] = useState([]);

  useEffect(() => {
    const load = async () => {
      try {
        const data = await fetchDocuments();
        setDocuments(data);
      } catch (error) {
        console.error('Failed to fetch documents:', error);
      }
    };
    load();
  }, []);

  const handleDelete = async (id) => {
    try {
      await deleteDocument(id);
      setDocuments(documents.filter(doc => doc.id !== id));
    } catch (error) {
      console.error('Failed to delete document:', error);
    }
  };

  return (
    <div className="mt-4">
      <h2 className="text-xl mb-2">Analyzed Documents</h2>
      <ul>
        {documents.map(doc => (
          <li key={doc.id} className="flex justify-between items-center">
            <button className="text-blue-600 underline" onClick={() => onSelect(doc.id)}>
              {doc.fileName}
            </button>
            <button className="text-red-600 underline ml-4" onClick={() => handleDelete(doc.id)}>
              Delete
            </button>
          </li>
        ))}
      </ul>
    </div>
  );
};

export default DocumentList;
