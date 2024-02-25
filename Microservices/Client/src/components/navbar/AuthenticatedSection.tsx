import React from 'react';
import NavbarItem from "./NavbarItem";

const AuthenticatedSection: React.FC<{ userName: string }> = ({userName}) => {
    return (
        <>
            <li className="nav-item">
                <span className="nav-link text-dark">Welcome, {userName}</span>
            </li>
            <NavbarItem label={"Profile"} url={"/profile"}/>
            <NavbarItem label={"Logout"} url={"/logout"}/>
        </>
    );
};

export default AuthenticatedSection;