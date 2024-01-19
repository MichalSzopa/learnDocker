const supertest = require("supertest");
const assert = require("assert");

const apiUrl = "http://localhost:5013/";

describe("GET /WeatherForecast", function () {
  it("should has status code 200", function (done) {
    supertest(apiUrl)
      .get("WeatherForecast")
      .expect(200);
      done();
  });
});

describe("GET /Categories", function () {
  it("should has status code 401", function (done) {
    supertest(apiUrl)
      .get("Categories")
      .expect(401);
      done();
  });
});
