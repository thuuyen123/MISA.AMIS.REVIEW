<template>
  <div class="dialog-detail" v-if="!status.isHide">
    <div class="model">
      <div class="dialog-content">
        <div class="dialog-header">
          <span>Thông tin nhân viên</span>
          <div class="components-checkbox">
            <input type="checkbox" name="isCustomer" />
            <label for="">Là khách hàng</label>
          </div>
          <div class="components-checkbox">
            <input type="checkbox" name="isProvider" />
            <label for="">Là nhà cung cấp</label>
          </div>
          <div class="dialog-header-options">
            <div class="m-btn-question sprite icon-question-mark"></div>
            <div
              class="m-btn-close sprite icon-x"
              @click="btnCloseDialog"
            ></div>
          </div>
        </div>

        <div class="dialog-content-form">
          <div class="form-block-1">
            <BaseLabel :required="true" label="Mã">
              <BaseInput
                ref="inputEmployeeCode"
                id="txtEmployeeCode"
                type="text"
                fieldType="employeeCode"
                displayName="Mã"
                value=""
                placeholder=""
                :required="true"
                v-model="employeeDetail.EmployeeCode"
              />
            </BaseLabel>
            <BaseLabel :required="true" label="Tên">
              <BaseInput
                ref="inputEmployeeName"
                id="txtEmployeeName"
                type="text"
                fieldType="name"
                displayName="Tên"
                value=""
                placeholder=""
                :required="true"
                v-model="employeeDetail.EmployeeName"
              />
            </BaseLabel>
            <BaseLabel :required="true" label="Đơn vị">
              <BaseDropdownDepartment
                ref="inputDepartment"
                id="txtDepartment"
                type="text"
                fieldType="department"
                displayName="Đơn vị"
                value=""
                placeholder=""
                :required="true"
                itemId="DepartmentId"
                itemName="DepartmentName"
                itemCode="DepartmentCode"
                :selectedId="employeeDetail.DepartmentId"
                v-model="employeeDetail.DepartmentId"
              />
            </BaseLabel>
            <BaseLabel label="Chức danh">
              <BaseInput
                ref="inputEmployeePosition"
                id="txtEmployeePosition"
                type="text"
                displayName="Chức danh"
                value=""
                placeholder=""
                v-model="employeeDetail.EmployeePosition"
              />
            </BaseLabel>
          </div>
          <div class="form-block-2">
            <BaseLabel label="Ngày sinh">
              <BaseInput
                ref="inputDateOfBirth"
                id="txtDateOfBirth"
                type="date"
                displayName="Ngày sinh"
                value=""
                placeholder=""
                v-model="employeeDetail.DateOfBirth"
              />
            </BaseLabel>

            <BaseLabel label="Giới tính">
              <div class="field-gender">
                <input
                  v-model="employeeDetail.Gender"
                  type="radio"
                  id="html"
                  name="Gender"
                  :value="1"
                />
                <label :for="1">Nam</label>
                <input
                  v-model="employeeDetail.Gender"
                  type="radio"
                  id="css"
                  name="Gender"
                  :value="0"
                />
                <label :for="0">Nữ</label>
                <input
                  v-model="employeeDetail.Gender"
                  type="radio"
                  id="css"
                  name="Gender"
                  :value="2"
                />
                <label :for="2">Khác</label>
              </div>
            </BaseLabel>
            <BaseLabel label="Số CMND">
              <BaseInput
                ref="inputIdentityNumber"
                id="txtIdentityNumber"
                type="text"
                displayName="Số CMND"
                fieldType="number"
                value=""
                placeholder=""
                v-model="employeeDetail.IdentityNumber"
              />
            </BaseLabel>
            <BaseLabel label="Ngày cấp">
              <BaseInput
                ref="inputIdentityDate"
                id="dtIdentityDate"
                type="date"
                displayName="Ngày cấp"
                value=""
                placeholder="DD/MM/YYYY"
                v-model="employeeDetail.IdentityDate"
              />
            </BaseLabel>
            <BaseLabel label="Nơi cấp">
              <BaseInput
                ref="inputIdentityPlace"
                id="txtIdentityPlace"
                type="text"
                displayName="Nơi cấp"
                value=""
                placeholder=""
                v-model="employeeDetail.IdentityPlace"
              />
            </BaseLabel>
          </div>
          <div class="form-block-3">
            <BaseLabel label="Địa chỉ">
              <BaseInput
                ref="inputAddress"
                id="txtAddress"
                displayName="Địa chỉ"
                type="text"
                value=""
                placeholder=""
                v-model="employeeDetail.Address"
              />
            </BaseLabel>

            <BaseLabel label="ĐT di động">
              <BaseInput
                ref="inputMobilePhoneNumber"
                id="txtMobilePhoneNumber"
                type="text"
                fieldType="number"
                displayName="ĐT di động"
                value=""
                placeholder=""
                v-model="employeeDetail.MobilePhoneNumber"
              />
            </BaseLabel>

            <BaseLabel label="ĐT cố định">
              <BaseInput
                ref="inputLandlineNumber"
                id="txtLandlineNumber"
                displayName="ĐT cố định"
                type="text"
                value=""
                maxlength="20"
                placeholder=""
                v-model="employeeDetail.LandlineNumber"
              />
            </BaseLabel>

            <BaseLabel label="Email">
              <BaseInput
                ref="inputEmail"
                id="txtEmail"
                type="text"
                displayName="Email"
                fieldType="email"
                value=""
                placeholder="example@gmail.com"
                v-model="employeeDetail.Email"
              />
            </BaseLabel>

            <BaseLabel label="Tài khoản ngân hàng">
              <BaseInput
                ref="inputBankAccountNumber"
                id="txtBankAccountNumber"
                type="text"
                displayName="Tài khoản ngân hàng"
                value=""
                placeholder=""
                v-model="employeeDetail.BankAccountNumber"
              />
            </BaseLabel>

            <BaseLabel label="Tên ngân hàng">
              <BaseInput
                ref="inputBankName"
                id="txtBankName"
                displayName="Tên ngân hàng"
                type="text"
                value=""
                placeholder=""
                v-model="employeeDetail.BankName"
              />
            </BaseLabel>

            <BaseLabel label="Chi nhánh">
              <BaseInput
                ref="inputBankBranchName"
                id="txtBankBranchName"
                displayName="Chi nhánh"
                type="text"
                value=""
                placeholder=""
                v-model="employeeDetail.BankBranchName"
              />
            </BaseLabel>
          </div>
        </div>
        <div class="divide"></div>
        <div class="dialog-footer">
          <div class="btn-cancel">
            <BaseButton
              type="secondary"
              id="btnDialogCancel"
              @btn-click="btnCloseDialog"
            >
              Hủy
            </BaseButton>
          </div>
          <div>
            <BaseButton
              type="secondary"
              id="btnDialogSave"
              @btn-click="btnSaveForm"
            >
              Cất
            </BaseButton>
            <BaseButton
              type="primary"
              id="btnDialogSaveAndAdd"
              @btn-click="btnSaveAndAddForm"
            >
              Cất và thêm
            </BaseButton>
          </div>
        </div>
      </div>

      <BasePopup
        v-if="saveChangesPopupShow"
        btn1="Có"
        btn2="Hủy"
        btn3="Không"
        @close="closeSaveChangesPopup"
        @confirm="confirmSaveChangesPopup"
        @cancel="cancelSaveChangesPopup"
        type="confirm-1"
        icon="icon-confirm"
      >
        {{ saveChangesPopupMessage }}
      </BasePopup>

      <BasePopup
        v-if="isNotifyInValidPopShow"
        btn1="Đóng"
        @confirm="onNotifyInValidPopShowConfirm"
        type="alert"
        icon="icon-notify"
      >
        {{ notifyInvalidMsg }}
      </BasePopup>

      <BasePopup
        v-if="isWarningServerPopShow"
        btn1="Đồng ý"
        @confirm="isWarningServerPopShow = false"
        type="warning"
        icon="icon-warning"
      >
        {{ warningServerMsg }}
      </BasePopup>
    </div>
  </div>
