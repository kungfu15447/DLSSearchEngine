import { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import { APIDocument } from '../../data/models/document';
import { GetDocumentsByTerm } from '../../data/services/DocumentService';
import SearchInput from '../../shared/search-input/search-input';
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
        <div className="searched-document-page__header-title">
          <span style={{ color: '#4285F4' }}>Z</span>
          <span style={{ color: '#F4B400' }}>e</span>
          <span style={{ color: '#0F9D58' }}>r</span>
          <span style={{ color: '#DB4437' }}>o</span>
        </div>
        <SearchInput term={searchedInput} setTerm={setSearchedInput} />
      </div>
      <div className="searched-document-page__body">
        {document.map((value, index) => {
          return (
            <div className="searched-document-page__body-row" key={index}>
              <h6>{value.link}</h6>
              <h4>{value.title}</h4>
            </div>
          );
        })}
      </div>
    </div>
  );
};

export default SearchedDocumentPage;
