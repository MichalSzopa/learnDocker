export default {
  async getProjects() {
    let projects = null;
    await fetch("http://localhost:5013/projects", {
      method: "GET",
      credentials: "include",
      mode: "cors",
      headers: {
        "Content-Type": "application/json",
      },
    })
      .then(async (response) => {
        if (!response.ok) {
          throw new Error("Network response was not ok");
        }
        projects = await response.json();
      })
      .catch((error) => {
        console.error("There was a problem with the fetch operation:", error);
      });
    return projects;
  },
  async createProject(model) {
    const data = {
      description: model.description,
      title: model.title,
      categoryId: model.categoryId
    };
    await fetch("http://localhost:5013/projects/create", {
      method: "POST",
      credentials: "include",
      mode: "cors",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(data),
    });
  },
  async editProject(model) {
    const data = {
      id: model.id,
      title: model.title,
      description: model.description,
      categoryId: model.categoryId
    };
    await fetch("http://localhost:5013/projects/edit", {
      method: "POST",
      credentials: "include",
      mode: "cors",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(data),
    });
  },
};
