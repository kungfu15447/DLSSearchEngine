import React from 'react';
import { Route, BrowserRouter as Router, Switch } from 'react-router-dom';
import './App.css';
import SearchPage from './pages/search-page/search-page';
import SearchedDocumentPage from './pages/searched-document.page/searched-document-page';

function App() {
  return (
    <div className="App">
      <Router>
        <Switch>
          <Route path="/" exact={true} component={SearchPage} />
          <Route path="/search/:term" component={SearchedDocumentPage} />
        </Switch>
      </Router>
    </div>
  );
}

export default App;
