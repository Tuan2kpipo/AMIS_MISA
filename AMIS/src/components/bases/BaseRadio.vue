<template>
  {{ radioStatus() }}
  <input
    :name="radioName"
    type="radio"
    class="radiobutton__input"
    :value="value"
    :checked="isChecked"
    @click="rdoOnClick"
    :tabindex="tabindex"
  />
  <span class="radiobutton__text">{{ radioText }}</span>
</template>

<script>
export default {
  name: "BaseRadio",
  emits: ["changeGender"],
  props: {
    radioName: {
      type: String,
      required: true,
    },
    radioText: {
      type: String,
      required: true,
    },
    modelValue: {
      type: Number,
      default: 1,
    },
    value: {
      type: Number,
      default: 1,
    },
    tabindex: {
      type: Number,
      default: 1,
    },
  },
  methods: {
    /**
     * Hàm khởi tạo trạng thái radio
     * Author:ND_TUAN(04/08/2022)
     */
    radioStatus() {
      if (this.value === this.modelValue) {
        this.isChecked = true;
      } else {
        this.isChecked = false;
      }
    },
    /**
     * Xử lý sự kiện khi click chọn giới tính
     * Author: ND_TUAN(04/08/2022)
     */
    rdoOnClick() {
      this.$emit("changeGender", this.value);
    },
  },
  data() {
    return {
      isChecked: false,
    };
  },
};
</script>

<style scoped>
.radiobutton__text {
  margin-left: 6px;
}
</style>