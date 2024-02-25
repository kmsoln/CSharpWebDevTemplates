import React, {ReactNode} from 'react';

interface NavbarDropdownProps {
    label: string;
    children: ReactNode;
}

/**
 * Represents a dropdown element in the navigation bar.
 * @component
 * @param {Object} props - Component properties.
 * @param {string} props.label - The label or text content of the dropdown.
 * @param {ReactNode} props.children - The child elements placed inside the NavbarDropdown.
 */
const NavbarDropdown: React.FC<NavbarDropdownProps> = ({label, children}) => {
    return (
        <li className="nav-item dropdown">
            <button
                className="nav-link dropdown-toggle"
                type="button"
                id="navbarDropdown"
                data-bs-toggle="dropdown"
                aria-haspopup="true"
                aria-expanded="false"
            >
                {label}
            </button>
            <div className="dropdown-menu" aria-labelledby="navbarDropdown">
                {children}
            </div>
        </li>
    );
};

export default NavbarDropdown;
