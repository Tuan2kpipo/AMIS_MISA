<template>
  <div class="dialog">
    <div
      class="dialog-background"
      style="background-color: transparent"
      @click="closeDialog"
    ></div>
    <div class="dialog-content">
      <div
        class="table-option-dropdown zoomIn"
        :style="{ top: top + 'px', left: left + 'px' }"
      >
        <div class="dropdown-item" @click="onClickReplication">Nhân bản</div>
        <div class="dropdown-item" @click="onClickBtnDel">Xóa</div>
        <div class="dropdown-item">Ngừng sử dụng</div>
      </div>
    </div>
  </div>
</template>

<script>
// import axios from 'axios';
export default {
  props: {
    /**
     * Vị trí của component so với top
     * Author: ND_Tuan (27/07/2022)
     */
    top: {
      type: Number,
      default: 0,
    },

    /**
     * Vị trí của component so với left
     * Author: ND_Tuan (27/07/2022)
     */
    left: {
      type: Number,
      default: 0,
    },

    employeeId: {
      type: String,
      default: "",
    },
  },

  methods: {
    /**
     * Phương thức đóng dialog.
     * Author: ND_Tuan (27/07/2022)
     */
    closeDialog() {
      this.$emit("onClose");
    },

    onClickBtnDel() {
      this.$emit("onClickBtnDel");
    },

    onClickReplication() {
      this.$emit("onClickReplication");
    },
  },
};
</script>


<style scoped>
.dialog {
  position: fixed;
  top: 0;
  bottom: 0;
  left: 0;
  right: 0;
  display: flex;
  justify-content: center;
  align-items: center;
  z-index: 100;
}
.dialog-background {
  position: absolute;
  height: 100%;
  width: 100%;
  background-color: #2ca01c;
}

.dialog-content {
  z-index: 100;
  background-color: #fff;
  margin: 20px auto;
  width: 900px;
  position: relative;
}

.tooltip-box {
  display: inline-block;
  position: absolute;
  right: 0;
  top: 0;
  display: flex;
  flex-direction: row;
  justify-content: flex-end;
}
.btn-close-dialog {
  height: 40px;
  width: 40px;
  display: flex;
  justify-content: center;
  align-items: center;
  cursor: pointer;
}

.dialog-header {
  align-items: center;
  height: 52px;
  padding-left: 32px;
  padding-right: 32px;
}

.dialog-title {
  font-size: 24px;
  font-weight: bold;
}

.option {
  align-items: center;
  padding-left: 16px;
  padding-right: 16px;
}

.dialog-body {
  padding-left: 32px;
  padding-right: 32px;
  padding-bottom: 32px;
}

.dialog-footer {
  justify-content: space-between;
  align-items: center;
  height: 72px;
  margin-left: 32px;
  margin-right: 32px;
  border-top: 1px solid #ccc;
}

.dropdown {
  position: relative;
}

.dropdown-content {
  min-width: 100%;
  position: absolute;
  background-color: #fff;
  border: 1px solid #ccc;
  white-space: nowrap;
  z-index: 20;
  min-width: 100%;
}

.dropdown-content.reserve {
  top: auto;
  bottom: 100%;
}

.dropdown-content.hide {
  display: none;
}

.dropdown-content.right {
  right: 0;
}

.dropdown-item {
  height: 32px;
  line-height: 32px;
  padding-left: 12px;
  padding-right: 12px;
}

.dropdown-content:hover {
  background-color: #f4f5f6;
  color: #2ca01c;
  cursor: pointer;
}

.table-option-dropdown {
  position: fixed;
  background-color: #fff;
  z-index: 100;
  white-space: nowrap;
  border: 1px solid #ccc;
}

/* .dropdown-item {
    height: 32px;
    line-height: 32px;
    padding-left: 12px;
    padding-right: 12px;} */

.dropdown-item:hover {
  background-color: #f4f5f6;
  color: #2ca01c;
  cursor: pointer;
}
</style>