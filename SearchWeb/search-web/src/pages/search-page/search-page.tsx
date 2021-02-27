import { useEffect, useState } from 'react';
import { APIDocument } from '../../data/models/document';
import { GetDocumentsByTerm } from '../../data/services/DocumentService';
import './search-page.css';

const SearchPage: React.FC = () => {
  const [documents, setDocuments] = useState<APIDocument[]>([]);
  const [term, setTerm] = useState('');

  const searchDocuments = () => {
    if (term.length !== 0) {
      GetDocumentsByTerm(term)
        .then((documents) => {
          setDocuments(documents);
        })
        .catch(() => {
          setDocuments([]);
        });
    }
  };

  return (
    <div className="search-page">
      <div className="search-page__title">
        <span style={{ color: '#4285F4' }}>Z</span>
        <span style={{ color: '#F4B400' }}>E</span>
        <span style={{ color: '#0F9D58' }}>R</span>
        <span style={{ color: '#DB4437' }}>O</span>
      </div>
      <div className="search-page__input-container">
        <input
          className="search-page__input"
          type="text"
          onChange={(event) => setTerm(event.target.value)}
        />
      </div>
      <button
        className="search-page__search-button"
        onClick={() => searchDocuments()}
      >
        Search
      </button>
      {documents.map((value, index) => {
        return <div key={index}>{value.title}</div>;
      })}
    </div>
  );
};

export default SearchPage;
