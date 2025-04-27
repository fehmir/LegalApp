
import React, { useState } from 'react';
import DocumentUpload from '../components/DocumentUpload';
import DocumentList from '../components/DocumentList';
import DocumentDetails from '../components/DocumentDetails';

const Home = () => {
  const [selectedDocId, setSelectedDocId] = useState(null);
  const [refreshKey, setRefreshKey] = useState(0);

  return (
    <div className="container mx-auto p-4">
      <DocumentUpload onUploadSuccess={() => setRefreshKey(k => k + 1)} />
      <DocumentList key={refreshKey} onSelect={setSelectedDocId} />
      {selectedDocId && <DocumentDetails documentId={selectedDocId} />}
    </div>
  );
};

export default Home;
