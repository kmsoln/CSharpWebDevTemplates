import React from 'react';

interface NavbarItemProps {
    label: string;
    url: string;
}

/**
 * Represents a navigation item in the navbar.
 * @component
 * @param {Object} props - Component properties.
 * @param {string} props.label - The label or text content of the navigation item.
 * @param {string | undefined} props.url - The URL to navigate to. If undefined, the item becomes a button.
 */
const NavbarItem: React.FC<NavbarItemProps> = ({label, url}) => {
    // If there is a valid URL, use an anchor tag
    if (url) {
        return (
            <a className="nav-link text-dark" href={url}>
                {label}
            </a>
        );
    }

    // If there is no URL, use a button styled as a link
    return (
        <button type="button" className="nav-link text-dark" onClick={() => {
        }}>
            {label}
        </button>
    );
};

export default NavbarItem;