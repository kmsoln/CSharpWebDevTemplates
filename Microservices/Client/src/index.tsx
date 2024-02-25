import React from 'react';
import ReactDOM from 'react-dom/client';
import {BrowserRouter} from 'react-router-dom';
import Router from "./Router";

const Index = ReactDOM.createRoot(
    document.getElementById('root') as HTMLElement
);
Index.render(
    <React.StrictMode>
        <BrowserRouter>
            <Router/>
        </BrowserRouter>
    </React.StrictMode>
);