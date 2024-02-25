import React from 'react';
import NavbarItem from "./NavbarItem";

const NonAuthenticatedSection: React.FC = () => {
    return (
        <>
            <NavbarItem label={"Login"} url={"/login"}/>
            <NavbarItem label={"Register"} url={"/register"}/>
        </>
    );
};

export default NonAuthenticatedSection;