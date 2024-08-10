<script setup>
import { RouterLink } from 'vue-router';
</script>

<template>
    <nav class="bg-primary border-b border-white-600">
        <div class="mx-auto max-w-7xl px-2 sm:px-6 lg:px-8">
            <div class="flex h-20 items-center justify-between">
                <div class="flex flex-1 items-center justify-center md:items-stretch md:justify-start">
                    <!-- <a class="flex flex-shrink-0 items-center mr-4" href="index.html">
                    <img class="h-10 w-auto" src="images/logo.png" alt="Vue Jobs" />
                    <span class="hidden md:block text-white text-2xl font-bold ml-2"
                    >Vue Jobs</span>
                     -->
                    <div class="md:ml-auto">
                        <div class="flex space-x-2">
                            <RouterLink to="/"
                                class="text-white hover:bg-hover hover:text-white rounded-md px-3 py-2">Home
                            </RouterLink>
                            <RouterLink to="/fragrances"
                                class="text-white hover:bg-secondary hover:text-white rounded-md px-3 py-2">Fragrances
                            </RouterLink>
                            <RouterLink to="/fragrances/add"
                                class="text-white hover:bg-secondary hover:text-white rounded-md px-3 py-2">Add
                                Fragrance
                            </RouterLink>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </nav>
</template>
