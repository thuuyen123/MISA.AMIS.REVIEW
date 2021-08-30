<template>
  <div class="menu-container expand">
    <div class="menu-logo">
      <div class="sprite icon-menu"></div>
      <div class="logo"></div>
      <div class="sprite icon-toggle-light" style="display: none"></div>
    </div>
    <div class="menu-content">
      <router-link class="menu-item" to="/inUpdating">
        <div class="menu-item-icon sprite icon-pie-chart"></div>
        <div class="menu-item-text">Tổng quan</div>
      </router-link>
      <router-link class="menu-item" to="/employee">
        <div class="menu-item-icon sprite icon-money-draw"></div>
        <div class="menu-item-text">Tiền mặt</div>
      </router-link>
      <router-link class="menu-item" to="/inUpdating">
        <div class="menu-item-icon sprite icon-bank"></div>
        <div class="menu-item-text">Tiền gửi</div>
      </router-link>
      <router-link class="menu-item" to="/inUpdating">
        <div class="menu-item-icon sprite icon-bag"></div>
        <div class="menu-item-text">Mua hàng</div>
      </router-link>
      <router-link class="menu-item" to="/inUpdating">
        <div class="menu-item-icon sprite icon-cart"></div>
        <div class="menu-item-text">Bán hàng</div>
      </router-link>
      <router-link class="menu-item" to="/inUpdating">
        <div class="menu-item-icon sprite icon-document"></div>
        <div class="menu-item-text">Quản lý hóa đơn</div>
      </router-link>
      <router-link class="menu-item" to="/inUpdating">
        <div class="menu-item-icon sprite icon-warehouse"></div>
        <div class="menu-item-text">Kho</div>
      </router-link>
      <router-link class="menu-item" to="/inUpdating">
        <div class="menu-item-icon sprite icon-tools"></div>
        <div class="menu-item-text">Công dụng dụng cụ</div>
      </router-link>
      <router-link class="menu-item" to="/inUpdating">
        <div class="menu-item-icon sprite icon-assets"></div>
        <div class="menu-item-text">Tài sản cố định</div>
      </router-link>
      <router-link class="menu-item" to="/inUpdating">
        <div class="menu-item-icon sprite icon-government"></div>
        <div class="menu-item-text">Thuế</div>
      </router-link>
      <router-link class="menu-item" to="/inUpdating">
        <div class="menu-item-icon sprite icon-price-tag"></div>
        <div class="menu-item-text">Giá thành</div>
      </router-link>
      <router-link class="menu-item" to="/inUpdating">
        <div class="menu-item-icon sprite icon-notebook"></div>
        <div class="menu-item-text">Tổng hợp</div>
      </router-link>
      <router-link class="menu-item" to="/inUpdating">
        <div class="menu-item-icon sprite icon-dollar-coin"></div>
        <div class="menu-item-text">Ngân sách</div>
      </router-link>
      <router-link class="menu-item" to="/inUpdating">
        <div class="menu-item-icon sprite icon-bar-chart"></div>
        <div class="menu-item-text">Báo cáo</div>
      </router-link>
      <router-link class="menu-item" to="/inUpdating">
        <div class="menu-item-icon sprite icon-graph"></div>
        <div class="menu-item-text">Phân tích tài chính</div>
      </router-link>
    </div>
  </div>
</template>

<script>
export default {
  name: "TheMenu",
};
</script>
<style lang="scss" scoped>
@import "../../css/layout/menu.css";

</style>
