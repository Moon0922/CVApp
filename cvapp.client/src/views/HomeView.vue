<template>

  <LandingSection />

  <WhatWeDoSection />

  <DiscoverHelp />

  <CustomizeSection />

  <FunFactsSection />

  <AmazingFeaturesSection />

  <FAQSection />
</template>

<script lang="ts">
import {defineComponent} from "vue";
import {mapState, mapActions, mapMutations, mapGetters} from "vuex";

export default defineComponent({
  name: "HomeView",
  components: {},
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
  },
  created() {
    console.log("test");
  },
  mounted() {
    console.log("test1");
  },
  unmounted() {
  },
  destoryed() {
  },
});
</script>
