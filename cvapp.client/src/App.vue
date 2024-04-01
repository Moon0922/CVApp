<template>
  <v-app>
    <AppBar/>
    <v-main>
      <router-view/>
    </v-main>
    <ContactUsSection />
    <AppFooter/>
  </v-app>
</template>

<script lang="ts">

import {defineComponent} from "vue";
import {mapState, mapActions, mapMutations, mapGetters} from "vuex";
import AppBar from "@/components/app/AppBar.vue";
import router from "@/router";
import AppFooter from "@/components/app/AppFooter.vue"

export default defineComponent({
  name: "App",
  components: {AppBar, AppFooter},
  setup() {
    return {};
  },
  data: () => ({}),
  watch: {},
  computed: {
    ...mapState([]),
    ...mapGetters([]),
  },
  methods: {
    ...mapActions([]),
    ...mapMutations([]),
    functionTemplate: function () {
    },
  },
  created() {
  },
  mounted() {
    //router.push("/");
  },
  unmounted() {
  },
  destoryed() {
  },
});
</script>

<style scoped lang="scss"></style>
<style lang="scss">
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  color: #000000;
}
</style>
