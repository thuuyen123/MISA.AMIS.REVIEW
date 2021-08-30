<template>
  <div :class="['model-loader']" v-if="!hideLoader">
    <!-- {'hide-loader': hideLoader} -->
    <div class="loader">
      <div class="lds-roller">
        <div></div>
        <div></div>
        <div></div>
        <div></div>
        <div></div>
        <div></div>
        <div></div>
        <div></div>
      </div>
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
.model-loader {
    top: 0;
    right: 0;
    left: 0;
    bottom: 0;
    position: fixed;
    /* background-color: rgba(0, 0, 0, 0.4); */
    z-index: 100;
}

</style>