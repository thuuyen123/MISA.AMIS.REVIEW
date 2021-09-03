<template>
  <div class="layout-paging">
    <div class="paging-total-record">Tổng số: <strong>{{totalRecord}}</strong> bản ghi</div>
    <div class="paging-filter">
     <BaseCombobox/>
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
import BaseCombobox from '../base/BaseCombobox.vue'
export default {
  name: "BasePaging",
  components: {
    Paginate,
    BaseCombobox,
  },
  props: {
    totalRecord: Number,
    pageIndex: Number,
    pageSize: Number,
    totalPages: Number,
  },
  methods: {
    /**
     * Hàm xử lý khi thay đổi trang
     * CreateBy: TTUyen (30/8/2021)
     */
    clickCallback(pageNum){
        this.$emit("changePageIndex", pageNum);
    }
  },
};
</script>

<style scoped>
@import "../../css/base/paging.css";
</style>