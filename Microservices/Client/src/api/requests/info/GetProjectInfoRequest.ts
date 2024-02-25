import {ProjectInfoModel} from "../../models/info/ProjectInfoModel";
import {apiConfig} from "../../apiConfig";

export const GetProjectInfoRequest = async (): Promise<ProjectInfoModel> => {
    const { link, routes } = apiConfig;

    // Create the request options
    const options: RequestInit = {
        method: 'GET',
        headers: {
            accept: '*/*',
            'Content-Type': 'application/json',
        },
        credentials: 'include',
    };

    // Send the request to the login endpoint
    try {
        const response = await fetch(`${link}${routes.getProjectInfo}`, options);

        if (response.ok) {
            return response.json() as Promise<ProjectInfoModel>;
        } else {
            console.error(`Request failed with status ${response.status}`);
            console.error(await response.text());
            throw new Error(`Request failed with status ${response.status}`);
        }
    } catch (error) {
        console.error('Error:', error);
        throw new Error('Error occurred during the request');
    }
};
