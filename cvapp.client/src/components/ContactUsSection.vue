<template>
  <v-sheet
    class="text-center py-16"
    color="primary"
  >
    <div class="text-white text-h4 font-weight-medium">
      Contact Us
    </div>

    <div class="text-center text-body-1 mb-15">

    </div>

    <v-container>
      <v-row>
        <v-col cols="6">
          <v-text-field
            bg-color="transparent"
            flat
            hide-details
            label="Your Name*"
            single-line
            variant="outlined"
          />
        </v-col>

        <v-col cols="6">
          <v-text-field
            bg-color="transparent"
            flat
            hide-details
            label="Email Address*"
            single-line
            variant="outlined"
          />
        </v-col>

        <v-col cols="6">
          <v-text-field
            bg-color="transparent"
            flat
            hide-details
            label="Phone Number*"
            single-line
            variant="outlined"
          />
        </v-col>

        <v-col cols="6">
          <v-text-field
            bg-color="transparent"
            flat
            hide-details
            label="Option*"
            single-line
            variant="outlined"
          />
        </v-col>

        <v-col cols="12">
          <v-textarea
            bg-color="transparent"
            flat
            hide-details
            label="Your Message..."
            lines="4"
            variant="outlined"
          />
        </v-col>
      </v-row>
    </v-container>

    <v-btn
      class="px-10 text-body-1"
      color="accent"
      flat
      height="55"
      text="GET IN TOUCH"
    />
  </v-sheet>
</template>
