import axios from 'axios';
import { APIDocument } from '../models/document';

export const GetDocumentsByTerm = async (term: string) => {
  const response = await axios.get<APIDocument[]>(
    `https://localhost:5001/search/${term}`
  );

  return response.data;
};
