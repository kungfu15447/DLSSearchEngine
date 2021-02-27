import { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import { APIDocument } from '../../data/models/document';
import { GetDocumentsByTerm } from '../../data/services/DocumentService';

const SearchedDocumentPage: React.FC = () => {
  const [document, setDocument] = useState<APIDocument[]>([]);
  const { term } = useParams<{ term: string }>();

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
        <input type="text" value={term} />
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
