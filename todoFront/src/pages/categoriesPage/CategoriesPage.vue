<template>
    <v-list 
        :items="categories"
        item-title="description"
        item-value="id">
    </v-list>
</template>

<script>
import { mapGetters, mapActions } from 'vuex';

export default {
    name: 'UserHomePage',
    data() {
        return {
        }
    },
    computed: {
    ...mapGetters('categories', ['getData']),
    },
    methods: {
        ...mapActions('categories', ['fetchData']),
    },
    async created() {
        this.fetchData();
    }
}
</script>