<template>
    <v-sheet width="300" class="mx-auto">
        <v-form fast-fail @submit.prevent="submitForm">
            <v-text-field v-model="description" label="Description" :rules="descriptionRules"></v-text-field>

            <v-text-field v-model="title" label="Title" :rules="titleRules"></v-text-field>

            <v-btn type="submit">Submit</v-btn>
            <v-btn @click="this.$emit('addingFinished')">Cancel</v-btn>
        </v-form>
    </v-sheet>
</template>

<script>
import { mapActions } from 'vuex'

export default {
    name: 'AddProject',
    data: () =>({
        description: '',
        descriptionRules: [
            value => {
                if (value?.length >= 3) return true

                return 'Description must be at least 3 characters.'
            },
        ],
        title: '',
        titleRules: [
            value => {
                if (value?.length >= 3) return true

                return 'Title must be at least 3 characters.'
            },
        ],
    }),
    methods: {
        ...mapActions('projects', ['createProject']),
        async submitForm() {
            const project = {
                description: this.description,
                title: this.title
            };
            await this.createProject(project);
            this.$emit('addingFinished')
        },
    }
}
</script>
