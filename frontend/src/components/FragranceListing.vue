<script setup>
import { ref, onMounted } from 'vue';
import axios from 'axios';
import { RouterLink } from 'vue-router';

const props = defineProps({
  fragrance: Object
});

const showFullDescription = ref(false);

const toggleFullDescription = () => {
  showFullDescription.value = !showFullDescription.value;
};

const scentName = ref('');
const categoryName = ref('');

// Method to fetch scent name based on scentId
const getScent = async (scentId) => {
  try {
    const response = await axios.get(`https://localhost:7224/api/Scent/${scentId}`);
    scentName.value = response.data.name;
  } catch (error) {
    console.error('Error fetching scent name:', error);
  }
};

// Method to fetch category name based on categoryId
const getCategory = async (categoryId) => {
  try {
    const response = await axios.get(`https://localhost:7224/api/Category/${categoryId}`);
    categoryName.value = response.data.name;
  } catch (error) {
    console.error('Error fetching category name:', error);
  }
};

// Fetch names when the component mounts
onMounted(() => {
    getScent(props.fragrance.scentId);
    getCategory(props.fragrance.categoryId);
});
</script>

<template>
  <div class="bg-white rounded-xl shadow-md relative">
    <div class="p-4">
      <div class="mb-6">
        <div class="text-primary my-2">{{ categoryName }}</div>
        <h3 class="text-xl font-bold">{{ fragrance.name }}</h3>
      </div>

      <div class="mb-5">
        {{ fragrance.description }}
      </div>

      <h3 class="text-primary mb-2">{{ fragrance.price }}$</h3>

      <div class="border border-gray-100 mb-5"></div>

      <div class="flex flex-col lg:flex-row justify-between mb-4">
        <div class="text-black mb-3">
          Scent Type: <span class="text-primary font-bold">{{ scentName }}</span> 
        </div>
        <RouterLink
          :to="'/fragrances/' + fragrance.id"
          class="h-[36px] bg-primary hover:bg-hover text-white px-4 py-2 rounded-lg text-center text-sm"
        >
          Read More
        </RouterLink>
      </div>
    </div>
  </div>
</template>
