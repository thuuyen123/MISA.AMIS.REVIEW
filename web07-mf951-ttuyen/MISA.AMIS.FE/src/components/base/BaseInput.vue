<template>
  <div
    class="field-input"
    :class="{
      'icon-field-input': icon,
      'input-border-red': !(isRequiredValid && isValid) && !focusing,
    }"
    :id="id"
    :title="tooltip"
  >
    <input
      ref="input"
      :value="value"
      @input="onInput($event.target.value)"
      @keyup.enter="inputSearchOnEnter"
      @blur="onBlur($event.target.value)"
      @focus="onInputFocus"
      v-bind="$attrs"
    />
    <div v-if="icon" class="field-icon sprite" :class="icon"></div>
  </div>
</template>
<script>
import { MESSAGE } from "../../js/common/const";
import { CommonFn } from "../../js/common/common";
export default {
  name: "BaseInput",

  data() {
    return {
      //Nội dung title khi validate dữ liệu
      tooltip: "",

      //input được focus
      focusing: false,

      // Kiểm tra đã hợp lệ chưa
      isValid: true,

      // Kiểm tra required không rỗng
      isRequiredValid: true,

    };
  },
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
  },
  watch: {},
  methods: {
    onInputFocus() {
      this.focusing = true;
    },
    /**
     * Hàm lọc theo input tìm kiếm
     */
    inputSearchOnEnter() {
      this.$emit("search");
    },
    /**
     * Hàm nhập input
     */
    onInput(value) {
      let me = this;
      me.$emit("input", value);
      me.validateInput(value);
    },
    onBlur(value) {
      this.focusing = false;
      let me = this;
      me.validateInput(value);
    },

    validateInput(value) {
      let me = this;
      //Kiểm tra nhập các trường bắt buộc
      if (!me.required && value == "") {
        me.isValid = true;
        me.isRequiredValid = true;
        return;
      }

      //Rỗng và bắt buộc
      if (value == "" && me.required) {
        me.isRequiredValid = false;
        me.tooltip = MESSAGE.CANT_BE_NULL.format(me.displayName);
        return;
      } else {
        me.isRequiredValid = true;
      }

      switch (me.fieldType) {
        case "email":
          me.isValid = CommonFn.isEmail(value);
          me.tooltip = me.isValid ? "" : MESSAGE.INVALID_EMAIL;
          break;
        case "number":
          me.isValid = CommonFn.checkNumberOnly(value);
          me.tooltip = me.isValid
            ? ""
            : MESSAGE.INVALID_NUMBER.format(me.displayName);
          break;

      }
      if (me.isRequiredValid && me.isValid) {
        me.tooltip = "";
      }
    },
  },
};
</script>
<style scoped>
@import "../../css/base/input.css";
</style>