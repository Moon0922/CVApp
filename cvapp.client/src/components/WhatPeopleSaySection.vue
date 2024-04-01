<template>
  <v-sheet
    id="testimonials"
    class="py-16"
    color="secondary"
  >
    <v-container>
      <v-row align="center">
        <v-col cols="12" md="6">
          <div class="text-h4 font-weight-medium">
            What People Are Saying.
          </div>

          <div class="text-body-1 text-medium-emphasis mt-5">
            Quis autem velis ets reprehender net etid quiste nets voluptate. Utise
            wisi enim minim venim, quis etsad aspernatis netsum stationes nets.
          </div>

          <v-row class="mt-5">
            <div
              v-for="(item, index) in ['TrustPilot', 'Feefo']"
              :key="item"
            >
              <v-alert
                :border="index === 1 ? 'start' : undefined"
                class="pt-3 rounded-0"
                color="secondary"
              >
                <div class="font-weight-bold">
                  {{ item }}
                </div>

                <div>
                  <v-rating
                    color="yellow-darken-2"
                    density="compact"
                    model-value="5"
                  />
                </div>
              </v-alert>
            </div>
          </v-row>
        </v-col>

        <v-col cols="12" md="6">
          <v-alert
            v-for="n in 3"
            :key="n"
            border="start"
            border-color="accent"
            class="my-5 border-opacity-100"
            color="white"
            elevation="5"
            rounded
          >
            <div class="d-flex flex-row align-center ga-3">
              <v-avatar image="https://vuetifyjs.b-cdn.net/images/john-smirk.png" />

              <div class="font-weight-bold text-h6">
                John Leider /
                <span class="text-primary">Engineer - Vuetify</span>
              </div>
            </div>
          </v-alert>
        </v-col>
      </v-row>
    </v-container>
  </v-sheet>
</template>
