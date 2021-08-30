<template>
  <div class="model-popup">
    <div class="popup-container">
      <div class="pop-content">
        <div class="pop-icon-container">
          <div class="pop-icon sprite" :class="icon"></div>
        </div>
        <div class="pop-text">
          <p>
            <slot></slot>
          </p>
        </div>
      </div>
      <div class="pop-option">
        <BaseButton
          subClass="m-btn-secondary"
          @btn-click="closePopup"
          id="btnPopClose"
          :tabindex="1"
        >
          {{ $attrs.btn2 }}
        </BaseButton>
        <div>
          <BaseButton
            subClass="m-btn-secondary"
            id="btnPopCancel"
            :tabindex="2"
            @btn-click="cancelPopup"
          >
            {{ $attrs.btn3 }}
          </BaseButton>
          <BaseButton
            subClass="m-btn-primary"
            @btn-click="confirmPopup"
            id="btnPopConfirm"
            :tabindex="3"
          >
            {{ $attrs.btn1 }}
          </BaseButton>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import BaseButton from "../base/BaseButton.vue";
export default {
  components: {
    BaseButton,
  },
  props: {
    open: {
      type: Boolean,
      default: false,
    },
    icon: String,
  },
  methods: {
    /**
     * Đóng popup
     */
    closePopup() {
      this.$emit("close");
    },

    /**
     * Hủy popup
     */
    cancelPopup() {
      this.$emit("cancel");
    },

    /**
     * Handle bấm xác nhận
     */
    confirmPopup() {
      this.$emit("confirm");
    },
  },
};
</script>
<style scoped>
@import "../../css/base/popup.css";
</style>