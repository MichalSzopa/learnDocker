const supertest = require("supertest");

const apiUrl = "http://localhost:5013/";

describe("Categories tests", () => {
  it("should has status code 401", (done) => {
    supertest(apiUrl)
      .get("Categories")
      .expect(401);
      done();
  })

  it('should authenticate the user and set the cookie', (done) => {
    supertest(apiUrl)
      .post('Auth/login')
      .send({
        username: '123',
        password: '123',
      })
      .expect(200);
    done();
  });

  it("should has status code 200", (done) => {
    supertest(apiUrl)
      .get("Categories")
      .expect(200);
    done();
  });
});
