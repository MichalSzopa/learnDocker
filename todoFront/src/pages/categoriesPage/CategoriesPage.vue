<template>
    <v-btn variant="outlined" @click="addCategory"> Add category</v-btn>
    <v-list :items="categories" item-title="description" item-value="id">
    </v-list>
</template>

<script>
import { mapGetters, mapActions } from 'vuex';

export default {
    name: 'CategoriesPage',
    data() {
        return {
            categories: Array[0]
        }
    },
    computed: {
        ...mapGetters('categories', ['getData']),
    },
    methods: {
        ...mapActions('categories', ['fetchData']),
        async addCategory() {
            this.$router.push('/add-category');
        }
    },
    async created() {
        await this.fetchData();
        this.categories = this.getData;
    },

}
</script>