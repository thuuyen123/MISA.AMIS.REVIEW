<template>
  <div class="amis-container">
    <TheMenu />
    <div class="content-container">
      <TheHeader />
      <div class="content-area">
        <router-view class="router-view"></router-view>
      </div>
    </div>
  </div>
</template>

<script>
import TheHeader from "./components/layout/TheHeader.vue";
import TheMenu from "./components/layout/TheMenu.vue";

export default {
  name: "App",
  components: {
    TheHeader,
    TheMenu,
  },
};
</script>
<style scoped>
@import "./css/main.css";
@import "./css/base/icon.css";

.amis-container {
  position: absolute;
  top: 0;
  bottom: 0;
  right: 0;
  left: 0;
  display: flex;
  box-sizing: border-box;
}
.content-container {
  flex-grow: 1;
}

.content-area {
  height: calc(100vh - 48px);
  background-color: #f4f5f8;
  flex: 1;
  border-top: 1px solid #dedede;
  position: relative;
  padding-left: 16px;
  padding-right: 16px;
}
</style>
