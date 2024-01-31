import { createStore } from 'vuex'
import categories from './pages/categoriesPage/module';
import login from './pages/loginPage/module';
import tasks from './pages/tasksPage/module'

const store = createStore({
    modules: {
        categories: categories,
        login: login,
        tasks: tasks,
    },
})

export default store;