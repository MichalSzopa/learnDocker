import tasksService from "./service";

export default {
  namespaced: true,
  state: {
    tasks: null
  },
  mutations: {
    setTasks(state, newTasks) {
      state.tasks = newTasks;
    },
  },
  actions: {
    async fetchTasks({ commit }) {
      const data = await tasksService.getTasks();
      commit("setTasks", data);
    },
    async createTask({ commit }, model) {
      await tasksService.createTask(model);
      const data = await tasksService.getTasks();
      commit("setTasks", data);
    },
  },
  getters: {
    getTasks: (state) => state.tasks,
  },
};
