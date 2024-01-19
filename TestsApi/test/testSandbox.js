const supertest = require("supertest");

const apiUrl = "http://localhost:5013/";

describe("GET /WeatherForecast", () => {
  it("should has status code 200", (done) => {
    supertest(apiUrl)
      .get("WeatherForecast")
      .expect(200);
      done();
  });
});

describe("GET /Categories", () => {
  it("should has status code 401", (done) => {
    supertest(apiUrl)
      .get("Categories")
      .expect(401);
      done();
  });
});
