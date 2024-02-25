import React, {ReactNode} from 'react';

interface NavbarContainerProps {
    children: ReactNode;
}

/**
 * Represents a container for the navigation bar.
 * @component
 * @param {Object} props - Component properties.
 * @param {ReactNode} props.children - The child elements placed inside the NavbarContainer.
 */
const NavbarContainer: React.FC<NavbarContainerProps> = ({children}) => {
    return (
        <nav
            className="navbar navbar-expand-sm navbar-toggleable-sm navbar-light bg-white border-bottom box-shadow mb-3">
            {children}
        </nav>
    );
};

export default NavbarContainer;