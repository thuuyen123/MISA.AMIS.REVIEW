<template>
  <div
    ref="contextMenu"
    class="context-menu"
    id="contextMenu"
    :class="{ 'hide-context-menu': !isShow }"
  >
    <div class="context-menu-title" @click="btnClone">Nhân bản</div>
    <div class="context-menu-title" @click="btnDelete">Xóa</div>
    <div class="context-menu-title">Ngưng sử dụng</div>
  </div>
</template>

<script>
export default {
  directives: {},
  name: "BaseContextMenu",
  props: {
    isShow: {
      type: Boolean,
    },
  },
  data() {
    return {};
  },

  methods: {
    /**
     * Mở Dialog nhân bản nhân viên
     * CreatedBy:TTUyen (30/08/2021)
     */
    btnClone() {
      this.$emit("btnClone", false, "clone");
    },

    /**
     * Xóa nhân viên
     * CreatedBy:TTUyen (30/08/2021)
     */
    btnDelete() {
      this.$emit("btnDelete");
    },

  },
};
</script>
<style scoped>
@import "../../css/base/contextMenu.css";
/* .context-menu{
  display: none ;
} */
.hide-context-menu {
  display: none !important;
}
</style>