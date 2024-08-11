<script setup>
import { ref, onMounted } from 'vue';
import { useRoute, RouterLink, useRouter } from 'vue-router';
import { useToast } from 'vue-toastification';
import axios from 'axios';

const toast = useToast();
const router = useRouter();
const route = useRoute();
const fragranceId = ref(route.params.id);

// Initialize fragrance with an empty object or default properties
const fragrance = ref({});

const categoryName = ref('');
const brandName = ref('');
const genderName = ref('');
const scentName = ref('');
const seasonName = ref('');
const longevityName = ref('');
const sillageName = ref('');

// Function to fetch the fragrance based on the ID
const fetchFragrance = async () => {
  try {
    const response = await axios.get(`https://localhost:7224/api/Fragrance/${fragranceId.value}`);
    fragrance.value = response.data;
    // console.log(fragrance.value.name);

    // Fetch related data based on IDs
    getCategory(fragrance.value.categoryId);
    getBrand(fragrance.value.brandId);
    getGender(fragrance.value.genderId);
    getScent(fragrance.value.scentId);
    getSeason(fragrance.value.seasonId);
    getLongevity(fragrance.value.longevityId);
    getSillage(fragrance.value.sillageId);
  } catch (error) {
    console.error('Error fetching the fragrance:', error);
  }
};

// Methods to fetch names based on IDs
const getCategory = async (categoryId) => {
  try {
    const response = await axios.get(`https://localhost:7224/api/Category/${categoryId}`);
    categoryName.value = response.data.name;
  } catch (error) {
    console.error('Error fetching category name:', error);
  }
};

const getBrand = async (brandId) => {
  try {
    const response = await axios.get(`https://localhost:7224/api/Brand/${brandId}`);
    brandName.value = response.data.name;
  } catch (error) {
    console.error('Error fetching brand name:', error);
  }
};

const getGender = async (genderId) => {
  try {
    const response = await axios.get(`https://localhost:7224/api/Gender/${genderId}`);
    genderName.value = response.data.name;
  } catch (error) {
    console.error('Error fetching gender name:', error);
  }
};

const getScent = async (scentId) => {
  try {
    const response = await axios.get(`https://localhost:7224/api/Scent/${scentId}`);
    scentName.value = response.data.name;
  } catch (error) {
    console.error('Error fetching scent name:', error);
  }
};

const getSeason = async (seasonId) => {
  try {
    const response = await axios.get(`https://localhost:7224/api/Season/${seasonId}`);
    seasonName.value = response.data.name;
  } catch (error) {
    console.error('Error fetching season name:', error);
  }
};

const getLongevity = async (longevityId) => {
  try {
    const response = await axios.get(`https://localhost:7224/api/Longevity/${longevityId}`);
    longevityName.value = response.data.name;
  } catch (error) {
    console.error('Error fetching longevity name:', error);
  }
};

const getSillage = async (sillageId) => {
  try {
    const response = await axios.get(`https://localhost:7224/api/Sillage/${sillageId}`);
    sillageName.value = response.data.name;
  } catch (error) {
    console.error('Error fetching sillage name:', error);
  }
};

const deleteFragrance = async () => {
  try {
    const confirm = window.confirm('Are you sure you want to delete this fragrance?');
    if (confirm) {
      await axios.delete(`https://localhost:7224/api/Fragrance/delete/${fragranceId.value}`);
      toast.success('Fragrance Deleted Successfully!');
      router.push('/fragrances');
    }
  } catch (error) {
    console.error('Error deleting the fragrance!', error);
    toast.error("Fragrance could not be deleted!");
  }
}

// Fetch the fragrance and related data when the component is mounted
onMounted(() => {
  fetchFragrance();
});
</script>

<template>
  <section class="bg-green-50">
    <div class="container m-auto py-10 px-6">
      <div class="grid grid-cols-1 md:grid-cols-70/30 w-full gap-6">
        <main>
          <div class="bg-white p-6 rounded-lg shadow-md text-center md:text-left">
            <div class="text-gray-500 mb-4">{{ categoryName }}</div>
            <h1 class="text-3xl font-bold mb-4">{{ fragrance.name }}</h1>
            <div class="text-gray-500 mb-4 flex align-middle justify-center md:justify-start">
              <p class="text-primary">{{ brandName }}</p>
            </div>
          </div>

          <div class="bg-white p-6 rounded-lg shadow-md mt-6">
            <h3 class="text-primary text-lg font-bold mb-6">Fragrance Description</h3>
            <p class="mb-4">{{ fragrance.description }}</p>
            <h3 class="text-primary text-lg font-bold mb-2">Ingredients:</h3>
            <p class="mb-4">{{ fragrance.ingredients }}</p>
            <h3 class="text-primary text-lg font-bold mb-2">Price</h3>
            <p class="mb-4">{{ fragrance.price }}</p>
          </div>
        </main>

        <!-- Sidebar -->
        <aside>
          <!-- Fragrance Info -->
          <div class="bg-white p-6 rounded-lg shadow-md">
            <h3 class="text-xl font-bold mb-6">Fragrance Info:</h3>

            <h3 class="text-xl">Gender:</h3>
            <p class="my-2 font-bold">{{ genderName }}</p>

            <h3 class="text-xl">Scent:</h3>
            <p class="my-2 font-bold">{{ scentName }}</p>

            <h3 class="text-xl">Season:</h3>
            <p class="my-2 font-bold">{{ seasonName }}</p>

            <hr class="my-4" />

            <h3 class="text-xl">Longevity:</h3>
            <p class="my-2 bg-green-100 p-2 font-bold">{{ longevityName }}</p>

            <h3 class="text-xl">Sillage:</h3>
            <p class="my-2 bg-lightPrimary p-2 font-bold">{{ sillageName }}</p>
          </div>

          <!-- Manage -->
          <div class="bg-white p-6 rounded-lg shadow-md mt-6">
            <h3 class="text-xl font-bold mb-6">Manage Fragrance</h3>
            <RouterLink :to="`/fragrances/edit/${fragrance.id}`" 
              class="bg-green-500 hover:bg-green-600 text-white text-center font-bold py-2 px-4 rounded-full w-full focus:outline-none focus:shadow-outline mt-4 block">
              Edit Fragrance
            </RouterLink>
            <button @click="deleteFragrance"
              class="bg-red-500 hover:bg-red-600 text-white font-bold py-2 px-4 rounded-full w-full focus:outline-none focus:shadow-outline mt-4 block">
              Delete Fragrance
            </button>
          </div>
        </aside>
      </div>
    </div>
  </section>
</template>
