<template>
    <v-card>
      <v-layout>
        <v-navigation-drawer
          v-model="drawer"
          :rail="rail"
          permanent
        >
          <v-list-item
            prepend-avatar="https://upload.wikimedia.org/wikipedia/commons/thumb/9/95/Vue.js_Logo_2.svg/1280px-Vue.js_Logo_2.svg.png"
            title="Todo App"
            nav
            @click="rail = false"
          >
            <template v-slot:append>
              <v-btn
                variant="text"
                icon="mdi-chevron-left"
                @click.stop="rail = true"
              ></v-btn>
            </template>
          </v-list-item>
  
          <v-divider></v-divider>
  
          <v-list density="compact" nav>
            <v-list-item prepend-icon="mdi-home-city" title="Tasks" value="home" @click="onTasksClick"></v-list-item>
            <v-list-item prepend-icon="mdi-account" title="Projects" value="account" @click="onProjectsClick"></v-list-item>
            <v-list-item prepend-icon="mdi-account-group-outline" title="Categories" value="users" @click="onCategoriesClick"></v-list-item>
          </v-list>
        </v-navigation-drawer>
        <v-main style="height: 250px"></v-main>
      </v-layout>
    </v-card>
  </template>

<script>
  export default {
    name: 'NavigationComponent',
    data () {
      return {
        drawer: true,
        rail: false,
      }
    },
    methods: {
      async onCategoriesClick() {
        this.rail = true;
        this.$router.push('/categories');
      },
      async onTasksClick() {
        this.rail = true;
        this.$router.push('/tasks');
      },
      async onProjectsClick() {
        this.rail = true;
        // this.$router.push('/projects');
      },
    }
  }
</script>
