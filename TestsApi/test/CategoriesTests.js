const supertest = require("supertest");

const apiUrl = "http://localhost:5013/";

describe("Categories tests", async () => {

  let authCookie = '';
  it('1 should has status code 401', async () => {
    await supertest(apiUrl)
      .get('Categories')
      .expect(401);
  })

  it('2 should authenticate the user and set the cookie', async () => {
    const loginResponse = await supertest(apiUrl)
      .post('Auth/login')
      .send({
        username: '123',
        password: '123',
      })
      .expect(200);

    authCookie = loginResponse.headers['set-cookie'][0];
  });

  it('3 should has status code 200', async () => {
    await supertest(apiUrl)
      .get('Categories')
      .set('Cookie', [authCookie])
      .expect(200);
  });
});
