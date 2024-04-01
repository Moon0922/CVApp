<template>
  <v-sheet class="py-16">
    <v-container>
      <v-row>
        <v-col cols="12" md="5">
          <v-img src="/assets/discover_bg.png" /></v-col>

        <v-col
          cols="12"
          md="7"
        >
          <div class="text-h4">
            Discover how we can help you to group your business fast
          </div>

          <div class="text-body-1 text-medium-emphasis my-5">
            Venis demo enim ipsam voluptatem quia voluptas sit aspernatur netsum
            lorem fugit, seditum netis velas matrix net nesciunt
          </div>

          <div
            v-for="text in discover"
            :key="text"
            class="text-medium-emphasis my-2 mb-4"
          >
            <v-icon
              color="accent"
              icon="mdi-check-bold"
              start
            />

            {{ text }}
          </div>

          <v-btn
            color="primary"
            flat
            height="55"
            rounded
            text="Discover More"
          />
        </v-col>
      </v-row>
    </v-container>
  </v-sheet>
</template>

<script setup>
  const discover = [
    'Quias netus magni netsum eos qui ratione sequi',
    'Venis ratione sequi netus enim quia tempor magne',
    'Venis ratione sequi netus enim quia tempor magne',
  ]
</script>
