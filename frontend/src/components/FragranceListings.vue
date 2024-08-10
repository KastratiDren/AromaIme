<script setup>
import FragranceListing from './FragranceListing.vue';
import { ref, onMounted } from 'vue';
import axios from 'axios';

// Define a reactive variable to store fragrances
const fragrances = ref([]);

// Function to fetch fragrances
const fetchFragrances = async () => {
  try {
    const response = await axios.get('https://localhost:7224/api/Fragrance');
    fragrances.value = response.data;
  } catch (error) {
    console.error('Error fetching fragrances:', error);
  }
};

// Fetch fragrances when the component mounts
onMounted(fetchFragrances);
</script>

<template>
    <section class="px-4 py-10">
        <div class="container-xl lg:container m-auto">
            <h2 class="text-3xl font-bold text-primary mb-6 text-center">
                Browse fragrances
            </h2>
            <div class="grid grid-cols-1 md:grid-cols-3 gap-6">
                <FragranceListing v-for="fragrance in fragrances" :key="fragrance.id" :fragrance="fragrance"/>
            </div>
        </div>
    </section>
</template>
