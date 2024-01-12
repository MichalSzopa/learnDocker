export default {
    async getCategories() {
        const categories = await fetch('http://localhost:5013/categories', {credentials: 'include'});
        console.log('service getCategories triggered', categories);
        return categories.data;
    }
}