import {apiConfig} from "../../apiConfig";

/**
 * Performs a logout by sending a POST request to the logout endpoint.
 * @returns A promise that resolves to a boolean indicating whether the logout was successful.
 * @throws An error if the request fails or encounters an issue.
 */
export const logoutRequest = async (): Promise<boolean> => {
    const {link, routes} = apiConfig;

    // Create the request options
    const options: RequestInit = {
        method: 'POST',
        credentials: 'include',
    };

    try {
        // Send the request to the logout endpoint
        const response = await fetch(`${link}${routes.logout}`, options);

        // Handle the response status
        return response.ok;
    } catch (error) {
        // Throw an error if the request fails or encounters an issue
        throw new Error(`Logout failed: ${(error as Error).message || 'Unknown error'}`);
    }
};