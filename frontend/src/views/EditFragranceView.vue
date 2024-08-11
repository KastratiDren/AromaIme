<script setup>
import { ref, onMounted } from 'vue';
import axios from 'axios';
import { useRoute, useRouter } from 'vue-router';
import { useToast } from 'vue-toastification';

const toast = useToast();

// Ref for form data object
const formData = ref({
  name: '',
  description: '',
  price: '',
  notes: '',
  ingredients: '',
  launchYear: '',
  size: '',
  categoryId: null,
  scentId: null,
  seasonId: null,
  longevityId: null,
  sillageId: null,
  genderId: null,
  brandId: null,
});

// Ref arrays to store the options for each foreign key
const categories = ref([]);
const scents = ref([]);
const seasons = ref([]);
const longevities = ref([]);
const sillages = ref([]);
const genders = ref([]);
const brands = ref([]);

const route = useRoute();
const router = useRouter();
const fragranceId = route.params.id;

// Function to fetch options for each foreign key
const fetchOptions = async () => {
  try {
    const [categoryRes, scentRes, seasonRes, longevityRes, sillageRes, genderRes, brandRes] = await Promise.all([
      axios.get('https://localhost:7224/api/Category'),
      axios.get('https://localhost:7224/api/Scent'),
      axios.get('https://localhost:7224/api/Season'),
      axios.get('https://localhost:7224/api/Longevity'),
      axios.get('https://localhost:7224/api/Sillage'),
      axios.get('https://localhost:7224/api/Gender'),
      axios.get('https://localhost:7224/api/Brand'),
    ]);

    categories.value = categoryRes.data;
    scents.value = scentRes.data;
    seasons.value = seasonRes.data;
    longevities.value = longevityRes.data;
    sillages.value = sillageRes.data;
    genders.value = genderRes.data;
    brands.value = brandRes.data;
  } catch (error) {
    console.error('Error fetching options:', error);
  }
};

// Function to fetch fragrance details by ID
const fetchFragrance = async () => {
  try {
    const response = await axios.get(`https://localhost:7224/api/Fragrance/${fragranceId}`);
    formData.value = response.data; // Populate form data with the fetched fragrance details
  } catch (error) {
    console.error('Error fetching fragrance:', error);
  }
};

// Function to submit the form data
const submitForm = async () => {
  try {
    await axios.put(`https://localhost:7224/api/fragrance/update/${fragranceId}`, formData.value);
    toast.success('Fragrance Updated Succesfully!');
    router.push('/fragrances'); // Redirect to fragrance list after successful update
  } catch (error) {
    console.error('Error updating fragrance:', error);
    toast.error('Fragrance could not be updated!');
  }
};

// Fetch options and fragrance details when the component mounts
onMounted(() => {
  fetchOptions();
  fetchFragrance();
});

</script>

<template>
  <section class="bg-lightPrimary">
    <div class="container m-auto max-w-2xl py-24">
      <div class="bg-white px-6 py-8 mb-4 shadow-md rounded-md border m-4 md:m-0">
        <form @submit.prevent="submitForm">
          <h2 class="text-3xl text-center font-semibold mb-6">Edit Fragrance</h2>

          <!-- Input fields populated with fragrance data -->

          <div class="mb-4">
            <label for="name" class="block text-black font-bold mb-2">Fragrance Name</label>
            <input v-model="formData.name" type="text" id="name" class="border rounded w-full py-2 px-3 mb-2" required />
          </div>

          <div class="mb-4">
            <label for="description" class="block text-black font-bold mb-2">Description</label>
            <textarea v-model="formData.description" id="description" class="border rounded w-full py-2 px-3" rows="4"></textarea>
          </div>

          <div class="mb-4">
            <label for="price" class="block text-black font-bold mb-2">Price</label>
            <input v-model="formData.price" type="number" step="0.01" id="price" class="border rounded w-full py-2 px-3" required />
          </div>

          <div class="mb-4">
            <label for="size" class="block text-black font-bold mb-2">Size</label>
            <input v-model="formData.size" type="number" step="0.01" id="size" class="border rounded w-full py-2 px-3" required />
          </div>

          <div class="mb-4">
            <label for="notes" class="block text-black font-bold mb-2">Notes</label>
            <input v-model="formData.notes" type="text" id="notes" class="border rounded w-full py-2 px-3" required />
          </div>

          <div class="mb-4">
            <label for="ingredients" class="block text-black font-bold mb-2">Ingredients</label>
            <input v-model="formData.ingredients" type="text" id="ingredients" class="border rounded w-full py-2 px-3" required />
          </div>

          <div class="mb-4">
            <label for="launchYear" class="block text-black font-bold mb-2">Launch Year</label>
            <input v-model="formData.launchYear" type="number" id="launchYear" class="border rounded w-full py-2 px-3" required />
          </div>

          <!-- Foreign Key Dropdowns (Categories, Scents, etc.) -->

          <div class="mb-4">
            <label for="category" class="block text-black font-bold mb-2">Category</label>
            <select v-model="formData.categoryId" id="category" class="border rounded w-full py-2 px-3" required>
              <option v-for="category in categories" :key="category.id" :value="category.id">{{ category.name }}</option>
            </select>
          </div>

          <div class="mb-4">
            <label for="scent" class="block text-black font-bold mb-2">Scent</label>
            <select v-model="formData.scentId" id="scent" class="border rounded w-full py-2 px-3" required>
              <option v-for="scent in scents" :key="scent.id" :value="scent.id">{{ scent.name }}</option>
            </select>
          </div>

          <div class="mb-4">
            <label for="season" class="block text-black font-bold mb-2">Season</label>
            <select v-model="formData.seasonId" id="season" class="border rounded w-full py-2 px-3" required>
              <option v-for="season in seasons" :key="season.id" :value="season.id">{{ season.name }}</option>
            </select>
          </div>

          <div class="mb-4">
            <label for="longevity" class="block text-black font-bold mb-2">Longevity</label>
            <select v-model="formData.longevityId" id="longevity" class="border rounded w-full py-2 px-3" required>
              <option v-for="longevity in longevities" :key="longevity.id" :value="longevity.id">{{ longevity.name }}</option>
            </select>
          </div>

          <div class="mb-4">
            <label for="sillage" class="block text-black font-bold mb-2">Sillage</label>
            <select v-model="formData.sillageId" id="sillage" class="border rounded w-full py-2 px-3" required>
              <option v-for="sillage in sillages" :key="sillage.id" :value="sillage.id">{{ sillage.name }}</option>
            </select>
          </div>

          <div class="mb-4">
            <label for="gender" class="block text-black font-bold mb-2">Gender</label>
            <select v-model="formData.genderId" id="gender" class="border rounded w-full py-2 px-3" required>
              <option v-for="gender in genders" :key="gender.id" :value="gender.id">{{ gender.name }}</option>
            </select>
          </div>

          <div class="mb-4">
            <label for="brand" class="block text-black font-bold mb-2">Brand</label>
            <select v-model="formData.brandId" id="brand" class="border rounded w-full py-2 px-3" required>
              <option v-for="brand in brands" :key="brand.id" :value="brand.id">{{ brand.name }}</option>
            </select>
          </div>

          <div>
            <button class="bg-primary hover:bg-hover text-white font-bold py-2 px-4 rounded-full w-full focus:outline-none focus:shadow-outline" type="submit">
              Update Fragrance
            </button>
          </div>
        </form>
      </div>
    </div>
  </section>
</template>
