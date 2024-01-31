import projectsService from "./service";

export default {
  namespaced: true,
  state: {
    projects: null,
    editedProject: null
  },
  mutations: {
    setProjects(state, newProjects) {
      state.projects = newProjects;
    },
    setEditedProject(state, newEditedProject) {
      state.editedProject = newEditedProject;
    },
  },
  actions: {
    async fetchProjects({ commit }) {
      const data = await projectsService.getProjects();
      commit("setProjects", data);
    },
    async createProject({ commit }, model) {
      await projectsService.createProject(model);
      const data = await projectsService.getProjects();
      commit("setProjects", data);
    },
    async editProject({ commit }, model) {
      await projectsService.editProject(model);
      const data = await projectsService.getProjects();
      commit("setProjects", data);
    },
  },
  getters: {
    getProjects: (state) => state.projects,
    getEditedProject: (state) => state.editedProject,
  },
};
