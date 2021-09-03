<template>
  <div class="content">
    <div class="layout-header">
      <div class="title-layout">Nhân viên</div>
      <BaseButton
        isIcon="false"
        id="btnAdd"
        @btn-click="changeStatusForm"
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
        ref="table"
        :tableData="table"
        @edit-btn-click="changeStatusForm"
        @show-option-click="showOptionOnClick"
      />
    </div>

    <div class="layout-footer">
      <BasePaging
        :totalRecord="totalRecord"
        :pageIndex="pageIndex"
        :pageSize="pageIndex"
        :totalPages="totalPages"
        @changePageIndex="changPageIndex"
      />
    </div>
    <div class="dialog">
      <EmployeeDetail
        :hideLoader="isHideLoader"
        :status="recordStatus"
        @btnCloseDialog="changeStatusForm"
        @reloadData="reloadData"
        @changeState="changeStatusForm"
      />
    </div>
    <BaseLoader :hideLoader="isHideLoader" />
    <BaseContextMenu
      ref="context"
      :isShow="isShowContextMenu"
      @btnClone="btnShowDialogClone"
      @btnDelete="btnShowDelete"
    />
    <BasePopup
      v-if="!isHidePopupDelete"
      btn1="Có"
      btn2="Không"
      type="confirm-del"
      icon="icon-warning"
      @close="btnCancleDelete"
      @confirm="btnConfirmDelete"
    >
      {{ contentTextDel }}
    </BasePopup>
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
import BasePopup from "../../components/base/BasePopup.vue";
import BaseContextMenu from "../../components/base/BaseContentMenu.vue";
import { eventBus } from "../../main.js";
import { MESSAGE, CONFIG } from "../../js/common/const";
export default {
  // directives: {
  //   onClickaway: onClickaway,
  // },
  components: {
    BaseButton,
    BaseInput,
    BaseTable,
    BasePaging,
    EmployeeDetail,
    BaseLoader,
    BaseContextMenu,
    BasePopup,
  },
  data() {
    return {
      isHideLoader: true,

      isHidePopupDelete: true,

      contentTextDel: "",

      employees: [],

      keySearch: "",

      totalRecord: 0,

      pageIndex: 1,

      pageSize: 10,

      totalPages: 1,

      isShowContextMenu: false,

      selectedId: String,

      recordStatus: {
        isHide: true,
        formMode: "add",
        data: [],
      },

      cloneData: [],

      table: {
        columns: [
          {
            id: "EmployeeCodeHead",
            style: "min-width: 150px;position: sticky; left: 55px; z-index: 5;",
            fieldname: "EmployeeCode",
            title: "Mã nhân viên",
            subClass: "background-color-white",
          },
          {
            id: "EmployeeNameHead",
            style:
              "min-width: 170px; max-width:170px; position: sticky; left: 205px; z-index: 5;",
            fieldname: "EmployeeName",
            title: "Họ và tên",
            subClass: "background-color-white",
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
            style: "min-width: 140px",
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
            id: "MobilePhoneNumberHead",
            style: "min-width: 150px",
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
            id: "AddressHead",
            style: "min-width: 200px; max-width: 200px;",
            fieldname: "Address",
            title: "Địa chỉ",
            position: "text-overflow-ellipsis",
          },
          {
            id: "EmailHead",
            style: "min-width: 150px;  max-width: 150px;",
            fieldname: "Email",
            title: "Email",
            position: "text-overflow-ellipsis",
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

      top: 1,

      termTop: 0,
    };
  },
  created() {
    /**
     * Load dữ liệu
     * CreateBy: TTUyen(29/08/2021)
     */
    this.loadData();

    /**
     * Hàm active menu 
     * CreateBy: TTUyen(29/08/2021)
     */
    eventBus.$emit("activeMenu");
    /**
     * Xử lý khi thay đổi số bản ghi trên trang
     * CreateBy: TTUyen(03/09/2021)
     */
    eventBus.$on("changePageSize", (pageSize) => {
      this.pageSize = pageSize;
      this.loadData();
    });
  },

  methods: {

    /**
     * Hàm hiển thị popup xác nhận xóa
     * CreateBy: TTUyen(02/09/2021)
     */
    btnShowDelete() {
      this.isHidePopupDelete = false;
      setTimeout(() => {
        var employeeCode = this.cloneData.EmployeeCode;
        this.contentTextDel = MESSAGE.DELETE_EMPLOYEE.format(
          "Nhân viên",
          employeeCode
        );
      }, 150);
    },

    /**
     * Hàm hủy xóa bản ghi
     * CreateBy: TTUyen(02/09/2021)
     */
    btnCancleDelete() {
      this.isHidePopupDelete = true;
    },

    /**
     * Hàm xóa dữ liệu trong database
     * CreateBy: TTUyen(02/09/2021)
     */
    async btnConfirmDelete() {
      let me = this;
      try {
        await axios
          .delete(CONFIG.MY_URL + `Employees/${me.cloneData.EmployeeId}`)
          .then((res) => {
            if (res.status == 200) {
              this.$toast.success(MESSAGE.DELETE_MSG_SUCCESS, {
                position: "bottom-right",
                timeout: 2000,
              });
            } else {
              this.$toast.error(MESSAGE.ERROR_DELETE_NOSUCCES, {
                position: "bottom-right",
                timeout: 2000,
              });
            }
          })
          .catch(() => {
            this.$toast.error(MESSAGE.EXCEPTION_MSG, {
              position: "bottom-right",
              timeout: 2000,
            });
          });
      } catch (error) {
        console.log(error);
      }
      me.reloadData();
      this.isHidePopupDelete = true;
      this.closeContextMenu();
    },
    /**
     * Hiển thị contextMenu
     * CreateBy: TTUyen(02/09/2021)
     */
    showOptionOnClick(data = [], top) {
      this.cloneData = data;
      console.log(this.cloneData);
      this.top = top;
      if (this.top == this.termTop) {
        this.isShowContextMenu = false;
        this.termTop = 0;
        return;
      }
      this.termTop = top;
      this.isShowContextMenu = true;
      this.$refs.context.$refs.contextMenu.style.top = this.top + 20 + "px";
      if (this.top > document.body.clientHeight - 150) {
        this.$refs.context.$refs.contextMenu.style.top = this.top - 96 + "px";
      }
      if (this.top == 0) this.isShowContextMenu = false;
    },
    /**
     * Đóng context menu
     * CreateBy: TTUyen(02/09/2021)
     */
    closeContextMenu() {
      this.isShowContextMenu = false;
    },
    /**
     * Hiển thị form dialog thông qua context menu
     * CreateBy: TTUyen(02/09/2021)
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
     * CreateBy: TTUyen(02/09/2021)
     */
    async changeStatusForm(isHide, formMode = "add", data = []) {
      console.log(isHide);
      this.recordStatus.isHide = false;

      setTimeout(() => {
        this.recordStatus = {
          isHide: isHide,
          formMode: formMode,
          data: data,
        };
        this.reloadData();
      }, 150);
    },

    /**
     * Hàm Ẩn/hiện Loader
     * CreateBy: TTUyen(01/09/2021)
     */
    reloading() {
      this.isHideLoader = false;
      setTimeout(() => {
        this.isHideLoader = true;
      }, 1500);
    },

    /**
     * Hàm tắt loader
     * CreateBy: TTUyen(28/08/2021)
     */
    closeReloading() {
      this.isHideLoader = true;
    },

    /**
     * Hàm phân lại trang khi thay đổi vị trí trang
     * CreateBy: TTUyen(01/09/2021)
     */
    changPageIndex(pageIndex) {
      this.pageIndex = pageIndex;
      this.loadData();
    },
    /**
     * Hiển thị theo lọc và phân trang
     * CreateBy: TTUyen(01/09/2021)
     */
    async reloadFilterPaging() {
      await this.loadData();
    },

    /**
     * Hàm làm mới lại data table, phân trang, trang hiện tại
     *  CreateBy: TTUyen(28/08/2021)
     */
    btnRefresh() {
      this.totalRecord = 0;
      this.pageIndex = 1;
      this.pageSize = 10;
      this.totalPages = 1;
      this.loadData();
      this.$toast.success(MESSAGE.RELOAD_SUCCESS, {
        position: "bottom-right",
        timeout: 2000,
      });
    },

    /**
     * Lấy dữ liệu từ database
     * CreateBy: TTUyen(28/08/2021)
     */
    async loadData() {
      let me = this;
      me.reloading();
      try {
        await axios
          .get(
            CONFIG.MY_URL +
              "Employees/Filter?keySearch=" +
              me.keySearch +
              "&pageSize=" +
              me.pageSize +
              "&pageIndex=" +
              me.pageIndex
          )
          .then((res) => {
            if (res.status != 204) {
              me.table.data = res.data.Data;
              me.totalPages = res.data.TotalPage;
              me.totalRecord = res.data.TotalRecord;
            } else {
              me.table.data = [];
              me.totalRecord = 0;
              me.totalPages = 1;
              this.$toast.info(MESSAGE.DATA_EMPTY, {
                position: "bottom-right",
                timeout: 2000,
              });
            }
          })
          .catch(() => {
            this.$toast.error(MESSAGE.EXCEPTION_MSG, {
              position: "bottom-right",
              timeout: 2000,
            });
          });
        me.closeReloading();
      } catch (error) {
        console.log(error);
      }
    },

    /**
     * Xuất khẩu dữ liệu từ bảng ra file .xlsx
     *  CreateBy: TTUyen(01/09/2021)
     */
    async btnExportData() {
      let me = this;
      me.reloading();
      try {
        await axios
          .get(`${CONFIG.MY_URL}Employees/Export`, { responseType: "blob" })
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
              this.$toast.info(MESSAGE.DATA_EMPTY, {
                position: "bottom-right",
                timeout: 2000,
              });
            }
          })
          .catch(() => {
            this.$toast.info(MESSAGE.EXCEPTION_MSG, {
              position: "bottom-right",
              timeout: 2000,
            });
          });
      } catch (e) {
        console.log(e);
      }
      me.closeReloading();
    },

    /**
     * Tải lại dữ liệu
     */
    reloadData() {
      this.loadData();
    },
    // btnCloneOnClick() {},
  },
};
</script>
<style scoped>
@import "../../css/layout/employee.css";
</style>