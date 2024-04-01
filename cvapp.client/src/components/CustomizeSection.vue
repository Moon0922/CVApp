<template>
  <v-sheet
    class="py-16"
    color="secondary"
  >
    <v-container>
      <v-row align="center">
        <v-col cols="12" md="7">
          <v-list
            base-color="transparent"
            bg-color="transparent"
            class="px-2"
            lines="three"
            variant="flat"
          >
            <v-list-item
              v-for="(item, index) in customize"
              :key="item.title"
              class="ga-5"
              :class="{ 'bg-grey-lighten-5 elevation-5 rounded': index === 0 }"
            >
              <template #prepend>
                <img :src="item.icon">
              </template>

              <template #title>
                <span class="text-h6 font-weight-bold">{{ item.title }}</span>
              </template>

              <template #subtitle>
                <span class="text-body-1 text-grey-darken-3">{{ item.subtitle }}</span>
              </template>
            </v-list-item>
          </v-list>
        </v-col>

        <v-col cols="12" md="5">
          <v-img src="/assets/customize_bg.png" />
        </v-col>
      </v-row>
    </v-container>
  </v-sheet>
</template>

<script setup>
  const customize = [
    {
      icon: './assets/customize.png',
      title: 'Customize your workflow',
      subtitle:
        'Manage any process and be ready to address any challenge with total ease.',
    },
    {
      icon: './assets/onboarding.png',
      title: 'Easy onboarding, fast adoption.',
      subtitle:
        'With Square getting your team on board is as simple as sending an email.',
    },
    {
      icon: './assets/retention.png',
      title: 'Improve subscriber retention',
      subtitle:
        'Analyze customers by region, discounts and more and put a plan in place.',
    },
  ]; </script>
