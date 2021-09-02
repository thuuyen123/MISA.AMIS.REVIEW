<template>
  <div class="content">
    <div class="layout-header">
      <div class="title-layout">Nhân viên</div>
      <BaseButton
        tabindex="1"
        isIcon="false"
        id="btnAdd"
        @btn-click="btnShowDialog"
        type="primary"
      >
        Thêm mới nhân viên
      </BaseButton>
    </div>
    <div class="layout-body">
      <div class="layout-filter">
        <BaseInput
          icon="icon-search"
          placeHolder="Tìm kiếm theo mã, tên, số điện thoại"
          type="text"
          name=""
          value=""
          ref="inputSearchBox"
          v-model="keySearch"
          @search="reloadFilterPaging"
        />
        <div class="m-btn-refresh sprite icon-refresh" @click="btnRefresh" />
        <div class="m-btn-export sprite icon-export" @click="btnExportData" />
      </div>
      <BaseTable
        :tableData="table"
        @edit-btn-click="btnShowDialog"
        @show-option-click="showOptionOnClick"
      />
    </div>

    <div class="layout-footer">
      <BasePaging />
    </div>
    <div class="dialog">
      <EmployeeDetail
        :hideLoader="isHideLoader"
        :status="recordStatus"
        @btnCloseDialog="btnCloseDialog"
        @reloadData="reloadData"
      />
    </div>
    <BaseLoader :hideLoader="isHideLoader" />
    <BaseContextMenu
      v-on-clickaway="away"
      :isShow="isShowContextMenu"
      @btnClone="btnShowDialogClone"
      @btnDelete="btnShowDelete"
    />
  </div>
</template>
<script>
import axios from "axios";
import BaseButton from "../../components/base/BaseButton.vue";
import BaseInput from "../../components/base/BaseInput.vue";
import BaseTable from "../../components/base/BaseTable.vue";
import BasePaging from "../../components/base/BasePaging.vue";
import EmployeeDetail from "../employee/EmployeeDetail.vue";
import BaseLoader from "../../components/base/BaseLoader.vue";
import BaseContextMenu from "../../components/base/BaseContentMenu.vue";
import { directive as onClickaway } from "vue-clickaway";

