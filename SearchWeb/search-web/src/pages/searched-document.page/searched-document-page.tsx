import { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import { APIDocument } from '../../data/models/document';
import { GetDocumentsByTerm } from '../../data/services/DocumentService';
import './searched-document-page.css';

const SearchedDocumentPage: React.FC = () => {
  const [document, setDocument] = useState<APIDocument[]>([]);
  const [searchedInput, setSearchedInput] = useState('');
  const { term } = useParams<{ term: string }>();

  const getDocuments = (term?: string) => {
    let searchTerm = '';
    if (term) {
      searchTerm = term;
    } else {
      searchTerm = searchedInput;
    }

    GetDocumentsByTerm(searchTerm)
      .then((list) => {
        setDocument(list);
      })
      .catch(() => {
        setDocument([]);
      });
  };

  useEffect(() => {
    setSearchedInput(term);
  }, []);

  useEffect(() => {
    getDocuments(term);
  }, []);
  return (
    <div>
      <div className="searched-document-page__header">
        <input
          type="text"
          value={searchedInput}
          onChange={(event) => setSearchedInput(event.target.value)}
        />
      </div>
      <div className="searched-document-page__body">
        {document.map((value, index) => {
          return (
            <div className="searched-document-page__body-row" key={index}>
              <h4>{value.title}</h4>
              <h4>{value.link}</h4>
              <h4>{value.date}</h4>
            </div>
          );
        })}
      </div>
    </div>
  );
};

export default SearchedDocumentPage;
