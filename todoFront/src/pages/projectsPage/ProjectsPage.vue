<template>
    <AddProject v-if="adding === true" @addingFinished="returnToMainView" />
    <EditProject v-else-if="editing === true" @editingFinished="returnToMainView" />

    <div v-else>
        <v-btn variant="outlined" @click="addProject"> Add project</v-btn>

        <v-list>
            <v-list-item v-for="(item, index) in projects" :key="index" :value="item">
                <span>{{ item.description }}</span>
                <template v-slot:append>
                    <v-btn variant="text" icon="mdi-pencil" @click="editProject(item)"></v-btn>
                </template>
            </v-list-item>
        </v-list>
    </div>
</template>

<script>
import { mapGetters, mapActions, mapMutations } from 'vuex';
import AddProject from './AddProject.vue';
import EditProject from './EditProject.vue';

export default {
    name: 'ProjectsPage',
    data() {
        return {
            projects: Array[0],
            adding: false,
            editing: false,
        }
    },
    components: {
        AddProject,
        EditProject,
    },
    computed: {
        ...mapGetters('projects', ['getProjects']),
    },
    methods: {
        ...mapActions('projects', ['fetchProjects']),
        ...mapMutations('projects', ['setEditedProject']),

        async addProject() {
            this.adding = true;
        },
        async editProject(project) {
            this.setEditedProject(project);
            this.editing = true;
        },
        async returnToMainView() {
            await this.fetchProjects();
            this.projects = this.getProjects;
            this.adding = false;
            this.editing = false;
        }
    },
    async created() {
        await this.fetchProjects();
        this.projects = this.getProjects;
    },

}
</script>