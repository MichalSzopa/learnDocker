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
    console.log('model in service:', model);
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
    console.log('add category service 2');
  },
};
