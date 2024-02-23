import React from 'react';
import ReactDOM from 'react-dom/client';
import Layout from './components/Layout';

const Index = ReactDOM.createRoot(
  document.getElementById('root') as HTMLElement
);
Index.render(
  <React.StrictMode>
    <Layout />
  </React.StrictMode>
);