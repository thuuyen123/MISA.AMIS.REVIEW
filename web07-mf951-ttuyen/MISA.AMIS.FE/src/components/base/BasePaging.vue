<template>
  <div class="layout-paging">
    <div class="paging-total-record">Tổng số: <strong>200</strong> bản ghi</div>
    <div class="paging-filter">
      <input type="text" name="" id="" />
      <div class="paging-container">
        <button
          class="paging-btn mr-1"
          id="pagingPrev"
        >
          Trước
        </button>
        <button class="paging-num  pageSelected">1</button>
        <button class="paging-num">2</button>
        <button class="paging-num">3</button>
        <div>...</div>
        <button class="paging-num">10</button>
        <button class="paging-btn ml-1" id="pagingNext">Sau</button>
      </div>
    </div>
  </div>
</template>
<script>
export default {
    name: "BasePaging",
};
</script>

<style scoped>
@import '../../css/base/paging.css'
</style>