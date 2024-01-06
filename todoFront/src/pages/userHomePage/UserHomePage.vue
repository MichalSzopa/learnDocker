<template>
    <div>
        <button @click="loginTest"> Login test</button>
        <span v-if="this.testResult">{{ this.testResult }}</span>
    </div>
</template>

<script>
import axios from 'axios';

export default {
    name: 'UserHomePage',
    data() {
        return {
            testResult: null,
        }
    },
    methods: {
        async loginTest() {
            try {
                console.log('a');
                const response = await axios.get('http://localhost:5013/auth/login-test', { withCredentials: true });
                console.log('b');
                console.log(response);
                const data = response.data;
                console.log(data);
            }
            catch
            {
                console.log('not logged in');
                this.testResult='not logged in';
            }
        }
    },
};
</script>