import { useEffect, useState } from 'react';
import { SearchStatement } from '../../data/models/searchstatement';
import { getHistory } from '../../data/services/HistoryService';
import './search-input.css';

interface IProps {
  term?: string;
  setTerm(term: string): void;
}

const SearchInput: React.FC<IProps> = ({ term = '', setTerm }) => {
  const [history, setHistory] = useState<SearchStatement[]>([]);

  useEffect(() => {
    getHistory().then((list) => {
      setHistory(list);
    });
  }, []);

  return (
    <div className="search-input-container">
      <input
        className="search-input"
        type="text"
        value={term}
        onChange={(event) => setTerm(event.target.value)}
      />
      <div className="search-history-container">
        {history.map((value, index) => {
          return (
            <div key={index} className="search-history-container-row">
              <div className="search-history-container-row__text">
                {value.statement}
              </div>
              <span className="search-history-container-row__remove">
                Remove
              </span>
            </div>
          );
        })}
      </div>
    </div>
  );
};

export default SearchInput;
