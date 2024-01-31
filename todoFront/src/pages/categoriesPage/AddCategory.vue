<template>
    <v-sheet width="300" class="mx-auto">
        <v-form fast-fail @submit.prevent="submitForm">
            <v-text-field v-model="description" label="Description" :rules="descriptionRules"></v-text-field>

            <v-text-field v-model="color" label="Color" :rules="colorRules"></v-text-field>

            <v-btn type="submit">Submit</v-btn>
        </v-form>
    </v-sheet>
</template>

<script>
import { mapActions } from 'vuex'

export default {
    name: 'AddCategoryPage',
    data: () =>({
        description: '',
        descriptionRules: [
            value => {
                if (value?.length >= 3) return true

                return 'Description must be at least 3 characters.'
            },
        ],
        color: null,
        colorRules: [
            value => {
                if (!!value && value >= 0 && value <= 9) return true

                return 'Color must be in range 0-9.'
            },
        ],
    }),
    methods: {
        ...mapActions('categories', ['createCategory']),
        async submitForm() {
            const category = {
                description: this.description,
                color: this.color
            };
            await this.createCategory(category);
            this.$router.push('/categories');
        },
    }
}
</script>
