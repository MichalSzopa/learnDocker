<template>
    <v-list 
        :items="categories"
        item-title="description"
        item-value="id">

    </v-list>
</template>

<script>
import axios from 'axios';

export default {
    name: 'UserHomePage',
    data() {
        return {
            categories: [],
        }
    },
    methods: {
        
    },
    async created() {
        this.categories = (await axios.get('http://localhost:5013/categories', { withCredentials: true })).data;
    }
}
</script>