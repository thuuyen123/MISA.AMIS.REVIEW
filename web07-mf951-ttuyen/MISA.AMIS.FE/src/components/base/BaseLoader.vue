<template>
  <div class="model-loader" v-if="!hideLoader">
    <div class="loader">
      <img src="../../assets/img/loading.svg" alt="">
    </div>
  </div>
</template>

<script>
export default {
  name: "BaseLoader",

  props: {
    hideLoader:{
      type: Boolean,
      default: true,
    },
  },

  methods: {},

  watch: {},
};
</script>

<style scoped>
@import "../../css/base/loader.css";
</style>