export default {
    async login(username, password) {
        const data = {
            username,
            password
        }

        await fetch('http://localhost:5013/auth/login', {
            method: 'POST',
            mode: 'cors',
            credentials: 'include',
            headers: {
                'Content-Type': 'application/json'
              },
            body: JSON.stringify(data),
        }).then(response => {
            if (!response.ok) {
              throw new Error('Network response was not ok');
            }
            return response.json();
          })
          .catch(error => {
            console.error('There was a problem with login operation:', error);
          });
    },
    async checkIfLoggedIn() {
      let loggedIn = false;
      await fetch('http://localhost:5013/auth/login-test', {
            method: 'GET',
            mode: 'cors',
            credentials: 'include',
            headers: {
                'Content-Type': 'application/json'
              },
        }).then(async response => {
            if (response.ok) {
              const res = await response.json();
              loggedIn = res;
            }
          })
          .catch(() => {
          });
      return loggedIn;
    }
}