import './search-input.css';

interface IProps {
  term?: string;
  setTerm(term: string): void;
}

const SearchInput: React.FC<IProps> = ({ term = '', setTerm }) => {
  return (
    <div className="search-input-container">
      <input
        className="search-input"
        type="text"
        value={term}
        onChange={(event) => setTerm(event.target.value)}
      />
      <div></div>
    </div>
  );
};

export default SearchInput;
