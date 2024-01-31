<template>
    <v-btn variant="outlined" @click="addTask"> Add task</v-btn>

    <v-list>
        <v-list-item v-for="(item, index) in tasks" :key="index" :value="item">
            <span>{{ item.title }}</span>
            <span> {{ item.description }}</span>
        </v-list-item>
    </v-list>
</template>

<script>
import { mapGetters, mapActions } from 'vuex';

export default {
    name: 'TasksPage',
    data() {
        return {
            tasks: Array[0]
        }
    },
    computed: {
        ...mapGetters('tasks', ['getTasks']),
    },
    methods: {
        ...mapActions('tasks', ['fetchTasks']),

        async addTask() {
            this.$router.push('/add-task');
        },
    },
    async created() {
        await this.fetchTasks();
        this.tasks = this.getTasks;
    },

}
</script>