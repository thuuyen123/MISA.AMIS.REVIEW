<template>
  <div class="layout-paging">
    <div class="paging-total-record">Tổng số: <strong>{{totalRecord}}</strong> bản ghi</div>
    <div class="paging-filter">
      <input type="text" name="" id="" />
      <!-- <div class="paging-container">
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
      </div> -->
      <div class="paging-container">
        <Paginate
          :page-count="totalPages"
          :page-range="3"
          :margin-pages="1"
          :click-handler="clickCallback"
          :prev-text="'Trước'"
          :next-text="'Sau'"
          :container-class="'paging-container'"
          :page-class="'paging-num '"
          :prev-link-class="'paging-btn mr-1'"
          :next-link-class="'paging-btn ml-1'"
        />
      </div>
    </div>
  </div>
</template>
<script>
import Paginate from "vuejs-paginate";
export default {
  name: "BasePaging",
  components: {
    Paginate,
  },
  props: {
    totalRecord: Number,
    pageIndex: Number,
    pageSize: Number,
    totalPages: Number,
  },
  methods: {
    clickCallback(){

    }
  },
};
</script>

<style scoped>
@import "../../css/base/paging.css";
</style>