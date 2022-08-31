<template>
  <div ref="txtDepartmentName" class="cbbUnit">
    <input
      v-model="val"
      title="Đơn vị không được bỏ trống"
      type="text"
      @blur="checkEmpty"
      ref="elRef"
    />

    <div class="cbbUnit__btn" @click="isShowOption = !isShowOption">
      <div class="cbbUnit__icon"></div>
    </div>

    <div v-show="isShowOption" class="cbbUnit__option">
      <table cellspacing="0">
        <tr>
          <th colspan="2">Tên đơn vị</th>
        </tr>
        <tr
          v-for="dpm in departments"
          v-bind:key="dpm.departmentId"
          @click="addValue(dpm)"
          class="cbbUnit__option--item"
        >
          <td colspan="2">{{ dpm.departmentName }}</td>
        </tr>
        <tr>
          <td colspan="2" style="">
            <div class="penIcon"></div>
            <div>Cập nhật cơ cấu tổ chức</div>
          </td>
        </tr>
      </table>
    </div>
  </div>
</template>

<script>
import axios from "axios";
export default {
  data() {
    return {
      departments: {},
      isShowOption: false,
      val: "",
    };
  },
  created() {
    try {
      var me = this;
      axios
        .get("api/v2/Departments")
        .then((res) => {
          me.departments = res.data;
        })
        .catch((err) => {
          console.log(err);
        });
    } catch (err) {
      console.log(err);
    }
  },
  methods: {
    addValue(dpm) {
      this.val = dpm.departmentName;
      this.departmentId = dpm.departmentId;
      this.$emit("dpmId", dpm.departmentId);
      this.isShowOption = false;
    },

    /**
     * Kiểm tra input bắt buộc nhập có đang để trống không
     * Author: ND_Tuan
     */
    checkEmpty() {
      if (this.inputRequire == true) {
        if (this.val === "" || this.val === undefined) {
          this.$refs.txtDepartmentName.classList.add("errorBorder");
        } else {
          this.$refs.txtDepartmentName.classList.remove("errorBorder");
        }
      }
    },
  },

  props: [
    "setBorder",
    "Department",
    "removeBorder",
    "inputRequire",
    "modelValue",
  ],
  watch: {
    Department: function (value) {
      this.val = value;
    },
    val: function (newValue) {
      this.$emit("newDepartmentName", newValue);
    },
    setBorder: function () {
      this.$refs.txtDepartmentName.classList.add("errorBorder");
    },
    removeBorder: function () {
      this.$refs.txtDepartmentName.classList.remove("errorBorder");
    },
  },
};
</script>

<style scoped>
.cbbUnit {
  text-indent: 5px;
  width: 390px;
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
  width: 350px;
  border: none;
  outline: none;
  color: #000;
  text-indent: 5px;
  font-family: Misa Fonts Regular !important;
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
  width: 391px;
  top: 35px;
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
