import {RegisterModel} from "../../models/auth/RegisterModel";
import {apiConfig} from "../../apiConfig";

/**
 * Handles the registration functionality by sending a POST request to the registration endpoint.
 * @param model - The registration data model containing username, email, password, etc.
 * @returns A Promise that resolves to an object with `success` indicating whether registration
 *          was successful, and `data` or `errors` containing the response data or errors, respectively.
 */
export const registerRequest = async (
    model: RegisterModel,
): Promise<{
    success: boolean,
    data?: any,
    errors?: any
}> => {
    const {link, routes} = apiConfig;

    const options = {
        method: 'POST',
        headers: {
            'accept': '*/*',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(model),
    };

    try {
        const response = await fetch(`${link}${routes.register}`, options);

        if (response.ok) {
            // Registration was successful
            return {success: true, data: await response.json()};
        } else {
            // Registration failed, return errors
            const errorData = await response.json();
            return {success: false, errors: errorData};
        }
    } catch (error) {
        console.error('Error during registration:', error);
        return {success: false, errors: ['An error occurred during registration.']};
    }
};
