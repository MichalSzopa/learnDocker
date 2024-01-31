import { createRouter, createWebHistory } from "vue-router";
import CategoriesPage from "./pages/categoriesPage/CategoriesPage.vue";
import TasksPage from "./pages/tasksPage/TasksPage.vue";
import ProjectsPage from "./pages/projectsPage/ProjectsPage.vue";

const routes = [
    {
        name: "CategoriesPage",
        component: CategoriesPage,
        path: "/categories",
    },
    {
        name: "TasksPage",
        component: TasksPage,
        path: "/tasks",
    },
    {
        name: "ProjectsPage",
        component: ProjectsPage,
        path: "/projects",
    }
]

const router = createRouter({
    history: createWebHistory(),
    routes,
});

export default router;