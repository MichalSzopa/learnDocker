<template>
    <v-sheet width="300" class="mx-auto">
        <v-form fast-fail @submit.prevent="submitForm">
            <v-text-field v-model="category.description" label="Description" :rules="descriptionRules"></v-text-field>

            <v-text-field v-model="category.color" label="Color" :rules="colorRules"></v-text-field>

            <v-btn type="submit">Submit</v-btn>
        </v-form>
    </v-sheet>
</template>

<script>
import { mapActions, mapGetters } from 'vuex'

export default {
    name: 'EditCategoryPage',
    data: () =>({
        category: {
            id: null,
            description: null,
            color: null,
        },
        descriptionRules: [
            value => {
                if (value?.length >= 3) return true

                return 'Description must be at least 3 characters.'
            },
        ],
        colorRules: [
            value => {
                if (!!value && value >= 0 && value <= 9) return true

                return 'Color must be in range 0-9.'
            },
        ],
    }),
    computed: {
        ...mapGetters('categories', ['getEditedCategory']),
    },
    methods: {
        ...mapActions('categories', ['editCategory']),
        async submitForm() {
            await this.editCategory(this.category);
            this.$router.push('/categories');
        },
    },
    async created() {
        this.category = this.getEditedCategory;
    }
}
</script>
