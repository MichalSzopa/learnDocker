export default {
  async getTasks() {
    let tasks = null;
    await fetch("http://localhost:5013/tasks", {
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
        tasks = await response.json();
      })
      .catch((error) => {
        console.error("There was a problem with the fetch operation:", error);
      });
    return tasks;
  },
  async createTask(model) {
    const data = {
      title: model.title,
      description: model.description,
      isRecurring: model.isRecurring,
      repetition: null, // TODO repetition
      eventDate: model.eventDate,
      time: model.time,
      categoryId: 3, // TODO category
      priority: null, // TODO priority
      parentId: null, // TODO parent task
      projectId: null, // TODO project
    };
    await fetch("http://localhost:5013/tasks/create", {
      method: "POST",
      credentials: "include",
      mode: "cors",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(data),
    });
  },
  async editTask(model) {
    const data = {
      // TODO
      id: model.id,
      description: model.description,
      color: model.color,
    };
    await fetch("http://localhost:5013/tasks/edit", {
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
