<script setup>
    import { ref } from 'vue';
    import axios from 'axios';

    const username = ref('');
    const password = ref('');
    const errorMessage = ref('');

    const login = async () => {
        try {
            const url = import.meta.env.VITE_BACKEND_URL + import.meta.env.VITE_LOGIN_ACTION;
            const data = {
                username: username.value,
                password: password.value
            };
            console.log(`Logging in to ${url} with ${JSON.stringify(data)}`);
            const response = await axios.post(url, data);

            // Extract the token from the response
            const token = response.data.token;
            
            // Store the token in local storage
            localStorage.setItem('jwtToken', token);

            console.log(`Login successful, JWT token received: ${token}`, response.data);

            window.location.reload();
        } catch (error) {
            errorMessage.value = 'Login failed. Please check your credentials and try again.';
            console.error('Login error:', error);
        }
    };
</script>

<template>
    <div class="login">
      <h1>Login</h1>
      <form @submit.prevent="login">
        <label for="username">Username</label>
        <input type="text" id="username" v-model="username" required />
        
        <label for="password">Password</label>
        <input type="password" id="password" v-model="password" required />
        
        <button type="submit">Login</button>
      </form>
      <p v-if="errorMessage" class="error">{{ errorMessage }}</p>
    </div>
  </template>
  
  <style scoped>
    .login {
        max-width: 300px;
        margin: auto;
    }
    label {
        display: block;
    }
    button {
        margin-left: 1rem;
    }
    .error {
        color: red;
        margin-top: 0.1rem;
    }
  </style>