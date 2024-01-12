export default {
    async login(username, password) {
        const data = {
            username,
            password
        }

        await fetch('http://localhost:5013/auth/login', {
            method: 'POST',
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
          .then(data => {
            // Handle the data from the POST request
            console.log(data);
          })
          .catch(error => {
            // Handle errors
            console.error('There was a problem with the fetch operation:', error);
          });
    }
}