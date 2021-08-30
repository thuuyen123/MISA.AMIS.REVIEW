<template>
  <div
    class="context-menu"
    id="contextMenu"
    v-if="isShow"
  >
    <div class="context-menu-title" @click="btnClone">Nhân bản</div>
    <div class="context-menu-title" @click="btnDelete">Xóa</div>
    <div class="context-menu-title">Ngưng sử dụng</div>
  </div>
</template>

<script>
export default {
  name: "BaseContextMenu",
  props: {
    isShow: {
      type: Boolean,
    },
    positionX: String,
    positionY: String,
  },
  data() {
    return {
    };
  },


  methods: {
    /**
     * Mở Dialog nhân bản nhân viên
     * CreatedBy:TTUyen (30/08/2021)
     */
    btnClone() {
      this.$emit("btnClone");
    },

    /**
     * Xóa nhân viên
     * CreatedBy:TTUyen (30/08/2021)
     */
    btnDelete() {
      this.$emit("btnDelete");
    },
  }
}
</script>
<style scoped>
@import "../../css/base/contextMenu.css";
</style>