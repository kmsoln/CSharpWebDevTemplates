import React from 'react';
import NavbarContainer from "./navbar/NavbarContainer";


const Navbar: React.FC = () => {
    
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
            </div>
        </NavbarContainer>
    );
};

export default Navbar;