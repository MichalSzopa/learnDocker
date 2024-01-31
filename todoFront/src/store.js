import { createStore } from 'vuex'
import categories from './pages/categoriesPage/module';
import login from './pages/loginPage/module';
import tasks from './pages/tasksPage/module';
import projects from './pages/projectsPage/module';

const store = createStore({
    modules: {
        categories: categories,
        login: login,
        tasks: tasks,
        projects: projects,
    },
})

export default store;