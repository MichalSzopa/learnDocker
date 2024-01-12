import loginService from './service'

export default {
    namespaced: true,
    state: {
      loggedIn: false
    },
    mutations: {
      onLoggedIn(state) {
        state.loggedIn = true;
      },
      onLoggedOut(state) {
        state.loggedIn = false;
      }
    },
    actions: {
      async logIn({ commit }, data) {
        await loginService.login(data.username, data.password)
          .then(response => {
            commit('onLoggedIn');
            console.log(response); //TODO
          })
          .catch(error => {
            console.error('Error fetching data:', error);
          });
      },
    },
    getters: {
      isLoggedIn: state => state.loggedIn
    },
  };