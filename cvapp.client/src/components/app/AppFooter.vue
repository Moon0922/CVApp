<template>
  <v-footer height="80">
    <v-row justify="center" no-gutters>
      <v-col class="text-center" cols="12">
        {{ new Date().getFullYear() }} — <strong>CVAPP</strong>
      </v-col>
    </v-row>
  </v-footer>
</template>

<style scoped lang="scss">

</style>

<script lang="ts">
import {defineComponent} from "vue";
export default defineComponent({
  name: "AppFooter",
  components: {}
});
</script>
