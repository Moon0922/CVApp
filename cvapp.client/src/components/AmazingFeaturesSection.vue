<template>
  <v-sheet id="features" class="text-center py-16">
    <div class="text-h4 font-weight-medium">
      Amazing Features
    </div>

    <div class="text-body-1 text-medium-emphasis my-5">
      Quis autem velis ets reprehender net etid quiste voluptate.
    </div>

    <v-container>
      <v-row>
        <v-col
          v-for="item in features"
          :key="item.title"
          class="d-flex ga-5 pa-5 text-left"
          cols="12"
          md="4"
        >
          <div class="mt-2">
            <v-img :src="item.icon" width="40" />
          </div>

          <div>
            <div class="text-h6 font-weight-bold">
              {{ item.title }}
            </div>

            <div class="text-body-1 text-medium-emphasis mt-2">
              {{ item.description }}
            </div>
          </div>
        </v-col>
      </v-row>
    </v-container>
  </v-sheet>
</template>

<script setup>
  const features = [
    {
      icon: '/assets/features/support.png',
      title: 'Support 24/7',
      description:
        'Utise wisi enim minim veniam, quis tation ullamcorper suscipit et loboti nisl consequat nihis.',
    },
    {
      icon: '/assets/features/user.png',
      title: 'User Friendly',
      description:
        'Utise wisi enim minim veniam, quis tation ullamcorper suscipit et loboti nisl consequat nihis.',
    },
    {
      icon: '/assets/features/bell.png',
      title: 'Notifications',
      description:
        'Utise wisi enim minim veniam, quis tation ullamcorper suscipit et loboti nisl consequat nihis.',
    },
    {
      icon: '/assets/features/accessibility.png',
      title: 'Accessibility',
      description:
        'Utise wisi enim minim veniam, quis tation ullamcorper suscipit et loboti nisl consequat nihis.',
    },
    {
      icon: '/assets/features/control.png',
      title: 'Control',
      description:
        'Utise wisi enim minim veniam, quis tation ullamcorper suscipit et loboti nisl consequat nihis.',
    },
    {
      icon: '/assets/features/chat.png',
      title: 'Chat With Friends',
      description:
        'Utise wisi enim minim veniam, quis tation ullamcorper suscipit et loboti nisl consequat nihis.',
    },
  ]
</script>
