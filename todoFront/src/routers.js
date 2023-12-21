import { createRouter, createWebHistory } from "vue-router";
import LoginPage from "./pages/loginPage/LoginPage.vue"
import HelloWorld from "./components/HelloWorld.vue"
import UserHomePage from "./pages/userHomePage/UserHomePage.vue"

const routes = [
    {
        name: "LoginPage",
        component: LoginPage,
        path: "/login",
    },
    {
        name: "HelloWorld",
        component: HelloWorld,
        path: "/",
    },
    {
        name: "UserHomePage",
        component: UserHomePage,
        path: "/user-home-page",
    },
]

const router = createRouter({
    history: createWebHistory(),
    routes,
});

export default router;