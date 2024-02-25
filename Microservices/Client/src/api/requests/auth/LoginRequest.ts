import {LoginModel} from "../../models/auth/LoginModel";
import {ApplicationUser} from "../../../auth/ApplicationUser";
import {apiConfig} from "../../apiConfig";
interface Logger {
    error(message: string, data?: any): void;
}

const logger: Logger = {
    error(message, data) {
        // Replace this with your actual logging mechanism
        console.error(`[Error] ${message}`, data);
    },
};

/**
 * Handles the login functionality by sending a POST request to the login endpoint.
 * @param model - The login data model containing email, password, etc.
 * @returns A Promise that resolves to the user data if login is successful, or false otherwise.
 */
export const loginRequest = async (
    model: LoginModel
): Promise<ApplicationUser | false> => {
    const { link, routes } = apiConfig; // Simplified destructuring assignment

    // Create the request options
    const options: RequestInit = {
        method: 'POST',
        headers: {
            'accept': '*/*',
            'Content-Type': 'application/json',
        },
        credentials: 'include',
        body: JSON.stringify(model),
    };

    // Send the request to the login endpoint
    try {
        const authenticated = await fetch(`${link}${routes.login}`, options);

        if (authenticated.ok) {
            console.log("user: " + authenticated.body)
            return await authenticated.json() as ApplicationUser;
        } else {
            logger.error(`Request failed with status ${authenticated.status}`, {
                responseText: await authenticated.text(),
            });
            return false;
        }
    } catch (error) {
        logger.error('Error:', error);
        return false;
    }
};