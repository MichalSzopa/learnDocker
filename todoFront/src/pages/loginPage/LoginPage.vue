<template>
    <div id="app">
        <div class="login-container">
            <h2>Login</h2>
            <div class="form-group">
                <label for="username">Username</label>
                <input type="text" id="username" v-model="username">
            </div>
            <div class="form-group">
                <label for="password">Password</label>
                <input type="password" id="password" v-model="password">
            </div>
            <div class="form-group">
                <button @click="login">Login</button>
            </div>
        </div>
        <button @click="loginTest"> Login test</button>
    </div>
</template>

<script>
import { mapGetters, mapActions } from 'vuex';

export default {
    name: 'LoginPage',
    data() {
        return {
            username: '',
            password: '',
        }
    },
    computed: {
        ...mapGetters('login', ['isLoggedIn']),
    },
    methods: {
        ...mapActions('login', ['logIn']),
        async login() {
            try {
                const data = {
                    username: this.username,
                    password: this.password
                };
                await this.logIn(data);
                if (this.isLoggedIn) {
                  this.$router.push('/categories');
                }
            }
            catch {
                console.log('cosik nieteges');
            }
        },
        async loginTest() {
            console.log(this.isLoggedIn);
        }
    }
};
</script>

<style>
.login-container {
    width: 300px;
    padding: 20px;
    border: 1px solid #ccc;
    border-radius: 5px;
    box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
}

.form-group {
    margin-bottom: 15px;
}

.form-group label {
    display: block;
    font-weight: bold;
    margin-bottom: 5px;
}

.form-group input {
    width: 100%;
    padding: 8px;
    border: 1px solid #ccc;
    border-radius: 3px;
}

.form-group button {
    width: 100%;
    padding: 8px;
    background-color: #007bff;
    color: white;
    border: none;
    border-radius: 3px;
    cursor: pointer;
}

.form-group button:hover {
    background-color: #0056b3;
}
</style>