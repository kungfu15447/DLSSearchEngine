import { useEffect, useState } from 'react';
import { useHistory } from 'react-router-dom';
import { SearchStatement } from '../../data/models/searchstatement';
import { getHistory, addStatement } from '../../data/services/HistoryService';
import './search-input.css';

interface IProps {
  term?: string;
  setTerm(term: string): void;
  showButtons?: boolean;
  searchDocuments(pTerm?: string): void;
}

const SearchInput: React.FC<IProps> = ({
  term = '',
  setTerm,
  showButtons = false,
  searchDocuments,
}) => {
  const [termHistory, setTermHistory] = useState<SearchStatement[]>([]);
  const [showHistory, setShowHistory] = useState(false);

  useEffect(() => {
    getHistory().then((list) => {
      setTermHistory(list);
    });
  }, []);

  const onSearchDocuments = (pterm?: string) => {
    let dterm = '';
    if (pterm) {
      dterm = pterm;
    } else {
      dterm = term;
    }
    addStatement(dterm).then((response) => {
      const index = termHistory.findIndex((r) => r.id === response.id);
      if (index === -1) {
        termHistory.unshift(response);
      } else {
        const newList = termHistory.filter((r) => r.id !== response.id);
        newList.unshift(response);
        setTermHistory(newList);
      }
      searchDocuments(dterm);
    });
  };

  return (
    <div className="search-input-container">
      <input
        className="search-input"
        type="text"
        value={term}
        onChange={(event) => setTerm(event.target.value)}
        onClick={() => setShowHistory(!showHistory)}
      />
      {!showHistory && showButtons && (
        <div>
          <button
            className="search-input__search-button"
            onClick={() => onSearchDocuments()}
          >
            Search
          </button>
        </div>
      )}
      {showHistory && (
        <div className="search-history-container">
          {termHistory.map((value, index) => {
            return (
              <div key={index} className="search-history-container-row">
                <div
                  className="search-history-container-row__text"
                  onClick={() => onSearchDocuments(value.statement)}
                >
                  {value.statement}
                </div>
                <span className="search-history-container-row__remove">
                  Remove
                </span>
              </div>
            );
          })}
        </div>
      )}
    </div>
  );
};

export default SearchInput;
