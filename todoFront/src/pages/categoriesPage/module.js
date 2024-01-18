import categoriesService from "./service";

export default {
  namespaced: true,
  state: {
    data: null,
  },
  mutations: {
    setData(state, newData) {
      state.data = newData;
    },
  },
  actions: {
    async fetchData({ commit }) {
      const data = await categoriesService.getCategories();
      commit("setData", data);
    },
    async createCategory({ commit }, model) {
      console.log("model in module:", model);
      await categoriesService.createCategory(model);
      const data = await categoriesService.getCategories();
      commit("setData", data);
    },
  },
  getters: {
    getData: (state) => state.data,
  },
};
