<script setup>
    import { ref } from 'vue';
    import Login from '../components/LoginComponent.vue';
    import UserInfo from '../components/UserInfoComponent.vue';

    const token = localStorage.getItem('jwtToken');
    const isLoggedIn = ref(!!token);
</script>

<template>
    <main>
        <Login v-if="!isLoggedIn" />
        <UserInfo v-else />
    </main>
</template>