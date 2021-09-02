<template>
  <div class="m-popup">
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
          type="secondary"
          @btn-click="closePopup"
          id="pop-2"
          :tabindex="1"
        >
          {{ $attrs.btn2 }}
        </BaseButton>
        <div>
          <BaseButton
            type="secondary"
            id="pop-3"
            :tabindex="2"
            @btn-click="cancelPopup"
          >
            {{ $attrs.btn3 }}
          </BaseButton>
          <BaseButton
            type="primary"
            @btn-click="confirmPopup"
            id="pop-1"
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
<style lang="scss" scoped>
@import "../../css/base/popup.css";
.m-popup[type="alert"] {
  .pop-option {
    justify-content: center;
    #pop-2,
    #pop-3 {
      display: none;
    }
  }
}
.m-popup[type="warning"] {
  .pop-option {
    justify-content: flex-end;
  }

  #pop-2,
  #pop-3 {
    display: none;
  }
}
</style>