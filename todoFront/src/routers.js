import { createRouter, createWebHistory } from "vue-router";
import CategoriesPage from "./pages/categoriesPage/CategoriesPage.vue";
import AddCategoryPage from "./pages/categoriesPage/AddCategory.vue";
import EditCategoryPage from "./pages/categoriesPage/EditCategory.vue";
import TasksPage from "./pages/tasksPage/TasksPage.vue"

const routes = [
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
    {
        name: "TasksPage",
        component: TasksPage,
        path: "/tasks",
    },
]

const router = createRouter({
    history: createWebHistory(),
    routes,
});

export default router;