<template>
  <div
    class="field-input"
    :class="{
      'icon-field-input': icon,
    }"
    :id="id"
  >
    <input
      ref="input"
      @input="$emit('input', $event.target.value)"
      @keyup.enter="inputSearchOnEnter"
      v-bind="$attrs"
    />
    <div v-if="icon" class="field-icon sprite" :class="icon"></div>
  </div>
</template>
<script>
export default {
  name: "BaseInput",
  props: {
    icon: String,
    value: String,
    id: String,
    required: {
      type: Boolean,
      default: false,
    },
    fieldType: {
      type: String,
    },
    displayName: {
      type: String,
      default: "",
    },
    modelValue: {
      type: String,
    },
  },
  methods: {
    inputSearchOnEnter() {
      this.$emit("search");
    },
  },
};
</script>
<style scoped>
@import "../../css/base/input.css";
</style>