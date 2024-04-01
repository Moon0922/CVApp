<template>
  <v-sheet
    id="about"
    class="py-16 text-center"
    color="secondary"
  >
    <div class="text-h4 font-weight-bold">
      What We Do
    </div>

    <div class="text-body-1 font-weight-regular mt-3 text-medium-emphasis mb-12">
      Discover how our amazing team can help your business.
    </div>

    <v-container>
      <v-row>
        <v-col
          v-for="item in whatWeDo"
          :key="item.title"
          class="d-flex flex-column align-center"
          cols="12"
          md="4"
        >
          <img :src="item.icon">

          <div class="text-h6 mt-1">
            {{ item.title }}
          </div>

          <div class="text-body-1 mt-2 text-medium-emphasis w-75">
            {{ item.description }}
          </div>
        </v-col>
      </v-row>
    </v-container>
  </v-sheet>
</template>

<script setup>
  const whatWeDo = [
    {
      icon: './assets/what/analytics.png',
      title: 'Web API',
      description:
        'Web API enables your application to flexibly use every latest recognition technologies from CVAPP.',
    },
    {
      icon: './assets/what/awareness.png',
      title: 'Mobile SDK',
      description:
        'Use CVAPP capabilities on mobile devices, offline. Process video streams easily.',
    },
    {
      icon: './assets/what/design.png',
      title: 'Windows and Linux SDK',
      description:
        'Use CVAPP capabilities on any OS, offline. Deployable on any device including Raspberry Pi, Arduino, Jetson Nano, etc.',
    },
  ]
</script>
