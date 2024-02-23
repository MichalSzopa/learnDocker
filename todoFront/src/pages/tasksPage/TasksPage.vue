<template>
    <v-btn variant="outlined" @click="addTask"> Add task</v-btn>

    <v-list>
        <v-list-item v-for="(item, index) in tasks" :key="index" :value="item">
            <span>{{ item.title }}</span>
            <span> {{ item.description }}</span>
        </v-list-item>
    </v-list>

    <myDialog v-model="showDialog" @closeDialog="onDialogClosed"/>
</template>

<script>
import { mapGetters, mapActions } from 'vuex';
import myDialog from './components/AddTask.vue'

export default {
    name: 'TasksPage',
    components: {
        myDialog,
    },
    data() {
        return {
            tasks: Array[0],
            showDialog: false,
        }
    },
    computed: {
        ...mapGetters('tasks', ['getTasks']),
    },
    methods: {
        ...mapActions('tasks', ['fetchTasks']),

        async addTask() {
            this.showDialog = true;
        },
        async onDialogClosed() {
            this.showDialog = false;
            this.fetchTasks();
            this.tasks = this.getTasks;
        }
    },
    async created() {
        await this.fetchTasks();
        this.tasks = this.getTasks;
    },

}
</script>