<template>
  <div class="hello">
    <img alt="Vue logo" src="../assets/logo.png">
    <h1>{{ jajko }}</h1>
    <p>
      <router-link to="/login"> Login </router-link>
    </p>
  </div>
</template>

<script>

export default {
  name: 'HelloWorld',
  props: {
    msg: String
  },
  data() {
    return {
      jajko: 'abc',
    }
  },
  methods: {
    async fetchForecast() {
      try {
        const response = await fetch('http://localhost:5013/WeatherForecast');
        const data = await response.json();
        this.jajko = data[0].date;
      }
      catch
      {
        console.log('kacz');
      }
    }
  },
  async mounted() {
    this.fetchForecast();
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
h3 {
  margin: 40px 0 0;
}
ul {
  list-style-type: none;
  padding: 0;
}
li {
  display: inline-block;
  margin: 0 10px;
}
a {
  color: #42b983;
}
</style>
