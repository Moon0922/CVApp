<template>
  <v-sheet
    class="text-center"
    min-height="700"
  >
    <div class="text-h4 font-weight-medium pt-15 ">
      Frequently Asked Questions
    </div>

    <div class="text-body-1 text-medium-emphasis mt-5">
      Quis autem velis ets reprehender net etid quiste voluptate
    </div>

    <v-container>
      <v-row class="pa-10 text-left">
        <v-col
          v-for="n in 4"
          :key="n"
          class="pa-10"
          cols="12"
          md="6"
        >
          <div class="text-h6 font-weight-bold text-blue-grey-darken-2">
            Velit ut tortizi pretium viverra suspendisse?
          </div>

          <div class="text-body-1 text-medium-emphasis mt-5">
            Utise wisi enim minim veniam, quis et stationes ullamcorper nets
            suscipit ets lobotis nisle consequat nihis etim. Quis autem velis ets
            reprehender net etid quiste voluptate velitte esse sedis.
          </div>
        </v-col>
      </v-row>
    </v-container>
  </v-sheet>
</template>
