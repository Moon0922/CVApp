<template>
  <v-sheet
    class="text-center pa-16"
    color="accent"
  >
    <div class="text-h3 font-weight-bold mb-5 mb-12">
      Facts About Our Agency
    </div>

    <v-container>
      <v-row align="center" class="mx-15">
        <v-col
          v-for="item in agency"
          :key="item.title"
          cols="12"
          md="3"
          sm="6"
        >
          <v-img height="56" :src="item.icon" />

          <div class="text-h4 font-weight-bold mt-5">
            {{ item.title }}
          </div>

          <div class="text-body-1 mt-5">
            {{ item.description }}
          </div>
        </v-col>
      </v-row>
    </v-container>
  </v-sheet>
</template>

<script setup>
  const agency = [
    {
      icon: '/assets/agency/completed.png',
      title: 'Accurate',
      description: 'Industry-leading accuracy, in real-world applications',
    },
    {
      icon: '/assets/agency/heart.png',
      title: 'Fast',
      description: 'Fast per-frame processing means it runs in real time on any device.'
    },
    {
      icon: '/assets/agency/awards.png',
      title: 'Efficient',
      description: 'Read the world without waiting, online and offline',
    },
    {
      icon: '/assets/agency/anchor.png',
      title: 'Reliable',
      description: 'Built for high availability, CVAPP is always on',
    },
  ]
</script>
