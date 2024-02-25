import {accountRoutes} from "./routes/auth/accountRoutes";
import {roleRoutes} from "./routes/auth/roleRoutes";
import {userRoutes} from "./routes/auth/userRoutes";
import {projectRoutes} from "./routes/info/projectRoutes";


export const apiConfig = {
    link: 'http://localhost:5101',
    routes: {
        // AuthService
        ...accountRoutes,
        ...roleRoutes,
        ...userRoutes,

        // InfoService
        ...projectRoutes
    },
};
