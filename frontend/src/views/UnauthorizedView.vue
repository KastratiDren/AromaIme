<script setup>
import { RouterLink } from 'vue-router';
</script>

<template>
  <section class="text-center flex flex-col justify-center items-center h-96">
    <i class="pi pi-exclamation-circle text-red-500 text-7xl mb-5"></i>
    <h1 class="text-6xl font-bold mb-4">Unauthorized</h1>
    <p class="text-xl mb-5">You do not have permission to view this page.</p>
    <RouterLink
      to="/"
      class="text-white bg-blue-700 hover:bg-blue-900 rounded-md px-3 py-2 mt-4"
      >Go Back</RouterLink
    >
  </section>
</template>

<style scoped>
/* Additional styles can go here */
</style>
