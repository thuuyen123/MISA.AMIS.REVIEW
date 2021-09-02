<template>
  <div>
    <table class="content-table" border="0" cellspacing="0">
      <thead>
        <tr>
          <th
            style="left: 0px; min-width: 16px"
            class="sticky-cell-header cell-empty"
          ></th>
          <th
            id="checkbox-all"
            class="sticky-cell-header"
            style="left: 16px; min-width: 16px"
          >
            <input type="checkbox" class="" v-model="checkAll" />
          </th>
          <th
            v-for="(item, index) in tableData.columns"
            :key="item.id + index"
            :id="item.id"
            :style="item.style"
            :fieldname="item.fieldname"
            :formattype="item.formattype ? item.formattype : ''"
          >
            <div :class="item.position">
              <span>{{ item.title }}</span>
            </div>
          </th>
          <th
            id="table-option-header"
            key="table-option-header"
            class="option-header sticky-cell-header"
            style="right: 24px; min-width: 120px"
          >
            <div class="text-align-center">
              <span>Chức năng</span>
            </div>
          </th>
          <th
            class="sticky-cell-header cell-empty"
            style="right: 0px; min-width: 24px"
          ></th>
        </tr>
      </thead>
      <tbody ref="tableBody">
        <tr
          v-for="(record, index) in tableData.data"
          :key="'record' + index"
          :id="'record' + index"
          @dblclick="btnEditOnClick(index)"
        >
          <td
            :id="'outter-left-cell-' + index"
            :key="'outter-left-cell-' + index"
            class="sticky-cell-body cell-empty"
            style="left: 0px; min-width: 16px"
          ></td>
          <td class="sticky-cell-body" style="left: 16px; min-width: 16px">
            <input
              type="checkbox"
              class=""
              :id="'checkbox-' + index"
              :checked="checkAll"
            />
          </td>
          <td
            v-for="(column, idx) in tableData.columns"
            :key="'td' + index + '' + idx"
            :id="'td' + index + '' + idx"
            :style="column.style"
            :title="formatData(record[column.fieldname], column.formattype)"
          >
            <div :class="column.position">
              <span>{{
                formatData(record[column.fieldname], column.formattype)
              }}</span>
            </div>
          </td>
          <td
            :id="'row-option-' + index"
            :key="'row-option-' + index"
            class="sticky-cell-body row-option"
            style="right: 24px"
          >
            <div class="option-feature">
              <div class="feature-text" @click="btnEditOnClick(index)">Sửa</div>
              <button ref="myButton" :active="index == selectedRow">
                <div
                  class="sprite icon-arrow-down-blue"
                  @click="btnShowOption(index)"
                ></div>
              </button>
            </div>
          </td>
          <td
            :id="'outter-right-cell-' + index"
            :key="'outter-right-cell-' + index"
            class="sticky-cell-body cell-empty"
            style="right: 0px; min-width: 24px"
          ></td>
        </tr>
      </tbody>
    </table>
    <div class="no-data" v-if="tableData.data.length <= 0">
      <div class="no-data-img"></div>
      <div class="no-data-text">Không có dữ liệu</div>
    </div>
  </div>
</template>
<script>
import dayjs from "dayjs";

export default {
  name: "BaseTable",
  props: {
    tableData: {
      data: {
        type: Array,
      },
      columns: {
        type: Array,
      },
    },
  },
  data() {
    return {
      // hàng đang được chọn
      selectedRow: -1,

      //Chọn hết checkbox
      checkAll: false,

      checkingRow: [],

      top: 0,
    };
  },
  components: {},

  methods: {
    btnShowOption(index) {
      console.log(this.tableData.data[index]);
      // this.top = this.$refs.myButton[0].getBoundingClientRect().top;
      this.$emit(
        "show-option-click",       
        true,
        this.tableData.data[index],
      );
    },
    /**
     * Hàm emit khi bấm sửa
     */
    btnEditOnClick(index) {
      this.$emit("edit-btn-click", false, "edit", this.tableData.data[index]);
    },
      /**
       * Hàm emit nhân bản bản ghi
       * CreateBy: TTUyen (30/8/2021)
       */
      btnCloneOnClick() {
        this.$emit("clone-btn-click");
      },

      /**
       * Hàm emit xóa bản ghi
       * CreateBy TTUyen (30/8/2021)
       */
      btnDeleteOnClick() {
        this.$emit("delete-btn-click");
      },

    /**
     * Hàm format date
     * CreateBy TTUyen (30/8/2021)
     */
    formatData(str, formatType) {
      if (formatType) {
        str = this.formatDateDMY(str);
      }
      return str;
    },
    /**
     * Hàm format date sang dạng dd/mm/yyyy
     * CreateBy TTUyen (30/8/2021)
     */
    formatDateDMY(date) {
      if (date == null) {
        return "";
      }
      return dayjs(date).format("DD/MM/YYYY");
    },
  },
};
</script>
<style scoped>
@import "../../css/base/table.css";
</style>