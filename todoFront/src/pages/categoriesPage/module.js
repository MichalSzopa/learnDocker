import categoriesService from './service';

export default {
    namespaced: true,
    state: {
      data: null,
      loading: false,
    },
    mutations: {
      setData(state, newData) {
        state.data = newData;
      },
      setLoading(state, isLoading) {
        state.loading = isLoading;
      },
    },
    actions: {
      fetchData({ commit }) {
        commit('setLoading', true);
  
        return categoriesService.getCategories()
          .then(response => {
            commit('setData', response.data);
            commit('setLoading', false);
          })
          .catch(error => {
            console.error('Error fetching data:', error);
            commit('setLoading', false);
          });
      },
    },
    getters: {
      getData: state => state.data,
      isLoading: state => state.loading,
    },
  };
  