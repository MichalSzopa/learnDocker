import categoriesService from "./service";

export default {
  namespaced: true,
  state: {
    categories: null,
    editedCategory: null
  },
  mutations: {
    setCategories(state, newCategories) {
      state.categories = newCategories;
    },
    setEditedCategory(state, newEditedCategory) {
      state.editedCategory = newEditedCategory;
    },
  },
  actions: {
    async fetchCategories({ commit }) {
      const data = await categoriesService.getCategories();
      commit("setCategories", data);
    },
    async createCategory({ commit }, model) {
      await categoriesService.createCategory(model);
      const data = await categoriesService.getCategories();
      commit("setCategories", data);
    },
    async editCategory({ commit }, model) {
      await categoriesService.editCategory(model);
      const data = await categoriesService.getCategories();
      commit("setCategories", data);
    },
  },
  getters: {
    getCategories: (state) => state.categories,
    getEditedCategory: (state) => state.editedCategory,
  },
};
