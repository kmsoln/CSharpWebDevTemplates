import React from 'react';
import NavbarDropdown from './NavbarDropdown';
import NavbarItem from './NavbarItem';

const AdminSection: React.FC = () => {
    return (
        <NavbarDropdown label="Admin">
            <NavbarItem label="Users" url="/admin/users"/>
            <NavbarItem label="Roles" url="/admin/roles"/>
        </NavbarDropdown>
    );
};

export default AdminSection;