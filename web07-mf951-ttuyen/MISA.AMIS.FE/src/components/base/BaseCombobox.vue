<template>
  <div class="combobox combobox-filter" @click="toggleCombobox">
    <div class="combobox-text">{{ selectedText }}</div>
    <div class="box-icon">
      <div class="sprite icon-arrow-down" :class="{ rotate: isRotate }"></div>
    </div>
    <div
      class="combobox-data"
      :class="{ 'combobox-hidden': isClose }"
      @click="changePageSize"
    >
      <div
        class="combobox-item"
        v-for="(item, index) in items"
        :key="item.value"
        @click="selectItem(index)"
        :value="item.value"
        :class="{ 'combobox-selected': activeItem(index) }"
      >
        <div class="combobox-item-text">
          {{ item.text }}
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { eventBus } from "../../main.js";
export default {
  name: "BaseCombobox",
  async created() {
    this.selectItem(0);
  },
  data() {
    return {
      isClose: true,
      selectedText: "",
      selectedValue: "",
      items: [
        { text: "10 bản ghi trên 1 trang", value: 10 },
        { text: "20 bản ghi trên 1 trang", value: 20 },
        { text: "30 bản ghi trên 1 trang", value: 30 },
        { text: "50 bản ghi trên 1 trang", value: 50 },
        { text: "100 bản ghi trên 1 trang", value: 100 },
      ],
      currentIndex: 0,
      isRotate: false,
    };
  },

  methods: {
    /**
     * Hàm bắt sự kiện click gửi value sang cho bên employeeDetail
     * CreatedBy: TTUyen(03/09/2021)
     */
    changePageSize() {
      eventBus.$emit("changePageSize", this.selectedValue);
    },

    /*
     * Hàm xử lý việc toggle combobox
     * CreatedBy: TTUyen(03/09/2021)
     */
    toggleCombobox() {
      this.isClose = !this.isClose;
      this.isRotate = !this.isRotate;
    },

    /**
     * Hàm select item
     * CreatedBy: TTUyen(03/09/2021)
     */
    selectItem(index) {
      this.selectedText = this.items[index].text;
      this.selectedValue = this.items[index].value;
      this.currentIndex = index;
    },

    /**
     * Hàm check index của item
     * CreatedBy: TTUyen(03/09/2021)
     */
    activeItem(index) {
      return this.currentIndex == index ? true : false;
    },

    /**
     * Hàm trả về index của item khi so sánh value
     * CreatedBy: TTUyen(03/09/2021)
     */
    getIndexByValue() {
      return this.items.findIndex((element, index) => {
        if (element.value === this.value) {
          return index;
        }
      });
    },

    /**
     * Hàm bắt sự kiện nút reload
     * khi reload sẽ đưa text combobox về mặc định
     * CreateBy: TTUyen ( 03/09/2021)
     */
    setTextDefault() {
      this.selectedText = this.items[0].text;
      this.selectedValue = this.items[0].value;
      this.currentIndex = 0;
      this.$emit("setValueDefaultCombobox", this.selectedValue);
    },

    /**
     * Hàm check event khi click ra bên ngoài combobox
     * CreateBy: TTUyen ( 03/09/2021)
     */
    close(e) {
      if (!this.$el.contains(e.target)) {
        this.isClose = true;
        this.isRotate = false;
      }
    },
  },

  mounted() {
    document.addEventListener("click", this.close);
  },
};
</script>

<style scoped>
@import url(../../css/base/combobox.css);
</style>