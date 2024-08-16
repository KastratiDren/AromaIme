<script setup>
import { ref } from 'vue';
import axios from 'axios';
import { useAuth } from '@/useAuth'; // Adjust path as needed
import { useRouter } from 'vue-router';
import { useToast } from 'vue-toastification';

// Define formData using ref
const formData = ref({
  userName: '',
  password: ''
});

const toast = useToast();
const { state, login } = useAuth(); // Destructure the updated auth store
const router = useRouter();

const submitForm = async () => {
  try {
    const response = await axios.post('https://localhost:7224/api/Authentication/login', formData.value);
    const userDTO = response.data;
    console.log('UserDTO:', userDTO);
    toast.success('Login successful!');

    // Use the login function from useAuth
    login(userDTO.token, userDTO.userName);

    // Redirect to homepage
    router.push('/');
  } catch (error) {
    console.error('Login error:', error);
    toast.error('Login failed!');
  }
};
</script>

<template>
  <section class="bg-lightPrimary">
    <div class="container m-auto max-w-2xl py-24">
      <div class="bg-white px-6 py-8 mb-4 shadow-md rounded-md border m-4 md:m-0">
        <form @submit.prevent="submitForm">
          <h2 class="text-3xl text-center font-semibold mb-6">Login</h2>

          <div class="mb-4">
            <label for="userName" class="block text-black font-bold mb-2">UserName</label>
            <input v-model="formData.userName" type="text" id="userName" class="border rounded w-full py-2 px-3" required />
          </div>

          <div class="mb-4">
            <label for="password" class="block text-black font-bold mb-2">Password</label>
            <input v-model="formData.password" type="password" id="password" class="border rounded w-full py-2 px-3" required />
          </div>

          <div>
            <button class="bg-primary hover:bg-hover text-white font-bold py-2 px-4 rounded-full w-full focus:outline-none focus:shadow-outline" type="submit">
              Login
            </button>
          </div>
        </form>
      </div>
    </div>
  </section>
</template>
