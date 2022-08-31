<template>
  <div class="cbbUnit">
    <input
      class="input"
      type="text"
      readonly
      :value="suggestions[current].text"
      @focus="showSuggestion"
      @blur="onBlur"
    />
    <div class="cbbUnit__btn" @click="isShowOption = !isShowOption">
      <div class="cbbUnit__icon"></div>
    </div>

    <div class="cbbUnit__option" v-show="isShowOption">
      <div
        v-for="(suggestion, i) in suggestions"
        :key="i"
        class="cbbUnit__option--item"
        :class="{ active: current == i }"
        @click.prevent="clickSuggestion(suggestion, i)"
      >
        {{ suggestion.text }}
      </div>
    </div>
  </div>
</template>

<script>
export default {
  props: {
    suggestions: {
      type: Array,
      required: true,
    },
    value: {
      type: Number,
      default: null,
    },
  },
  data: () => ({
    isShow: false,
    current: 0,
    isShowOption: false,
  }),
  methods: {
    enter() {
      this.$emit("update:value", this.suggestions[this.current].value);
      this.isShow = false;
      document.querySelector("input").blur();
    },
    up() {
      if (this.current > 0) this.current--;
    },
    down() {
      if (this.current < this.suggestions.length - 1) this.current++;
    },
    clickSuggestion(suggestion, index) {
      this.current = index;
      this.isShow = false;
      this.$emit("update:value", suggestion.value);
      document.querySelector("input").blur();
      this.isShowOption = false;
      this.$emit("onChangeRecordsPerPage");
    },
  },

  mounted() {
    let index = this.suggestions.findIndex((s) => s.value == this.value);
    if (index >= 0) {
      this.current = index;
    } else {
      this.current = 0;
    }
    document.addEventListener("click", this.close);
  },

  beforeUnmoute() {
    document.removeEventListener("click", this.close);
  },
};
</script>


<style scoped>
.cbbUnit {
  text-indent: 5px;
  width: 200px;
  height: 32px;
  border: 1px solid #b8bcc3;
  border-radius: 2px;
  position: relative;
  line-height: 32px;
}
.errorBorder {
  border: 1px solid red;
}
.cbbUnit input {
  width: 172px;
  border: none;
  outline: none;
  color: #576574;
  text-indent: 5px;
  font-family: Misa Fonts Regular;
}

.cbbUnit__btn {
  position: absolute;
  width: 30px;
  height: 30px;
  border-radius: 0 2px 2px 0;
  right: 0;
  top: 0;
  display: flex;
  align-items: center;
  cursor: pointer;
}
.cbbUnit__btn:hover {
  background-color: #b8bcc3;
}

.cbbUnit__icon {
  background: url("../../assets/img/Sprites.64af8f61.svg") no-repeat -564px -365px;
  width: 8px;
  height: 5px;
  margin: 0 auto;
}
.cbbUnit__option {
  text-indent: 5px;
  position: absolute;
  width: 200px;
  top: -168px;
  border: 1px solid #b8bcc3;
  background-color: #fff;
  border-radius: 2px;
  z-index: 900;
  left: -1px;
}
.cbbUnit__option table {
  width: 389px;
}
.cbbUnit__option--item:hover {
  color: #35bf22;
  background-color: #f4f5f8;
  cursor: pointer;
}
.cbbUnit__option table tr td:first-child {
  width: 130px;
}
.cbbUnit__option table tr td:last-child {
  width: 260px;
}
.cbbUnit__option table tr td,
th {
  height: 30px;
  line-height: 30px;
  text-indent: 5px;
}
.cbbUnit__option table tr:last-child {
  color: #35bf22;
  background-color: #f4f5f8;
}
.cbbUnit__option table tr:first-child {
  background-color: #f4f5f8;
}
.cbbUnit__option table tr th {
  text-align: left;
}
.penIcon {
  background: url("../../assets/img/Sprites.64af8f61.svg") no-repeat -652px -405px;
  width: 24px;
  height: 21px;
  float: left;
  margin-left: 4px;
  margin-top: 4px;
}
</style>