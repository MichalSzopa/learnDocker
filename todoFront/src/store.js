import { createStore } from 'vuex'
import categories from './pages/categoriesPage/module';
import login from './pages/loginPage/module';
// import crypto from './modules/crypto'

const store = createStore({
    modules: {
        categories: categories,
        login: login,
    },
})

export default store;