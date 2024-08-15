<script setup>
import { ref } from 'vue';
import axios from 'axios';
import { useToast } from 'vue-toastification';

// Ref for form data object
const formData = ref({
  name: '',
  surname: '',
  userName: '',
  email: '',
  password: ''
});

const toast = useToast();

// Function to submit the form data
const submitForm = async () => {
  console.log('Form Data:', formData.value);

  try {
    await axios.post('https://localhost:7224/api/User/register', formData.value);
    toast.success('Registration Successful!');

    // Reset the formData
    formData.value = {
      name: '',
      surname: '',
      userName: '',
      email: '',
      password: ''
    };
  } catch (error) {
      console.error('Error response:', error.response.data); // Log server response
      toast.error('Registration Failed!');
  }
};
</script>

<template>
  <section class="bg-lightPrimary">
    <div class="container m-auto max-w-2xl py-24">
      <div class="bg-white px-6 py-8 mb-4 shadow-md rounded-md border m-4 md:m-0">
        <form @submit.prevent="submitForm">
          <h2 class="text-3xl text-center font-semibold mb-6">Register</h2>

          <div class="mb-4">
            <label for="name" class="block text-black font-bold mb-2">Name</label>
            <input v-model="formData.name" type="text" id="name" class="border rounded w-full py-2 px-3 mb-2" required />
          </div>

          <div class="mb-4">
            <label for="surname" class="block text-black font-bold mb-2">Surname</label>
            <input v-model="formData.surname" type="text" id="surname" class="border rounded w-full py-2 px-3 mb-2" required />
          </div>

          <div class="mb-4">
            <label for="userName" class="block text-black font-bold mb-2">Username</label>
            <input v-model="formData.userName" type="text" id="userName" class="border rounded w-full py-2 px-3 mb-2" required />
          </div>

          <div class="mb-4">
            <label for="email" class="block text-black font-bold mb-2">Email</label>
            <input v-model="formData.email" type="email" id="email" class="border rounded w-full py-2 px-3 mb-2" required />
          </div>

          <div class="mb-4">
            <label for="password" class="block text-black font-bold mb-2">Password</label>
            <input v-model="formData.password" type="password" id="password" class="border rounded w-full py-2 px-3 mb-2" required />
          </div>

          <div>
            <button class="bg-primary hover:bg-hover text-white font-bold py-2 px-4 rounded-full w-full focus:outline-none focus:shadow-outline" type="submit">
              Register
            </button>
          </div>
        </form>
      </div>
    </div>
  </section>
</template>
