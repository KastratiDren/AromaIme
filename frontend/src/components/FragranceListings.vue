<script setup>
import FragranceListing from './FragranceListing.vue';
import { ref, onMounted, defineProps } from 'vue';
import axios from 'axios';

// Define a reactive variable to store fragrances
const fragrances = ref([]);

defineProps({
  limit: Number
});

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
                <FragranceListing 
                v-for="fragrance in fragrances.slice(0, limit || fragrances.length)" 
                :key="fragrance.id" 
                :fragrance="fragrance"/>
            </div>
        </div>
    </section>
    <section class="m-auto max-w-lg my-10 px-6">
      <a
        href="/fragrances"
        class="block bg-primary text-white text-center py-4 px-6 rounded-xl hover:bg-gray-700"
        >View All Fragrances</a
      >
    </section>
</template>
