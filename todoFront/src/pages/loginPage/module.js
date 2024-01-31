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
          .then(() => {
            commit('onLoggedIn');
          });
      },
      async checkIfLoggedIn({ commit }) {
        const response = await loginService.checkIfLoggedIn();
        if (response.loggedIn === true) {
          commit('onLoggedIn');
        }
        else {
          commit('onLoggedOut');
        }
      }
    },
    getters: {
      isLoggedIn: state => state.loggedIn
    },
  };