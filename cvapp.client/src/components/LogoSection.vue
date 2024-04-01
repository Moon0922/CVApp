<template>
  <v-sheet class="d-flex align-center justify-center py-16 flex-wrap ga-5 px-4">
    <v-img
      v-for="item in banners"
      :key="item"
      max-height="50"
      max-width="160"
      :src="item"
    />
  </v-sheet>
</template>

<script setup>
  const banners = [
    '/assets/banner/csswinner.png',
    '/assets/banner/cssawards.png',
    '/assets/banner/fwa.png',
    '/assets/banner/cssdesignawards.png',
  ]
</script>
