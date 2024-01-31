<template>
    <v-sheet width="300" class="mx-auto">
        <v-form fast-fail @submit.prevent="submitForm">
            <v-text-field v-model="project.description" label="Description" :rules="descriptionRules"></v-text-field>

            <v-text-field v-model="project.title" label="Title" :rules="titleRules"></v-text-field>

            <v-btn type="submit">Submit</v-btn>
            <v-btn @click="this.$emit('editingFinished')">Cancel</v-btn>
        </v-form>
    </v-sheet>
</template>

<script>
import { mapActions, mapGetters } from 'vuex'

export default {
    name: 'EditProject',
    data: () =>({
        project: {
            id: null,
            description: null,
            title: null,
        },
        descriptionRules: [
            value => {
                if (value?.length >= 3) return true

                return 'Description must be at least 3 characters.'
            },
        ],
        titleRules: [
            value => {
                if (value?.length >= 3) return true

                return 'Title must be at least 3 characters.'
            },
        ],
    }),
    computed: {
        ...mapGetters('projects', ['getEditedProject']),
    },
    methods: {
        ...mapActions('projects', ['editProject']),
        async submitForm() {
            await this.editProject(this.project);
            this.$emit('editingFinished');
        },
    },
    async created() {
        this.project = this.getEditedProject;
    }
}
</script>
