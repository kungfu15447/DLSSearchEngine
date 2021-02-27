import { useEffect, useState } from 'react';
import { APIDocument } from '../../data/models/document';
import { GetDocumentsByTerm } from '../../data/services/DocumentService';
import './search-page.css';

const SearchPage: React.FC = () => {
  const [documents, setDocuments] = useState<APIDocument[]>([]);
  const [term, setTerm] = useState('');

  const searchDocuments = () => {
    GetDocumentsByTerm(term).then((documents) => {
      setDocuments(documents);
    });
  };

  return (
    <div>
      <h1 className="search-page__title">Zero</h1>
      <input
        className="search-page__input"
        type="text"
        onChange={(event) => setTerm(event.target.value)}
      />
      <button onClick={() => searchDocuments()}>Search</button>
      {documents.map((value, index) => {
        return <div key={index}>{value.title}</div>;
      })}
    </div>
  );
};

export default SearchPage;
