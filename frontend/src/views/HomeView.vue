<script setup>
import Hero from '@/components/Hero.vue';
import HomeCards from '@/components/HomeCards.vue';
import FragranceListings from '@/components/FragranceListings.vue';
</script>

<template>
  <Hero />
  <HomeCards />
  <FragranceListings :limit="3" :show-button="true"/>
</template>