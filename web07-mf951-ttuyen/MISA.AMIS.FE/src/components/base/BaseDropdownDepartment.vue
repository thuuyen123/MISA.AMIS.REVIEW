<template>
  <div
    v-on-clickaway="away"
    :id="id"
    :class="['dropdown']"
    :itemid="itemId"
    :itemname="itemName"
    :itemCode="itemCode"
  >
    <div
      class="dropdown-header-wrapper"
      :class="{
        'input-border-red': !(isValid && isRequiredValid) && !focusing,
      }"
      :id="id"
      :title="tooltip"
      @click="toggleItems"
      :value="currentId"
      :tabindex="tabindex"
      @input="onInput($event.target.value)"
      @blur="onBlur($event.target.value)"
      v-bind="$attrs"
    >
      <input
        type="text"
        class="dropdown-value"
        @input="onInput($event.target.value)"
        @blur="onBlur($event.target.value)"
        v-bind="$attrs"
        :value="currentName"
      />
      <div class="dropdown-open">
        <div class="sprite icon-arrow-down"></div>
      </div>
    </div>

    <ul :class="['dropdown-list', opened ? 'isshow' : 'isnone']">
      <li class="dropdown-item dropdown-item-header">
        <div class="dropdown-item-text dropdown-col-1">Mã đơn vị</div>
        <div class="dropdown-item-text dropdown-col-2">Tên đơn vị</div>
      </li>
      <li
        :class="['dropdown-item', item[itemId] == currentId ? 'active' : '']"
        v-for="item in itemlist"
        :key="item[itemId]"
        @click="clickItem(item[itemId], item[itemName], item[itemCode])"
      >
        <div class="dropdown-item-text dropdown-col-1">
          {{ item[itemCode] }}
        </div>
        <div class="dropdown-item-text dropdown-col-2">
          {{ item[itemName] }}
        </div>
      </li>
    </ul>
  </div>
</template>

<script>
import axios from "axios";
import { MESSAGE, CONFIG } from "../../js/common/const";
import { directive as onClickaway } from "vue-clickaway";
export default {
  directives: {
    onClickaway: onClickaway,
  },
  name: "BaseDropdownDepartment",
  data() {
    return {
      itemlist: [],

      currentId: "-1",

      currentName: "",

      currentCode: "",

      opened: false,

      defaultId: "-1",

      //Nội dung title khi validate dữ liệu
      tooltip: "",

      //input được focus
      focusing: false,

      // Kiểm tra đã hợp lệ chưa
      isValid: true,

      // Kiểm tra required không rỗng
      isRequiredValid: true,
    };
  },
  props: {
    id: String,
    itemId: String,
    itemName: String,
    itemCode: String,
    selectedId: String,
    tabindex: String,
    value: String,
    required: {
      type: Boolean,
      default: false,
    },
    displayName: {
      type: String,
      default: "",
    },
  },
  created() {
    this.loadDropdownData();
    this.initChoice();
  },
  watch: {
    /**
     * Xử lý khi thay đổi lựa chọn
     *  CreateBy: TTUyen (30/8/2021)
     */
    selectedId: function () {
      this.initChoice();
    },
  },
  methods: {
    /**
     * Đóng dropdown khi click ra ngoài
     * CreateBy: TTUyen (30/8/2021)
     */
    away: function () {
      this.opened = false;
    },

    /**
     * Lấy dữ liệu department từ database
     * CreateBy: TTUyen (30/8/2021)
     */
    async loadDropdownData() {
      await axios
        .get(`${CONFIG.MY_URL}Departments`)
        .then((res) => {
          this.itemlist = res.data.Data;
        })
        .catch((error) => {
          console.log(error);
        });
    },

    /**
     *  Lấy dữ liệu theo để hiện thị
     * CreateBy: TTUyen (30/8/2021)
     */
    async initChoice() {
      let me = this;
      await me.loadDropdownData();
      if ((me.selectedId + "").length > 0) {
        me.itemlist.forEach((item) =>{
          if (me.selectedId == item[me.itemId]) {
            me.currentName = item[me.itemName];
            me.currentId = item[me.itemId];
            me.currentCode = item[me.itemCode];
          }
        });
        this.isValid = true;
        this.isRequiredValid = true;
      } else {
        me.currentId = "-1";
        me.currentName = "";
        me.currentCode = "";
      }
    },

    /**
     * Xử lý khi lick và vào các item
     * CreateBy: TTUyen (30/8/2021)
     */
    clickItem(itemValue, itemName, itemCode) {
      this.currentId = itemValue;
      this.currentName = itemName;
      this.currentCode = itemCode;
      this.opened = false;
      this.$emit("input", itemValue);
      this.$emit("dropdownOnSelect");
      this.isValid = true;
      this.isRequiredValid = true;
    },

    /**
     * Hàm đóng list dropdown
     * CreateBy: TTUyen (30/8/2021)
     */
    toggleItems() {
      this.opened = !this.opened;
    },
    
    /**
     * Hàm xử lý khi nhập input
     * CreateBy: TTUyen (30/8/2021)
     */
    onInput(value) {
      let me = this;
      me.focusing = true;
      me.$emit("input", value);
      me.validateInput(value);
    },

    /**
     * Hàm xử lý khi blur input
     * CreateBy: TTUyen (30/8/2021)
     */
    onBlur(value) {
      let me = this;
      me.focusing = false;
      me.validateInput(value);
    },

  /**
   * Hàm định dạng giá trị trong input
   * CreateBy: TTUyen (30/8/2021)
   */
    validateInput(value) {
      let me = this;
      //Kiểm tra nhập các trường bắt buộc
      if (!me.required && value == "") {
        me.isValid = true;
        me.isRequiredValid = true;
        return;
      }

      //Rỗng và bắt buộc
      if (value == "" && me.required) {
        me.isRequiredValid = false;
        me.tooltip = MESSAGE.CANT_BE_NULL.format(me.displayName);
        return;
      } else {
        me.isRequiredValid = true;
      }
      if (me.isRequiredValid && me.isValid) {
        me.tooltip = "";
      }
    },

    /**
     * Hàm reset lại các thuộc tính khi thoát khỏi form
     * CreateBy: TTUyen (30/8/2021)
     */
    reset() {
      this.isValid = true;
      this.isRequiredValid = true;
    },
  },
};
</script>
<style scoped>
@import "../../css/base/dropdown.css";
@import "../../css/base/icon.css";

.dropdown-list.isshow {
  display: block;
}

.dropdown-list.isnone {
  display: none;
}
#store .dropdown-header-wrapper {
  width: 200px;
  font-size: 15px;
  border: none;
}
</style>

