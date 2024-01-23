import { createRouter, createWebHistory } from "vue-router";
import LoginPage from "./pages/loginPage/LoginPage.vue";
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