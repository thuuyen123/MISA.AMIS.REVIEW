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
            <div class="m-btn-close sprite icon-x" @click="btnExitForm"></div>
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
                tabindex="1"
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
                tabindex="2"
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
                tabindex="7"
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
                tabindex="10"
              />
            </BaseLabel>
          </div>
          <div class="form-block-2">
            <BaseLabel label="Ngày sinh">
              <DatePicker
                v-model="employeeDetail.DateOfBirth"
                :format="'DD/MM/YYYY'"
                :value-type="'YYYY-MM-DD'"
                placeholder="DD/MM/YYYY"
                :disabled-date="(date) => date >= new Date()"
                style="width: 100%; outline: #2ca01c 1px"
                tabindex="3"
              >
                <BaseInput
                  ref="inputDateOfBirth"
                  id="txtDateOfBirth"
                  type="date"
                  displayName="Ngày sinh"
                  value=""
                  placeholder=""
                  v-model="employeeDetail.DateOfBirth"
                />
              </DatePicker>
            </BaseLabel>

            <BaseLabel label="Giới tính">
              <div class="field-gender">
                <div tabindex="4" style="outline-color: #2ca01c">
                  <input
                    v-model="employeeDetail.Gender"
                    type="radio"
                    id="html"
                    name="Gender"
                    :value="1"
                  />
                </div>
                <label :for="1">Nam</label>
                <div tabindex="5" style="outline-color: #2ca01c">
                  <input
                    v-model="employeeDetail.Gender"
                    type="radio"
                    id="css"
                    name="Gender"
                    :value="0"
                  />
                </div>
                <label :for="0">Nữ</label>
                <div tabindex="6"  style="outline-color: #2ca01c">
                  <input
                    v-model="employeeDetail.Gender"
                    type="radio"
                    id="css"
                    name="Gender"
                    :value="2"
                  />
                </div>
                <label :for="2">Khác</label>
              </div>
            </BaseLabel>
            <BaseLabel label="Số CMND">
              <BaseInput
                ref="inputIdentityNumber"
                id="txtIdentityNumber"
                type="text"
                displayName="Số CMND"
                value=""
                placeholder=""
                v-model="employeeDetail.IdentityNumber"
                tabindex="8"
              />
            </BaseLabel>
            <BaseLabel label="Ngày cấp">
              <DatePicker
                v-model="employeeDetail.IdentityDate"
                :format="'DD/MM/YYYY'"
                :value-type="'YYYY-MM-DD'"
                placeholder="DD/MM/YYYY"
                :disabled-date="(date) => date >= new Date()"
                style="width: 100%; outline: #2ca01c 1px"
                :tabindex="9"
              >
                <BaseInput
                  ref="inputIdentityDate"
                  id="txtIdentityDate"
                  type="date"
                  displayName="Ngày cấp"
                  value=""
                  v-model="employeeDetail.IdentityDate"
                  style="width: 100%; outline: #2ca01c 1px"
                />
              </DatePicker>
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
                tabindex="11"
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
                tabindex="12"
              />
            </BaseLabel>

            <BaseLabel label="ĐT di động">
              <BaseInput
                ref="inputMobilePhoneNumber"
                id="txtMobilePhoneNumber"
                type="text"
                displayName="ĐT di động"
                value=""
                placeholder=""
                v-model="employeeDetail.MobilePhoneNumber"
                tabindex="13"
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
                tabindex="14"
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
                tabindex="15"
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
                tabindex="16"
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
                tabindex="17"
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
                tabindex="18"
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
              @btn-click="btnCancelForm"
              tabindex="19"
            >
              Hủy
            </BaseButton>
          </div>
          <div>
            <BaseButton
              type="secondary"
              id="btnDialogSave"
              @btn-click="btnSaveForm"
              tabindex="20"
            >
              Cất
            </BaseButton>
            <BaseButton
              type="primary"
              id="btnDialogSaveAndAdd"
              @btn-click="btnSaveAndAddForm"
              tabindex="21"
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
        type="confirm-add"
        icon="icon-info"
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
import { MESSAGE, CONFIG } from "../../js/common/const";
import {FORM_STATE, STATUS_CODE} from '../../js/common/enums'
import axios from "axios";
import DatePicker from "vue2-datepicker";
import "vue2-datepicker/index.css";
export default {
  name: "EmployeeDetail",
  components: {
    BaseLabel,
    BaseInput,
    BaseButton,
    BasePopup,
    BaseDropdownDepartment,
    DatePicker,
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
      saveChangesPopupMessage: "",

      //hiện cảnh báo lỗi trường thông tin
      isNotifyInValidPopShow: false,

      //nội dung cảnh báo lỗi trường thông tin
      notifyInvalidMsg: "",

      //hiện thị thông báo lỗi từ server
      isWarningServerPopShow: false,

      //Nội dung thông báo lõi
      warningServerMsg: "",

      originalEmployeeRecord: {},

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

      //Các input không hợp lệ
      invalidRef: [],
    };
  },
  watch: {
    /**
     *
     */
    async status(value) {
      if (!value.isHide) {
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
          case FORM_STATE.ADD:
            await this.addForm();
            break;
          case FORM_STATE.EDIT:
            await this.editForm();
            break;
          case FORM_STATE.CLONE:
            await this.cloneForm();
            break;
          default:
            break;
        }
      }
      this.originalEmployeeRecord = { ...this.employeeDetail };
    },
  },
  methods: {
    /**
     * Hiển thị form thêm mới
     * CreateBy: TTUyen (01/09/2021)
     */
    async addForm() {
      let me = this;
      try {
        let res = await me.getNewCode();
        me.employeeDetail.EmployeeCode = res.data;
        if (
          me.employeeDetail.DateOfBirth == "" ||
          me.employeeDetail.IdentityDate == "" ||
          me.employeeDetail.Gender == ""
        ) {
          me.employeeDetail.DateOfBirth = null;
          me.employeeDetail.IdentityDate = null;
          me.employeeDetail.Gender = 1;
        }
        me.$refs.inputEmployeeCode.$refs.input.focus();
      } catch (e) {
        this.$toast.error(MESSAGE.EXCEPTION_MSG, {
          position: "bottom-right",
          timeout: 2000,
        });
      }
    },

    /**
     * Lấy mã mới từ API
     *  CreateBy: TTUyen(01/09/2021)
     */
    async getNewCode() {
      try {
        let res = await axios.get(CONFIG.MY_URL + "Employees/NewEmployeeCode");
        return res;
      } catch (e) {
        this.$toast.error(MESSAGE.EXCEPTION_MSG, {
          position: "bottom-right",
          timeout: 2000,
        });
      }
    },
    /**
     * Hiển thị form sửa
     *  CreateBy: TTUyen(01/09/2021)
     */
    async editForm() {
      let me = this;
      if (me.status.data) {
        me.employeeDetail = me.status.data;
        me.$refs.inputEmployeeCode.$refs.input.focus();
      }
    },

    /**
     * Hiển thị form nhân bản
     *  CreateBy: TTUyen(01/09/2021)
     */
    async cloneForm() {
      let me = this;
      let res = await me.getNewCode();
      let newCode = res.data;
      me.employeeDetail = me.status.data;
      me.employeeDetail.EmployeeCode = newCode;
      me.$refs.inputEmployeeCode.$refs.input.focus();
    },

    async btnSaveForm() {
      this.invalidRef = [];

      Object.entries(this.$refs).forEach(([key, el]) => {
        if (key.startsWith("input")) {
          el.$el.querySelector("input").focus();
          el.$el.querySelector("input").blur();

          if (!(el.$data.isValid && el.$data.isRequiredValid)) {
            this.invalidRef = [...this.invalidRef, el];
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

    /**
     * Hàm thực hiện lưu dữ liệu vào database
     * CreateBy: TTUyen(01/09/2021)
     */
    async sendDetails() {
      let employee = this.employeeDetail;
      console.log(this.employeeDetail);
      try {
        switch (this.status.formMode) {
          case FORM_STATE.ADD:
            this.employeeDetail.EmployeeId = "126a9642-609b-5827-5199-04b3a3d51ef2";
            this.employeeDetail.EntityState=1;
            this.employeeDetail.CreatedDate= null;
            this.employeeDetail.ModifiedDate= null;
            await axios
              .post(CONFIG.MY_URL + "Employees", employee)
              .then((res) => {
                if (res.status != STATUS_CODE.NO_CONTENT) {
                  this.$toast.success(MESSAGE.ADD_MSG_SUCCESS, {
                    position: "bottom-right",
                    timeout: 2000,
                  });
                  this.$emit("changeState", true);
                }
              })
              .catch((error) => {
                var msgError = String(error.response.data.Data.userMsg);
                msgError = msgError.split("[").join("");
                this.showPopupWarningServer(msgError);
              });
            break;
          case FORM_STATE.CLONE:
            await axios
              .post(CONFIG.MY_URL + "Employees", employee)
              .then((res) => {
                console.log(res.data);
                if (res.status != STATUS_CODE.NO_CONTENT) {
                  this.$toast.success(MESSAGE.CLONE_MSG_SUCCESS, {
                    position: "bottom-right",
                    timeout: 2000,
                  });
                  this.$emit("changeState", true);
                }
              })
              .catch((res) => {
                this.showPopupWarningServer(res.response.data.Data.userMsg[0]);
              });
            break;
          case FORM_STATE.EDIT:
            await axios
              .put(
                CONFIG.MY_URL + "Employees/" + this.employeeDetail.EmployeeId,
                this.employeeDetail
              )
              .then((res) => {
                console.log(res.data);
                if (res.status == STATUS_CODE.SUCCESS) {
                  this.$toast.success(MESSAGE.EDIT_MSG_SUCCESS, {
                    position: "bottom-right",
                    timeout: 2000,
                  });
                  this.$emit("changeState", true);
                }
              })
              .catch((res) => {
                this.showPopupWarningServer(res.response.data.Data.userMsg);
              });
            break;
          default:
            break;
        }
         console.log(this.employeeDetail);
      } catch (err) {
        console.log(err);
        this.$toast.error(MESSAGE.EXCEPTION_MSG, {
          position: "bottom-right",
          timeout: 2000,
        });
      }
      this.$emit("reloadData");
    },

    /**
     * Hiển thị popup thông báo khi có lỗi từ server
     *  CreateBy: TTUyen(01/09/2021)
     */
    showPopupWarningServer(message) {
      this.warningServerMsg = message;
      this.isWarningServerPopShow = true;
    },

    /**
     * Hiển thị popup thông báo trường không hợp lệ
     *   CreateBy: TTUyen(01/09/2021)
     */
    showPopupInvalidFields(message) {
      this.notifyInvalidMsg = message;
      this.isNotifyInValidPopShow = true;
    },

    /**
     * Đóng save popup khi click hủy
     *  CreateBy: TTUyen(01/09/2021)
     */
    closeSaveChangesPopup() {
      this.saveChangesPopupShow = false;
    },
    /**
     * Hủy lưu không cất dữ liệu
     *  CreateBy: TTUyen(01/09/2021)
     */
    cancelSaveChangesPopup() {
      this.saveChangesPopupShow = false;
      this.$emit("changeState", true);
    },

    /**
     * Xác nhận có cất dữ liệu
     *  CreateBy: TTUyen(01/09/2021)
     */
    confirmSaveChangesPopup() {
      this.saveChangesPopupShow = false;
      this.btnSaveForm();
    },

    /**
     * Hiển thị popup thông báo xác nhận
     *  CreateBy: TTUyen(01/09/2021)
     */
    onNotifyInValidPopShowConfirm() {
      this.isNotifyInValidPopShow = false;
      this.invalidRef[0].$el.querySelector("input").focus();
    },
    /**
     * Đóng form ( nút hủy trong form)
     *  CreateBy: TTUyen(01/09/2021)
     */
    btnCancelForm() {
      this.$emit("changeState", true);
    },

    /**
     * Thoát khi click vào button X ktra xem có bản ghi đã thay đổi chưa
     *  CreateBy: TTUyen(01/09/2021)
     */
    btnExitForm() {
      let isChange = false;

      Object.entries(this.originalEmployeeRecord).forEach(([key]) => {
        if (this.originalEmployeeRecord[key] !== this.employeeDetail[key]) {
          isChange = true;
        }
      });

      if (isChange) {
        this.saveChangesPopupShow = true;
        this.saveChangesPopupMessage = MESSAGE.FORM_CHANGED;
      } else {
        this.btnCancelForm();
      }
    },
    /**
     * hàm xử lý  cất và hiện thị form thêm mới
     *  CreateBy: TTUyen(01/09/2021)
     */
    async btnSaveAndAddForm() {
      if ((await this.btnSaveForm()) == false) {
        this.btnSaveForm();
      } else {
        this.$emit("changeState", false, FORM_STATE.ADD);
      }
    },
    /**
     * Hàm reset lại form khi thoát khỏi form
     * CreateBy: TTUyen(01/09/2021)
     */
    async resetInput() {
      await Object.entries(this.employeeDetail).forEach(([key]) => {
        this.employeeDetail[key] = "";
      });
    },
  },
};
</script>
<style scoped>
@import "../../css/layout/employee-form.css";
</style>