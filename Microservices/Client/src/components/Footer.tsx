import React, {useEffect, useState } from 'react';
import {GetProjectInfoRequest} from "../api/requests/info/GetProjectInfoRequest";


const Footer: React.FC = () => {
    const [projectInfo, setProjectInfo] = useState({
        projectName: 'rr',
        studentName: 'ee',
        studentGroup: 'ee'
    });

    useEffect(() => {
        const fetchData = async () => {
            try {
                const response = await GetProjectInfoRequest();
                setProjectInfo(response);
            } catch (error) {
                console.error('Error fetching project info:', error);
                // Handle the error as needed
            }
        };

        fetchData();
    }, []);

    // Get current year
    const currentYear = new Date().getFullYear();

    return (
        <footer className="container">
            {/* Copyright notice and project information */}
            &copy; {currentYear} - {projectInfo.projectName} | {projectInfo.studentName} ({projectInfo.studentGroup})
        </footer>
    );
};

export default Footer;
