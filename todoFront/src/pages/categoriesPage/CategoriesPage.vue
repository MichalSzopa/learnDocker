<template>
    <AddCategoryPage v-if="adding === true" @addingFinished="returnToMainView"/>
    <EditCategoryPage v-else-if="editing === true" @editingFinished="returnToMainView"/>
    <div v-else>
        <v-btn variant="outlined" @click="addCategory"> Add category</v-btn>

        <v-list>
            <v-list-item v-for="(item, index) in categories" :key="index" :value="item">
                <span>{{ item.description }}</span>
                <template v-slot:append>
                    <v-btn variant="text" icon="mdi-pencil" @click="editCategory(item)"></v-btn>
                </template>
            </v-list-item>
        </v-list>
    </div>
</template>

<script>
import { mapGetters, mapActions, mapMutations } from 'vuex';
import AddCategoryPage from "./AddCategory.vue";
import EditCategoryPage from "./EditCategory.vue";


export default {
    name: 'CategoriesPage',
    components: {
        AddCategoryPage,
        EditCategoryPage
    },
    data() {
        return {
            categories: Array[0],
            adding: false,
            editing: false,
        }
    },
    computed: {
        ...mapGetters('categories', ['getCategories']),
    },
    methods: {
        ...mapActions('categories', ['fetchCategories']),
        ...mapMutations('categories', ['setEditedCategory']),

        async addCategory() {
            this.adding = true;
        },
        async editCategory(category) {
            this.setEditedCategory(category);
            this.editing = true;
        },
        async returnToMainView() {
            await this.fetchCategories();
            this.categories = this.getCategories;
            this.adding = false;
            this.editing = false;
        }
    },
    async created() {
        await this.fetchCategories();
        this.categories = this.getCategories;
    },

}
</script>