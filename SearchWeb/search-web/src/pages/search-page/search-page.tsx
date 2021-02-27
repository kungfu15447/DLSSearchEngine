import { useState } from 'react';
import { useHistory } from 'react-router-dom';
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
    </div>
  );
};

export default SearchPage;
