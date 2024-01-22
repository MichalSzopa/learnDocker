<template>
    <v-btn variant="outlined" @click="addCategory"> Add category</v-btn>

    <v-list>
      <v-list-item
        v-for="(item, index) in categories"
        :key="index"
        :value="item"
      >
        <span>{{ item.description }}</span>
        <template v-slot:append>
          <v-btn :icon="mdi-edit" @click="editCategory(item)"></v-btn>
        </template>

        <v-list-item-title v-text="item.text"></v-list-item-title>
      </v-list-item>
    </v-list>
</template>

<script>
import { mapGetters, mapActions, mapMutations} from 'vuex';

export default {
    name: 'CategoriesPage',
    data() {
        return {
            categories: Array[0]
        }
    },
    computed: {
        ...mapGetters('categories', ['getCategories']),
    },
    methods: {
        ...mapActions('categories', ['fetchCategories']),
        ...mapMutations('categories', ['setEditedCategory']),

        async addCategory() {
            this.$router.push('/add-category');
        },
        async editCategory(category) {
            this.setEditedCategory(category);
            console.log('categoriesPage', category);
            this.$router.push('/edit-category');
        }
    },
    async created() {
        await this.fetchCategories();
        this.categories = this.getCategories;
    },

}
</script>