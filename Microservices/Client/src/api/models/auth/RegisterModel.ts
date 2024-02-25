/**
 * Represents data for user registration.
 */
export interface RegisterModel {
    /**
     * The username chosen by the user for registration.
     */
    userName: string;

    /**
     * The email address provided by the user for registration.
     */
    email: string;

    /**
     * The password chosen by the user for registration.
     */
    password: string;
}
