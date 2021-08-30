<template>
  <div class="content">
    <div class="layout-header">
      <div class="title-layout">Nhân viên</div>
      <BaseButton
        tabindex="1"
        isIcon="false"
        id="btnAdd"
        @btn-click="btnShowDialog"
        subClass="m-btn-primary"
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
        @clone-btn-click="btnCloneOnClick"
        @delete-btn-click="btnDeleteOnClick"
      />
    </div>
    <div class="layout-footer">
      <BasePaging />
    </div>
    <div class="dialog">
      <EmployeeDetail :status="recordStatus" @btnCloseDialog="btnCloseDialog" />
    </div>
    <BaseLoader :hideLoader="isHideLoader" />
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
export default {
  components: {
    BaseButton,
    BaseInput,
    BaseTable,
    BasePaging,
    EmployeeDetail,
    BaseLoader,
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
      //Lấy trạng thái hiện tại để thêm/sửa 
      recordStatus:{
        isHide: true,
        formMode: "add",
        data: [],
      },
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
            style: "min-width: 125px",
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
            id: "EmployeePositionHead",
            style: "min-width: 150px",
            fieldname: "EmployeePosition",
            title: "Vị trí",
          },
          {
            id: "DepartmentNameHead",
            style: "min-width: 150px",
            fieldname: "DepartmentName",
            title: "Phòng ban",
          },
          {
            id: "AddressHead",
            style: "min-width: 200px; max-width: 200px;",
            fieldname: "Address",
            title: "Địa chỉ",
            position: "text-overflow-ellipsis",
          },
          {
            id: "MobilePhoneNumberHead",
            style: "min-width: 160px",
            fieldname: "MobilePhoneNumber",
            title: "Điện thoại di động",
          },
          {
            id: "LandlineNumberHead",
            style: "min-width: 160px",
            fieldname: "LandlineNumber",
            title: "Điện thoại cố định",
          },
          {
            id: "EmailHead",
            style: "min-width: 250px",
            fieldname: "Email",
            title: "Email",
          },
          {
            id: "BacnkAccountNumberHead",
            style: "min-width: 180px",
            fieldname: "BankAccountNumber",
            title: "Tài khoản ngân hàng",
          },
          {
            id: "BankNameHead",
            style: "min-width: 160px",
            fieldname: "BankName",
            title: "Ngân hàng",
          },
          {
            id: "BankBranchNameHead",
            style: "min-width: 200px",
            fieldname: "BankBranchName",
            title: "Chi nhánh ngân hàng",
          },
          {
            id: "CreatedDateHead",
            style: "min-width: 120px",
            fieldname: "CreatedDate",
            formattype: "ddmmyyyy",
            title: "Ngày tạo",
            position: "text-align-center",
          },
        ],
        data: [],
      },
    };
  },
  created() {
    this.loadData();
  },
  methods: {
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
     * Hàm hiển thị form
     */
    btnShowDialog() {
      this.recordStatus.isHide = false;
    },

    /**
     * Hàm đóng form
     */
    btnCloseDialog() {
      this.recordStatus.isHide = true;
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
      me.reloading();
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
          console.log("table");
          console.log(me.table.data);
          console.log(me.employees);

          // me.isChecked = new Array(me.employees.length).fill(false);
        })
        .catch((res) => {
          console.log(res);
          // this.showMessage(type.WARNING, [message.EXCEPTION_MSG]);
        });
      me.closeReloading();
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
    btnDeleteOnClick() {},
    btnCloneOnClick() {},
  },
};
</script>
<style scoped>
@import "../../css/layout/employee.css";
</style>