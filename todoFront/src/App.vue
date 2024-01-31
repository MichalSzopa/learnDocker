<template>
  <LoginPage v-if="!this.isLoggedIn" />
  <v-container v-if="this.isLoggedIn">
    <v-row>
      <v-col class="d-flex">
        <NavigationComponent />
      </v-col>
      <v-col class="w-100 d-flex">
        <router-view />
      </v-col>
    </v-row>
  </v-container>
</template>

<script>
import NavigationComponent from './components/NavigationComponent.vue'
import LoginPage from "./pages/loginPage/LoginPage.vue";
import { mapGetters, mapActions } from 'vuex';
export default {
  name: 'App',
  components: {
    NavigationComponent,
    LoginPage,
  },
  computed: {
    ...mapGetters('login', ['isLoggedIn']),
    ...mapActions('login', ['checkIfLoggedIn']),
  },
  async created() {
    await this.checkIfLoggedIn;
  }
}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
