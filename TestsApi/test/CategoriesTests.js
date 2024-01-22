const supertest = require("supertest");
const assert = require("assert");

const apiUrl = "http://localhost:5013/";

describe("Categories tests", async () => {
  let authCookie = "";
  const categoryToCreate = {
    description: "category created by supertest",
    color: 1,
  };
  const editedCategory = {
    description: "editedDescription",
    color: 2,
  };
  let specificCategoryReceivedFromBackend = null;

  it("Should has status code 401", async () => {
    await supertest(apiUrl).get("Categories").expect(401);
  });

  it("Should authenticate the user and set the cookie", async () => {
    const loginResponse = await supertest(apiUrl)
      .post("Auth/login")
      .send({
        username: "123",
        password: "123",
      })
      .expect(200);

    authCookie = loginResponse.headers["set-cookie"][0];
    assert.ok(authCookie !== null);
  });

  it("Should get three predefined categories", async () => {
    const response = await supertest(apiUrl)
      .get("Categories")
      .set("Cookie", authCookie)
      .expect(200);

    assert.ok(response.body !== null);
    assert.ok(response.body.length === 3);
    assert.ok(
      response.body.some((category) => category.description === "Work")
    );
    assert.ok(
      response.body.every((category) => category.isPredefined === true)
    );
  });

  it("Should create a new category", async () => {
    await supertest(apiUrl)
      .post("Categories/create")
      .set("Cookie", authCookie)
      .send(categoryToCreate)
      .expect(200);
  });

  it("Should check if the new category is added", async () => {
    const response = await supertest(apiUrl)
      .get("Categories")
      .set("Cookie", authCookie)
      .expect(200);

    assert.ok(response.body !== null);
    assert.ok(response.body.length === 4);
    assert.ok(
      response.body.some(
        (category) =>
          category.description === categoryToCreate.description &&
          category.color === categoryToCreate.color &&
          category.isPredefined === false
      )
    );

    specificCategoryReceivedFromBackend = response.body.find(
      (category) =>
        category.description === categoryToCreate.description &&
        category.color === categoryToCreate.color &&
        category.isPredefined === false
    );
  });

  it("Should get specific category, added previously", async () => {
    const response = await supertest(apiUrl)
      .get(`Categories/${specificCategoryReceivedFromBackend.id.toString()}`)
      .set("Cookie", authCookie)
      .expect(200);

    assert.ok(response.body !== null);
    assert.ok(
      response.body.description === categoryToCreate.description &&
        response.body.color === categoryToCreate.color
    );
  });

  it("Should edit category added previously", async () => {
    const newCategory = {
      id: specificCategoryReceivedFromBackend.id,
      description: editedCategory.description,
      color: editedCategory.color,
    };

    await supertest(apiUrl)
      .post('Categories/edit')
      .set('Cookie', authCookie)
      .send(newCategory)
      .expect(200);
  })

  it("Should get specific category, edited previously", async () => {
    const response = await supertest(apiUrl)
      .get(`Categories/${specificCategoryReceivedFromBackend.id.toString()}`)
      .set("Cookie", authCookie)
      .expect(200);

    assert.ok(response.body !== null);
    assert.ok(
      response.body.description === editedCategory.description &&
        response.body.color === editedCategory.color
    );
  });

  it("Should delete specific category, added previously", async () => {
    await supertest(apiUrl)
      .delete(`Categories?categoryId=${specificCategoryReceivedFromBackend.id.toString()}`)
      .set("Cookie", authCookie)
      .expect(200);
  });

  it("Should get three predefined categories after the new one has been deleted", async () => {
    const response = await supertest(apiUrl)
      .get("Categories")
      .set("Cookie", authCookie)
      .expect(200);

    assert.ok(response.body !== null);
    assert.ok(response.body.length === 3);
    assert.ok(
      response.body.some((category) => category.description === "Work")
    );
    assert.ok(
      response.body.every((category) => category.isPredefined === true)
    );
  });
});
