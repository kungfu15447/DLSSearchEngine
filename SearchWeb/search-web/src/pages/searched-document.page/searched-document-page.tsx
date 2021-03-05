import { useEffect, useState } from 'react';
import { useHistory, useParams } from 'react-router-dom';
import { APIDocument } from '../../data/models/document';
import { GetDocumentsByTerm } from '../../data/services/DocumentService';
import SearchInput from '../../shared/search-input/search-input';
import './searched-document-page.css';

const SearchedDocumentPage: React.FC = () => {
  const [document, setDocument] = useState<APIDocument[]>([]);
  const [searchedInput, setSearchedInput] = useState('');
  const { term } = useParams<{ term: string }>();
  const history = useHistory();

  const getDocuments = (term?: string) => {
    let searchTerm = '';
    if (term) {
      searchTerm = term;
    } else {
      searchTerm = searchedInput;
    }
    if (searchTerm.length !== 0) {
      history.push('/');
      history.push(`search/${searchTerm}`);
    }
  };

  useEffect(() => {
    setSearchedInput(term);
  }, []);

  useEffect(() => {
    GetDocumentsByTerm(term)
      .then((list) => {
        setDocument(list);
      })
      .catch(() => {
        setDocument([]);
      });
  }, []);

  return (
    <div>
      <div className="searched-document-page__header">
        <div
          className="searched-document-page__header-title"
          onClick={() => history.push('/')}
        >
          <span style={{ color: '#4285F4' }}>Z</span>
          <span style={{ color: '#F4B400' }}>e</span>
          <span style={{ color: '#0F9D58' }}>r</span>
          <span style={{ color: '#DB4437' }}>o</span>
        </div>
        <SearchInput
          term={searchedInput}
          setTerm={setSearchedInput}
          searchDocuments={getDocuments}
        />
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
        {document.length === 0 && (
          <div className="searched-document-page__body-no-result">
            <span>Your search word - </span>
            <span style={{ fontWeight: 'bold' }}>{term}</span>
            <span> - did not match any documents</span>
            <h4 />
            <span>Recommendations:</span>
            <ul>
              <li>Make sure that all words are spelled correctly</li>
              <li>Try different search words</li>
              <li>Try more general search words</li>
            </ul>
          </div>
        )}
      </div>
    </div>
  );
};

export default SearchedDocumentPage;
