<script setup>
import { computed } from 'vue';
import { useAuth } from '@/useAuth'; // Adjust path as needed
import { useRouter } from 'vue-router';
import axios from 'axios';

// Destructure state and methods from useAuth
const { state, logout } = useAuth();
const router = useRouter();

const isLoggedIn = computed(() => state.value.isLoggedIn);
const username = computed(() => state.value.username);

const handleLogout = async () => {
  try {
    await axios.post('https://localhost:7224/api/Authentication/logout'); // API call to log out
    logout(); // Clear authentication state and local storage
    router.push('/login'); // Redirect to login page
  } catch (error) {
    console.error('Logout failed:', error);
  }
};
</script>

<template>
  <nav class="bg-primary border-b border-white-600">
    <div class="mx-auto max-w-7xl px-2 sm:px-6 lg:px-8">
      <div class="flex h-20 items-center justify-between">
        <div class="flex flex-1 items-center justify-center md:items-stretch md:justify-start">
          <div class="md:ml-auto">
            <div class="flex space-x-2">
              <RouterLink to="/" class="text-white hover:bg-hover hover:text-white rounded-md px-3 py-2">Home</RouterLink>
              <RouterLink to="/fragrances" class="text-white hover:bg-secondary hover:text-white rounded-md px-3 py-2">Fragrances</RouterLink>
              <RouterLink to="/fragrances/add" class="text-white hover:bg-secondary hover:text-white rounded-md px-3 py-2">Add Fragrance</RouterLink>
              
              <!-- Conditional rendering based on authentication state -->
              <template v-if="isLoggedIn">
                <span class="text-white rounded-md px-3 py-2">{{ username }}</span>
                <button @click="handleLogout" class="text-white hover:bg-secondary hover:text-white rounded-md px-3 py-2">Logout</button>
              </template>
              
              <template v-else>
                <RouterLink to="/register" class="text-white hover:bg-secondary hover:text-white rounded-md px-3 py-2">Register</RouterLink>
                <RouterLink to="/login" class="text-white hover:bg-secondary hover:text-white rounded-md px-3 py-2">Login</RouterLink>
              </template>
            </div>
          </div>
        </div>
      </div>
    </div>
  </nav>
</template>
