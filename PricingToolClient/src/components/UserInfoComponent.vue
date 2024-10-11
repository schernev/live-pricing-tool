<script setup>
    import { ref, onMounted } from 'vue';
    import axios from 'axios';

    const errorMessage = ref('');
    const username = ref('');

    const setInfo = async () => {
        try {
            const url = import.meta.env.VITE_BACKEND_URL + import.meta.env.VITE_USERINFO_ACTION;
            const token = localStorage.getItem('jwtToken');

            const response = await axios.get(url, {
                headers: {
                    Authorization: `Bearer ${token}` // Add the token to the request headers
                }
            });
            username.value = response.data.username;

            console.log(`User info received`, response);
        } catch (error) {
            const msg = 'Get user info failed.';
            errorMessage.value = msg;
            console.error(msg, error);
        }
    };

    onMounted(() => {
        setInfo();
    });

    const logout = () => {
        localStorage.removeItem('jwtToken');
        window.location.reload();
    };
</script>

<template>
    <div>
      <h1 v-if="!errorMessage">Hello, <b>{{ username }}</b>. <a href="#" @click.prevent="logout">Logout</a></h1>

      <p v-if="errorMessage" class="error">{{ errorMessage }}</p>
    </div>
  </template>