</template>
<script>
import BaseLabel from "../../components/base/BaseLabel.vue";
import BaseInput from "../../components/base/BaseInput.vue";
import BaseButton from "../../components/base/BaseButton.vue";
import BasePopup from "../../components/base/BasePopup.vue";
import BaseDropdownDepartment from "../../components/base/BaseDropdownDepartment.vue";
import { CommonFn } from "../../js/common/common";
import axios from "axios";

export default {
  name: "EmployeeDetail",
  components: {
    BaseLabel,
    BaseInput,
    BaseButton,
    BasePopup,
    BaseDropdownDepartment,
  },
  props: {
    status: {
      isHide: Boolean,
      formMode: String,
      data: [],
    },
  },
  data() {
    return {
      //hiển popup xác nhận
      saveChangesPopupShow: false,

      //thông báo có lỗi
      saveChangesPopupMessage: "Dữ liệu đã bị thay đổi. Bạn có muốn cất không",

      //hiện cảnh báo lỗi trường thông tin
      isNotifyInValidPopShow: false,

      //nội dung cảnh báo lỗi trường thông tin
      notifyInvalidMsg: "",

      //hiện thị thông báo lỗi từ server
      isWarningServerPopShow: false,

      //Nội dung thông báo lõi
      warningServerMsg: "",

      //Lưu dữ liệu
      employeeDetail: {
        EmployeeCode: "",
        EmployeeName: "",
        DepartmentId: "",
        EmployeePosition: "",
        DateOfBirth: null,
        Gender: null,
        IdentityNumber: "",
        IdentityDate: null,
        IdentityPlace: "",
        Address: "",
        MobilePhoneNumber: "",
        LandlineNumber: "",
        Email: "",
        BankAccountNumber: "",
        BankName: "",
        BankBranchName: "",
      },

      //url của API
      myUrl: "https://localhost:44331/api/v1/",

      //Các input không hợp lệ
      invalidRef: [],
    };
  },
  watch: {
    async status(value) {
      if (!value.isHide) {
        console.log("show");
        if (value.data.DateOfBirth != null && value.data.IdentityDate != null) {
          value.data.DateOfBirth = CommonFn.formatDateYMD(
            value.data.DateOfBirth
          );
          value.data.IdentityDate = CommonFn.formatDateYMD(
            value.data.IdentityDate
          );
        }
       this.resetInput();
        switch (value.formMode) {
          case "add":
            await this.addForm();
            break;
          case "edit":
            await this.editForm();
            break;
          case "clone":
            await this.cloneForm();
            break;
          default:
            break;
        }
      }
    },
  },
  methods: {
    btnSaveAndAddForm() {
      alert(1);
    },
    /**
     * Hiển thị form thêm
     */
    async addForm() {
      let me = this;
      // let newEmployee = [];
      try {
        let res = await me.getNewCode();
        me.employeeDetail.EmployeeCode = res.data;
        console.log(me.employeeDetail);
        if (
          me.employeeDetail.DateOfBirth == "" ||
          me.employeeDetail.IdentityDate == "" ||
          me.employeeDetail.Gender == ""
        ) {
          me.employeeDetail.DateOfBirth = null;
          me.employeeDetail.IdentityDate = null;
          me.employeeDetail.Gender = null;
        }
        console.log("add");
        console.log(me.employeeDetail);
        me.$refs.inputEmployeeCode.$refs.input.focus();
      } catch (error) {
        console.log(error);
      }
    },

    /**
     * Lấy mã mới từ API
     */
    async getNewCode() {
      let me = this;
      try {
        let res = await axios.get(me.myUrl + "Employees/NewEmployeeCode");
        return res;
      } catch (e) {
        console.log("liên hệ misa");
      }
    },
    /**
     * Hiển thị form sửa
     */
    async editForm() {
      let me = this;
      try {
        if (me.status.data) {
          me.employeeDetail = me.status.data;
          // console.log(me.employeeDetail);
        }
        me.$refs.inputEmployeeCode.$refs.input.focus();
      } catch (e) {
        console.log(e);
      }
    },

    /**
     * Hiển thị form nhân bản
     */
    async cloneForm() {
      let me = this;
      let res = await me.getNewCode();
      try {
        let newCode = res.data;
        me.employeeDetail = me.status.data;
        me.employeeDetail.EmployeeCode = newCode;
        // console.log(me.employeeDetail);
        me.$refs.inputEmployeeCode.$refs.input.focus();
      } catch (e) {
        console.log(e);
      }
    },

    async btnSaveForm() {
      this.invalidRef = [];

      //Loop qua thông tin nhân viên
      //Kiểm tra valid của từng input
      Object.entries(this.$refs).forEach(([key, el]) => {
        if (key.startsWith("input")) {
          //blur để input tự validate
          el.$el.querySelector("input").focus();
          el.$el.querySelector("input").blur();

          //Nếu input ko hợp lệ
          if (!(el.$data.isValid && el.$data.isRequiredValid)) {
            this.invalidRef = [...this.invalidRef, el];
            console.log(this.invalidRef);
          }
        }
      });

      //Kiểm tra những input không hợp lệ
      if (this.invalidRef.length > 0) {
        let msg =
          this.invalidRef[0].tooltip ?? this.invalidRef[0].$refs.input.tooltip;

        this.showPopupInvalidFields(msg);
        return false;
      } else {
        return this.sendDetails();
      }
    },

    async sendDetails() {
      let employee = this.employeeDetail;
      console.log(this.employeeDetail);
      try {
        switch (this.status.formMode) {
          case "add":
            await axios
              .post(this.myUrl + "Employees", employee)
              .then((res) => {
                alert("addOk");
                console.log(res.data);
                if (res.status != 204) {
                  alert("Thành công");
                } else {
                  alert("Không thành công");
                  this.showPopupWarningServer(res.data.Data.userMsg);
                }
              })
              .catch((res) => {
                console.log(res);
              });
            break;
          case "clone":
            await axios
              .post(this.myUrl + "Employees", employee)
              .then((res) => {
                alert("addOk");
                console.log(res.data);
                if (res.status != 204) {
                  alert("Thành công");
                } else {
                  this.showPopupWarningServer(res.data.Data.userMsg);
                }
              })
              .catch((res) => {
                console.log(res);
              });
            break;
          case "edit":
            await axios
              .put(
                this.myUrl + "Employees/" + this.employeeDetail.EmployeeId,
                this.employeeDetail
              )
              .then((res) => {
                console.log(res.data);
                alert("editok");
                if (res.status == 200) {
                  alert("Thành công");
                } else {
                  this.showPopupWarningServer(res.data.Data.userMsg);
                }
              })
              .catch((res) => {
                console.log(res);
              });
            break;

          default:
            break;
        }
      } catch (err) {
        console.log(err);
      }
      this.$emit("reloadData");
    },

    showPopupWarningServer(message) {
      this.warningServerMsg = message;
      this.isWarningServerPopShow = true;
    },

    /**
     * Thông báo trường không hợp lệ
     * @param {String} message
     */
    showPopupInvalidFields(message) {
      this.notifyInvalidMsg = message;
      this.isNotifyInValidPopShow = true;
    },

    /**
     * Đóng save popup
     */
    closeSaveChangesPopup() {
      this.saveChangesPopupShow = false;
    },
    /**
     * Hủy save
     */
    cancelSaveChangesPopup() {
      this.saveChangesPopupShow = false;
    },

    /**
     * Xác nhận
     */
    confirmSaveChangesPopup() {
      this.saveChangesPopupShow = false;
    },

    onNotifyInValidPopShowConfirm() {
      this.isNotifyInValidPopShow = false;
      this.invalidRef[0].$el.querySelector("input").focus();
    },
    /**
     * Đóng form
     */
    btnCloseDialog() {
      // if(this.status.formMode == "edit"){
      //   this.$emit("clear-data");
      // }
      this.$emit("btnCloseDialog");
    },

    async resetInput() {
      await Object.entries(this.employeeDetail).forEach(([key]) => {
        // if (key != "EmployeeCode") {
          // console.log(key);
          this.employeeDetail[key] = "";
        // }
      });
    },
  },
};
</script>
<style scoped>
@import "../../css/layout/employee-form.css";
</style>