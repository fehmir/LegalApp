import axios from 'axios';

const API_BASE_URL = 'https://localhost:7214/api/legaldocuments';

export const uploadDocument = (file) => {
  const formData = new FormData();
  formData.append('file', file);

  return axios.post(`${API_BASE_URL}/upload`, formData, {
    headers: { 'Content-Type': 'multipart/form-data' }
  });
};

export const fetchDocuments = () => {
  return axios.get(`${API_BASE_URL}`, {
    headers: {
      'Content-Type': 'application/json',
    },
  })
  .then(response => response.data) // Return the data
  .catch(error => {
    console.error('Error fetching documents:', error);
    throw error;
  });
};

export const fetchDocumentById = (id) => {
  return axios.get(`${API_BASE_URL}/${id}`, {
    headers: {
      'Content-Type': 'application/json',
    },
  })
  .then(response => response.data) // Return the data
  .catch(error => {
    console.error('Error fetching document by ID:', error);
    throw error;
  });
};

export const updateDocument = (id, document) => {
  return axios.put(`${API_BASE_URL}/${id}`, document, {
    headers: {
      'Content-Type': 'application/json',
    },
  })
  .then(response => response.data)
  .catch(error => {
    console.error('Error updating document:', error);
    throw error;
  });
};

export const deleteDocument = (id) => {
  return axios.delete(`${API_BASE_URL}/${id}`, {
    headers: {
      'Content-Type': 'application/json',
    },
  })
  .then(response => response.data)
  .catch(error => {
    console.error('Error deleting document:', error);
    throw error;
  });
};
