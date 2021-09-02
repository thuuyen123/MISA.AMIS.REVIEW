<template>
  <button
    class="m-btn"
    @click="btnClick"
  >
  <div v-if="isIcon=='true'" :class="['m-btn-icon',iconClass]"></div>
   <div class="m-btn-text" v-if="$slots.default" ><slot/></div>
  </button>

</template>

<script>
export default {
  name: "BaseButton",
  props: {
    subClass: String,
    iconClass: String,
    isIcon: String,
  },
  methods:{
    btnClick(){
      this.$emit('btn-click');
    }
  }
};
</script>
<style scoped>
@import "../../css/base/button.css"
</style>