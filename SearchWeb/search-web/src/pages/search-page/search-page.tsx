import { useState } from 'react';
import { useHistory } from 'react-router-dom';
import SearchInput from '../../shared/search-input/search-input';
import './search-page.css';

const SearchPage: React.FC = () => {
  const [term, setTerm] = useState('');
  const history = useHistory();

  const searchDocuments = () => {
    if (term.length !== 0) {
      history.push(`search/${term}`);
    }
  };

  return (
    <div className="search-page">
      <div className="search-page__title">
        <span style={{ color: '#4285F4' }}>Z</span>
        <span style={{ color: '#F4B400' }}>e</span>
        <span style={{ color: '#0F9D58' }}>r</span>
        <span style={{ color: '#DB4437' }}>o</span>
      </div>
      <div className="search-page__input-container">
        <SearchInput setTerm={setTerm} term={term} />
      </div>
      <button
        className="search-page__search-button"
        onClick={() => searchDocuments()}
      >
        Search
      </button>
    </div>
  );
};

export default SearchPage;
