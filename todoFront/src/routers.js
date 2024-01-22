import { createRouter, createWebHistory } from "vue-router";
import LoginPage from "./pages/loginPage/LoginPage.vue";
import HelloWorld from "./components/HelloWorld.vue";
import UserHomePage from "./pages/userHomePage/UserHomePage.vue";
import CategoriesPage from "./pages/categoriesPage/CategoriesPage.vue";
import AddCategoryPage from "./pages/categoriesPage/AddCategory.vue";
import EditCategoryPage from "./pages/categoriesPage/EditCategory.vue";

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
        path: "/user-home",
    },
    {
        name: "CategoriesPage",
        component: CategoriesPage,
        path: "/categories",
    },
    {
        name: "AddCategoryPage",
        component: AddCategoryPage,
        path: "/add-category",
    },
    {
        name: "EditCategoryPage",
        component: EditCategoryPage,
        path: "/edit-category",
    },
]

const router = createRouter({
    history: createWebHistory(),
    routes,
});

export default router;