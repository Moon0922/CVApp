<template>
  <v-sheet
    id="team"
    class="text-center py-16"
    color="secondary"
    min-height="800"
  >
    <div class="text-h4 font-weight-bold">
      Meet Our Team
    </div>

    <div class="text-body-1 text-medium-emphasis mt-5">
      Discover more about our high performing team.
    </div>

    <v-container>
      <v-row>
        <v-col
          v-for="person in team"
          :key="person.name"
          class="pa-5"
          cols="12"
          md="4"
        >
          <v-card
            class="bg-white rounded-t-xl pb-5"
            flat
          >
            <v-img
              class="w-100 rounded-t-xl"
              :src="person.image"
            />

            <div class="mt-3 text-body-1">
              {{ person.name }}
            </div>

            <div class="mt-3 text-grey-lighten-1 font-italic text-body-1">
              {{ person.title }}
            </div>

            <div class="mt-5 text-medium-emphasis mx-5">
              {{ person.description }}
            </div>
          </v-card>
        </v-col>
      </v-row>
    </v-container>
  </v-sheet>
</template>

<script setup>
  const team = [
    {
      image: './assets/team/person1.png',
      name: 'CHRISTINA HAWKINS',
      title: 'Head of SEO',
      description:
        'Johnathan is our co-founder and has developed search strategies for a variety of clients for over 5 years.',
    },
    {
      image: './assets/team/person2.png',
      name: 'CHRISTINA HAWKINS',
      title: 'Head of SEO',
      description:
        'Johnathan is our co-founder and has developed search strategies for a variety of clients for over 5 years.',
    },
    {
      image: './assets/team/person3.png',
      name: 'CHRISTINA HAWKINS',
      title: 'Head of SEO',
      description:
        'Johnathan is our co-founder and has developed search strategies for a variety of clients for over 5 years.',
    },
  ]
</script>
