<script setup>
import Card from '@/components/Card.vue'
import { RouterLink } from 'vue-router';
</script>

<template>
    <section class="py-4">
        <div class="container-xl lg:container m-auto">
            <div class="grid grid-cols-1 md:grid-cols-2 gap-4 p-4 rounded-lg">
                <!-- Customer Card -->
                <Card>
                    <h2 class="text-2xl font-bold text-primary">For Customers</h2>
                    <p class="mt-2 mb-4 text-black-700">
                        Browse our Fragrances and find the right one today
                    </p>
                    <RouterLink to="/fragrances" class="inline-block bg-primary text-white rounded-lg px-4 py-2 hover:bg-hover">
                        Browse Fragrances
                    </RouterLink>
                </Card>
                <!-- Companies Card -->
                <Card bg="bg-lightSecondary">
                    <h2 class="text-2xl font-bold text-primary">For Companies</h2>
                    <p class="mt-2 mb-4 text-black-700">
                        List your favorite fragrance to wear
                    </p>
                    <RouterLink to="/fragrances/add"
                        class="inline-block bg-primary text-white rounded-lg px-4 py-2 hover:bg-hover">
                        Add Fragrance
                    </RouterLink>
                </Card>
            </div>
        </div>
    </section>


</template>