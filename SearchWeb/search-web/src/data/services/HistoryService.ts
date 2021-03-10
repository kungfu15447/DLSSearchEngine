import axios from 'axios';
import { SearchStatement } from '../models/searchstatement';

const route = 'https://localhost:6001/load/history';

export const getHistory = async () => {
  const response = await axios.get<SearchStatement[]>(route);
  return response.data;
};

export const addStatement = async (
  statement: string
): Promise<SearchStatement> => {
  const response = await axios.post<SearchStatement>(route, {
    statement: statement,
  });

  return response.data;
};

export const removeStatement = async (statementId: number) => {
  await axios.delete(`${route}/${statementId}`);
};
