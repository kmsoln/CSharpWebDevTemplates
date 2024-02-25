import React from 'react';
import {Route, Routes} from 'react-router-dom';
import Home from "./pages/home/Home";
import LoginForm from "./pages/account/LoginForm";

function Router() {
    return (
        <Routes>
            <Route path="/" element={<Home/>}/>
        </Routes>
    );
}

export default Router;