import { eventBus } from "../../main.js";
export default {
  directives: {
    onClickaway: onClickaway,
  },
  components: {
    BaseButton,
    BaseInput,
    BaseTable,
    BasePaging,
    EmployeeDetail,
    BaseLoader,
    BaseContextMenu,
  },
  data() {
    return {
      isHideLoader: true,
      // isHideDialog: true,
      employees: [],
      keySearch: "",
      totalRecord: 0,
      pageIndex: 1,
      pageSize: 10,
      totalPages: 1,
      isShowContextMenu: false,
      selectedId: String,
      //Lấy trạng thái hiện tại để thêm/sửa
      recordStatus: {
        isHide: true,
        formMode: "add",
        data: [],
      },

      cloneData: [],
      myUrl: "https://localhost:44331/api/v1/",
      table: {
        columns: [
          {
            id: "EmployeeCodeHead",
            style: "min-width: 150px",
            fieldname: "EmployeeCode",
            title: "Mã nhân viên",
          },
          {
            id: "EmployeeNameHead",
            style: "min-width: 200px",
            fieldname: "EmployeeName",
            title: "Họ và tên",
          },
          {
            id: "GenderHead",
            style: "min-width: 100px",
            fieldname: "GenderName",
            title: "Giới tính",
          },
          {
            id: "DateOfBirthHead",
            style: "min-width: 120px",
            fieldname: "DateOfBirth",
            formattype: "ddmmyyyy",
            title: "Ngày sinh",
            position: "text-align-center",
          },
          {
            id: "IdentityNumberHead",
            style: "min-width: 180px",
            fieldname: "IdentityNumber",
            title: "Số CMND",
          },
          {
            id: "EmployeePositionHead",
            style: "min-width: 150px",
            fieldname: "EmployeePosition",
            title: "Chức danh",
          },
          {
            id: "DepartmentNameHead",
            style: "min-width: 150px",
            fieldname: "DepartmentName",
            title: "Tên đơn vị",
          },
          {
            id: "BankAccountNumberHead",
            style: "min-width: 180px",
            fieldname: "BankAccountNumber",
            title: "Tài khoản ngân hàng",
          },
          {
            id: "BankNameHead",
            style: "min-width: 140px",
            fieldname: "BankName",
            title: "Ngân hàng",
          },
          {
            id: "BankBranchNameHead",
            style: "min-width: 200px",
            fieldname: "BankBranchName",
            title: "Chi nhánh ngân hàng",
          },
        ],
        data: [],
      },

      top: 0,
    };
  },
  created() {
    this.loadData();
    this.loadAllData();
    eventBus.$emit("activeMenu");
  },
  methods: {
    away: function () {
      this.isShowContextMenu = false;
    },

    btnShowDelete() {
      console.log("1");
    },
    /**
     *Hiển thị contextMenu
     */
    showOptionOnClick(isShowMenu, data = []) {
      (this.isShowContextMenu = isShowMenu), (this.cloneData = data);
      console.log(this.cloneData);
    },

    /**
     * Đóng context menu
     */
    closeContextMenu() {
      this.isShowContextMenu = false;
    },
    /**
     * Hiển thị form dialog thông qua context menu
     */
    async btnShowDialogClone(isHide, formMode = "add") {
      this.recordStatus = {
        isHide: isHide,
        formMode: formMode,
        data: this.cloneData,
      };
      console.log(this.recordStatus);
      this.closeContextMenu();
    },
    /**
     * Hiển thị form dialog
     */
    async btnShowDialog(isHide, formMode = "add", data = []) {
      console.log(isHide);
      this.recordStatus = {
        isHide: isHide,
        formMode: formMode,
        data: data,
      };
    },

    async loadAllData() {
      let me = this;
      me.reloading();
      try {
        await axios
          .get(me.myUrl + "Employees")
          .then((res) => {
            if (res.status != 204) {
              me.employees = res.data.Data;
            } else {
              me.employees = [];
            }
          })
          .catch((res) => {
            console.log(res);
          });
        me.closeReloading();
      } catch (error) {
        console.log(error);
      }
    },
    /**
     * Hàm Ẩn/hiện Loader
     * Uyen 12/8/2021
     */
    reloading() {
      this.isHideLoader = false;
      setTimeout(() => {
        this.hideLoader = true;
      }, 2000);
    },

    /**
     * Hàm tắt reloader
     */
    closeReloading() {
      this.isHideLoader = true;
    },

    /**
     * Hàm đóng form
     */
    btnCloseDialog() {
      this.loadData();
      this.recordStatus={
        isHide : true,
        // formMode : "add",
        // data: [],
      }
    },

    /**
     * Hiển thị theo lọc và phân trang
     */
    async reloadFilterPaging() {
      await this.loadData();
    },

    /**
     * Hàm làm mới lại data table, phân trang, trang hiện tại
     */
    btnRefresh() {
      this.totalRecord = 0;
      this.pageIndex = 1;
      this.pageSize = 10;
      this.totalPages = 1;
      this.loadData();
    },

    /**
     * Lấy dữ liệu từ database
     */
    async loadData() {
      let me = this;
      me.pageSize = 50;
      me.reloading();
      try {
        await axios
          .get(
            me.myUrl +
              "Employees/Filter?keySearch=" +
              me.keySearch +
              "&pageSize=" +
              me.pageSize +
              "&pageIndex=" +
              me.pageIndex
          )
          .then((res) => {
            if (res.status != 204) {
              // me.employees = res.data.Data;
              me.table.data = res.data.Data;
              me.totalPages = res.data.TotalPage;
              me.totalRecord = res.data.TotalRecord;
            } else {
              // me.employees = [];
              me.table.data = [];
              me.totalRecord = 0;
              me.totalPages = 1;
              // this.showMessage(type.WARNING, [message.DATA_EMPTY]);
            }
            // me.isChecked = new Array(me.employees.length).fill(false);
          })
          .catch((res) => {
            console.log(res);
            // this.showMessage(type.WARNING, [message.EXCEPTION_MSG]);
          });
        me.closeReloading();
      } catch (error) {
        console.log(error);
      }
    },

    /**
     * Xuất khẩu dữ liệu từ bảng ra file .xlsx
     */
    async btnExportData() {
      let me = this;
      me.reloading();
      await axios
        .get(
          me.myUrl +
            "Employees/Export?keySearch=" +
            me.keySearch +
            "&pageSize=" +
            me.pageSize +
            "&pageIndex=" +
            me.pageIndex
        )
        .then((res) => {
          if (res.status != 204) {
            const url = window.URL.createObjectURL(new Blob([res.data]));
            const a = document.createElement("a");
            a.href = url;
            const filename = `Danh_sach_nhan_vien.xlsx`;
            a.setAttribute("download", filename);
            document.body.appendChild(a);
            a.click();
            a.remove();
          } else {
            console.log("empty");
          }
        })
        .catch((res) => {
          console.log(res);
          // this.showMessage(type.WARNING, [message.EXCEPTION_MSG]);
        });
      me.closeReloading();
    },
    reloadData(){
      this.loadData();
      // this.recordStatus={
      //   isHide : true,
      //   formMode : "add",
      //   data: [],
      // }
    },
    btnDeleteOnClick() {},
    btnCloneOnClick() {},
  },
};
</script>
<style scoped>
@import "../../css/layout/employee.css";
</style>