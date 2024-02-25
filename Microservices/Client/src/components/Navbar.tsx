import React from 'react';
import NavbarContainer from "./navbar/NavbarContainer";
import NavbarItem from "./navbar/NavbarItem";
import AdminSection from "./navbar/AdminSection";
import AuthenticatedSection from "./navbar/AuthenticatedSection";
import NonAuthenticatedSection from "./navbar/NonAuthenticatedSection";
import useAuth from "../hooks/useAuth";


const Navbar: React.FC = () => {
    
    const auth = useAuth()
    const isAuthenticated = auth.isAuthenticated
    const userName = auth.user?.userName
    
    return (
        <NavbarContainer>
            {/* Brand logo and link to the Home/Index action */}
            <div className="container-fluid">
                <a className="navbar-brand" href="/">ProjectName</a>
                <button className="navbar-toggler" type="button" data-bs-toggle="collapse"
                        data-bs-target=".navbar-collapse" aria-controls="navbarSupportedContent"
                        aria-expanded="false" aria-label="Toggle navigation">
                    <span className="navbar-toggler-icon"></span>
                </button>

                {/* Navbar content with flex layout */}
                <div className="navbar-collapse collapse d-sm-inline-flex justify-content-between">
                    <ul className="navbar-nav flex-grow-1">
                        <NavbarItem label={"Home"} url={"/"}/>
                        {isAuthenticated ? <AdminSection/> : ("")}
                    </ul>
                </div>
            </div>
        </NavbarContainer>
    );
};

export default Navbar;