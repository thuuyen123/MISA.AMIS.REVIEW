<template>
  <div class="dialog-detail"  v-if="!status.isHide">

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
            <div class="m-btn-close sprite icon-x" @click="btnCloseDialog"></div>
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
              />
            </BaseLabel>
            <BaseLabel :required="true" label="Tên">
              <BaseInput
                ref="inputEmployeeName"
                id="txtEmployeeName"
                type="text"
                fieldType="employeeName"
                displayName="Tên"
                value=""
                placeholder=""
                :required="true"
              />
            </BaseLabel>
            <BaseLabel :required="true" label="Đơn vị">
              <BaseInput
                ref="inputEmployeeName"
                id="txtEmployeeName"
                type="text"
                fieldType="employeeName"
                displayName="Đơn vị"
                value=""
                placeholder=""
                :required="true"
              />
            </BaseLabel>
            <BaseLabel label="Chức danh">
              <BaseInput
                ref="inputPosition"
                id="txtPosition"
                type="text"
                displayName="Chức danh"
                value=""
                placeholder=""
              />
            </BaseLabel>
          </div>
          <div class="form-block-2">
            <BaseLabel label="Ngày sinh">
              <BaseInput
                ref="inputDateOfBirth"
                id="txtPosition"
                type="date"
                displayName="Ngày sinh"
                value=""
                placeholder=""
              />
            </BaseLabel>

            <BaseLabel label="Giới tính">
              <div class="field-gender">
                <input type="radio" id="html" name="Gender" :value="1" />
                <label :for="1">Nam</label>
                <input type="radio" id="css" name="Gender" :value="0" />
                <label :for="0">Nữ</label>
                <input type="radio" id="css" name="Gender" :value="2" />
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
              />
            </BaseLabel>

            <BaseLabel label="ĐT di động">
              <BaseInput
                ref="inputPhoneNumber"
                id="txtPhoneNumber"
                type="text"
                displayName="ĐT di động"
                value=""
                placeholder=""
              />
            </BaseLabel>

            <BaseLabel label="ĐT cố định">
              <BaseInput
                ref="inputTelephoneNumber"
                id="txtTelephoneNumber"
                displayName="ĐT cố định"
                type="text"
                value=""
                maxlength="20"
                placeholder=""
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
                placeholder=""
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
              />
            </BaseLabel>
          </div>
        </div>
        <div class="divide"></div>
        <div class="dialog-footer">
          <div class="btn-cancel">
            <BaseButton subClass="m-btn-secondary" id="btnDialogCancel" @btn-click="btnCloseDialog">
              Hủy
            </BaseButton>
          </div>
          <div>
            <BaseButton subClass="m-btn-secondary" id="btnDialogSave">
              Cất
            </BaseButton>
            <BaseButton subClass="m-btn-primary" id="btnDialogSaveAndAdd">
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
        v-if="isNotifyPopShow"
        btn1="Đóng"
        @confirm="isNotifyPopShowConfirm"
        type="alert"
        icon="icon-notify"
      >
        {{ notifyMessage }}
      </BasePopup>

      <BasePopup
        v-if="isWarningPopShow"
        btn1="Đồng ý"
        @confirm="isWarningPopShow = false"
        type="warning"
        icon="icon-warning"
      >
        {{ warningMessage }}
      </BasePopup>
    </div>
  </div>
</template>
<script>
import BaseLabel from "../../components/base/BaseLabel.vue";
import BaseInput from "../../components/base/BaseInput.vue";
import BaseButton from "../../components/base/BaseButton.vue";
import BasePopup from "../../components/base/BasePopup.vue";
export default {
  name: "EmployeeDetail",
  components: {
    BaseLabel,
    BaseInput,
    BaseButton,
    BasePopup,
  },
  props: {
    status: {
      isHide: Boolean,
      formMode: String,
      data: [],
    },
  },
  data(){
    return{
      saveChangesPopupShow: false,
      saveChangesPopupMessage: "Dữ liệu đã bị thay đổi. Bạn có muốn cất không",
      isNotifyPopShow: false,
      notifyMessage: "",
      isWarningPopShow: false,
      warningMessage: ""
    }
  },
  methods: {
    closeSaveChangesPopup(){
       this.saveChangesPopupShow = false;
    },
    cancelSaveChangesPopup(){
      this.saveChangesPopupShow = false;
    },
    confirmSaveChangesPopup(){
       this.saveChangesPopupShow = false;
    },
    btnCloseDialog(){
      //  this.saveChangesPopupShow = false;
      this.$emit("btnCloseDialog");
    }
  },
};
</script>
<style scoped>
@import "../../css/layout/employee-form.css";
</style>