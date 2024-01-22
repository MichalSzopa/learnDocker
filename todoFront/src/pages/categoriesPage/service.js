export default {
  async getCategories() {
    let categories = null;
    await fetch("http://localhost:5013/categories", {
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
        categories = await response.json();
      })
      .catch((error) => {
        console.error("There was a problem with the fetch operation:", error);
      });
    return categories;
  },
  async createCategory(model) {
    const data = {
      description: model.description,
      color: model.color
    };
    await fetch("http://localhost:5013/categories/create", {
      method: "POST",
      credentials: "include",
      mode: "cors",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(data),
    });
  },
  async editCategory(model) {
    const data = {
      id: model.id,
      description: model.description,
      color: model.color
    };
    await fetch("http://localhost:5013/categories/edit", {
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
