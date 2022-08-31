<template>
  <div class="dialog">
    <div class="dialog__background" @click="closeDialog"></div>
    <div class="dialog__box--content">
      <div class="ms-message-box--content">
        <div class="dialog__content zoomIn" style="width: 444px">
          <div class="icon__dialog">
            <div class="icon__message"></div>
          </div>
          <div class="dialog__message" style="margin-left: 16px">
            <span> Dữ liệu đã bị thay đổi, bạn có muốn cất không ?</span>
          </div>
        </div>

        <div class="dialog__line"></div>

        <div class="dialog__footer">
          <div class="dialog__footer--left">
            <button color="secondary" @click="closeDialog" class="btn__out">
              Hủy
            </button>
          </div>

          <div class="footer__right">
            <div class="dialog__footer--left">
              <button color="secondary" @click="onclickBtnNo" class="btn__no">
                Không
              </button>
            </div>
            <div class="dialog__footer--right">
              <button color="primary" @click="onclickBtnYes" class="btn__yes">
                Có
              </button>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  components: {},

  props: {
    /**
     * Text thông báo "ví dụ : Bạn có muốn xóa không ?"
     * Author: ND_Tuan(01/08/2022)
     */
    text: {
      type: String,
      default: "",
    },
  },

  methods: {
    /**
     * Phương thức đóng dialog.
     * Author: ND_Tuan(01/08/2022)
     */
    closeDialog() {
      this.$emit("onClose");
    },

    /**
     * Phương thức chọn nút "có".
     * Thực hiện yêu cầu và đóng dialog
     * Author: ND_Tuan(01/08/2022)
     */
    onclickBtnNo() {
      this.$emit("onclickBtnNo");
    },
    /**
     * Phương thức chọn nút "có".
     * Thực hiện yêu cầu và đóng dialog
     * Author: ND_Tuan(01/08/2022)
     */
    onclickBtnYes() {
      this.$emit("onClickBtnYes");
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
  z-index: 1000;
  background: rgba(0, 0, 0, 0.4);
}

.dialog__box--content {
  position: relative;
  transition: all 0.2s;
  z-index: 1000;
  box-shadow: 0 5px 20px 0 rgb(0 0 0 / 10%);
  background: #fff;
  border-radius: 3px;
  width: 444px;
  min-width: 444px;
}

.ms-message-box--content {
  padding: 32px;
}

.dialog__content {
  display: flex;
  align-items: flex-start;
  width: inherit !important;
  position: relative;
}

.dialog__message {
  overflow: auto;
  max-height: 400px;
  margin-bottom: 32px;
  padding-left: 16px;
  padding-top: 12px;
}

.dialog__content span {
  display: block;
}

.icon__message {
  width: 48px;
  height: 48px;
  min-width: 48px;
  min-height: 48px;
  cursor: pointer;
  background-color: aqua;
  background: url("../../assets/img/Sprites.64af8f61.svg") no-repeat -832px -462px;
}

.dialog__line {
  height: 1px;
  background: #b8bcc3;
  margin-bottom: 20px;
}

.dialog__footer {
  display: flex;
  align-items: center;
  justify-content: space-between;
  position: relative;
  height: 36px;
}

.dialog__footer--left {
  float: left;
}

.dialog__footer--right {
  float: right;
  padding-left: 8px;
}

.btn__out {
  border: 1px solid #8d9096;
  color: #111;
  background-color: transparent;
  border-radius: 3px;
  height: 34px;
  padding: 6px 16px;
  background-color: #fff;
}

.btn__out:hover {
  cursor: pointer;
  background-color: #d2d3d6;
}
.btn__no {
  border: 1px solid #8d9096;
  color: #111;
  background-color: transparent;
  border-radius: 3px;
  height: 34px;
  padding: 6px 16px;
  background-color: #fff;
}

.btn__no:hover {
  cursor: pointer;
  background-color: #d2d3d6;
}

.btn__yes {
  border: 1px solid transparent;
  color: #fff;
  background-color: #2ca01c;
  border-radius: 3px;
  height: 34px;
  padding: 6px 16px;
}

.btn__yes:hover {
  cursor: pointer;
  background-color: #35bf22;
  color: #fff;
}

.footer__right {
  display: flex;
  align-items: center;
  justify-content: space-between;
  width: 132px;
}
</style>