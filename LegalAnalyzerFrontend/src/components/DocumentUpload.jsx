import React, { useState } from 'react';
import { uploadDocument } from '../services/api';

const DocumentUpload = ({ onUploadSuccess }) => {
  const [file, setFile] = useState(null);
  const [error, setError] = useState(null);

  const handleFileChange = (e) => {
    setFile(e.target.files[0]);
  };

  const handleUpload = async () => {
    if (!file) {
      setError('Please select a file to upload.');
      return;
    }

    try {
      const response = await uploadDocument(file);
      onUploadSuccess(response.data);
      setFile(null);
      setError(null);
    } catch (err) {
      console.error('Failed to upload document:', err);
      setError('Failed to upload document. Please try again.');
    }
  };

  return (
    <div className="mt-4">
      <h2 className="text-xl mb-2">Upload a Document</h2>
      <input type="file" onChange={handleFileChange} />
      <button className="ml-2 bg-blue-500 text-white px-4 py-2" onClick={handleUpload}>
        Upload
      </button>
      {error && <p className="text-red-500 mt-2">{error}</p>}
    </div>
  );
};

export default DocumentUpload;
