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
import axios from 'axios';

export default {
    name: 'LoginPage',
    data() {
        return {
            username: '',
            password: '',
        }
    },
    methods: {
        async login() {
            try {
            await axios.post('http://localhost:5013/auth/login', {
              username: this.username,
              password: this.password
            },
            {withCredentials: true});
            this.$router.push('/categories');
          } catch (error) {
            console.error('Login failed:', error.response ? error.response.data : error.message);
          }
        },
        async loginTest() {
            try {
                await axios.get('http://localhost:5013/login-test', {withCredentials: true});
            }
            catch
            {
                console.log('not logged in');
            }
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