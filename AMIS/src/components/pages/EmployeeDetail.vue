<template>
  <div
    class="ms__popup"
    id="daldetail__emp"
    v-bind:class="{ isShowDialog: isShow }"
  >
    <div class="amispopup__backgroud"></div>

    <div class="dialog__employee dialog__employee--add">
      <div id="dlgdialogemployee" class="dialog__info">
        <div class="employee__header">
          <Popper hover content="Trợ giúp">
            <div class="icon employee__cicle--question"></div>
          </Popper>
          <Popper hover content="Đóng">
            <div class="icon employee__x" @click="btnCloseOnClick"></div>
          </Popper>
        </div>

        <div class="header__popup">
          <div class="employee__nav">
            <span class="span__nav">Thông tin nhân viên</span>
          </div>
          <div class="employee__nav--select">
            <div class="employee__nav--item checkbox__customer">
              <input type="checkbox" />
              <span>Là khách hàng</span>
            </div>
            <div class="employee__nav--item checkbox__provid">
              <input type="checkbox" />
              <span>Là nhà cung cấp</span>
            </div>
          </div>
        </div>

        <div class="ms__popup--content employee__scroll">
          <div class="employee__content">
            <div class="employee__content--top">
              <div class="content__top--l">
                <div class="manv__tennv">
                  <div class="manv">
                    <div class="ms-input ms-editor">
                      <p class="ms__input--title">
                        Mã <span style="color: #f20">*</span>
                      </p>

                      <input
                        title="Mã nhân viên không được bỏ trống"
                        class="
                          input__manv
                          border__input
                          input__height
                          fieldinput
                          input__fontFamily
                        "
                        id="txtEmployeeCode"
                        v-model="employee.employeeCode"
                        ref="inputEmployeeCode"
                        @blur="validateOnBlur($event)"
                        name="emp-id"
                        required
                        maxlength="20"
                      />
                    </div>
                  </div>

                  <div class="tennv">
                    <div class="ms-input ms-editor">
                      <p class="ms__input--title">
                        Tên <span style="color: #f20">*</span>
                      </p>

                      <input
                        type="text"
                        class="
                          input__fontFamily input__tennv
                          border__input
                          input__height
                        "
                        title="Tên nhân viên không được bỏ trống"
                        id="txtEmployeeName"
                        maxlength="100"
                        v-model="employee.employeeName"
                        required
                        name="emp-name"
                        ref="inputFullName"
                        @blur="validateOnBlur($event)"
                      />
                    </div>
                  </div>
                </div>

                <div class="donvi">
                  <p class="ms__input--title">Đơn vị</p>

                  <el-tooltip
                    content="Đơn vị không được để trống!"
                    placement="bottom-start"
                  >
                    <el-select
                      filterable
                      name="emp-organization"
                      class="sel-footer-right"
                      ref="inputDepartmentId"
                      @blur="validateOnBlur($event)"
                      v-model="employee.departmentId"
                      placeholder="Chọn đơn vị"
                      size="large"
                      :autocomplete="on"
                    >
                      <el-option
                        class="el__option--department"
                        v-for="item in departments"
                        :key="item.departmentId"
                        :label="item.departmentName"
                        :value="item.departmentId"
                      />
                    </el-select>
                  </el-tooltip>
                </div>

                <div class="chucdanh">
                  <div class="ms-input ms-editor">
                    <p class="ms__input--title">Chức danh</p>
                    <input
                      class="
                        input__fontFamily input__chucdanh
                        border__input
                        input__height
                        fieldinput
                      "
                      v-model="employee.positionName"
                    />
                  </div>
                </div>
              </div>

              <div class="content__top--r">
                <div class="manv__tennv">
                  <div class="manv">
                    <div class="ngaysinh">
                      <p class="ms__input--title">Ngày sinh</p>

                      <Datepicker
                        v-model="employee.dateOfBirth"
                        placeholder="DD/MM/YYYY"
                        format="dd/MM/yyyy"
                        lang="vi"
                        :dayNames="['T2', 'T3', 'T4', 'T5', 'T6', 'T7', 'CN']"
                        :monthNames="[Thg1]"
                        textInput
                        inlineWithInput
                        autoApply
                        ref="refDateOfBirth"
                      >
                        <template #month="{ value }">
                          Tháng {{ value + 1 }}
                        </template>

                        <template #month-overlay="{ value }">
                          Tháng {{ value + 1 }}
                        </template>

                        <template #year="{ year }"> Năm {{ year }} </template>
                      </Datepicker>
                    </div>
                  </div>
                  <div class="gioitinh">
                    <div class="gender items-center">
                      <p class="ms__input--title">Giới tính</p>
                      <div id="group1" class="radio__gioitinh">
                        <div class="flex-align-center">
                          <div class="group__radio">
                            <amisbaseradio
                              isChecked="true"
                              :radioName="'rdoGender'"
                              :radioText="'Nam'"
                              :value="1"
                              :modelValue="employee.gender"
                              @changeGender="changeGender"
                            >
                            </amisbaseradio>
                          </div>
                          <div class="flex margin-20">
                            <amisbaseradio
                              :radioName="'rdoGender'"
                              :radioText="'Nữ'"
                              :value="2"
                              :modelValue="employee.gender"
                              @changeGender="changeGender"
                            >
                            </amisbaseradio>
                          </div>
                          <div class="flex margin-20">
                            <amisbaseradio
                              :radioName="'rdoGender'"
                              :radioText="'Khác'"
                              :value="0"
                              :modelValue="employee.gender"
                              @changeGender="changeGender"
                            >
                            </amisbaseradio>
                          </div>
                        </div>
                      </div>
                    </div>
                  </div>
                </div>

                <div class="cmnd__ngaycap">
                  <div class="donvi">
                    <div class="ms__input--ngaycap ms__editor">
                      <Popper hover content="Số chứng minh nhân dân">
                        <p class="ms__input--title">Số CMND</p>
                      </Popper>

                      <input
                        class="
                          input__fontFamily input__cmnd
                          border__input
                          input__height
                          fieldinput
                        "
                        ref="refIdentityNumber"
                        :size="'w-40 p-r-6'"
                        v-model="employee.identityNumber"
                      />
                    </div>
                  </div>

                  <div class="chucdanh date__created">
                    <p class="ms__input--title">Ngày cấp</p>

                    <Datepicker
                      v-model="employee.createdDate"
                      placeholder="DD/MM/YYYY"
                      format="dd/MM/yyyy"
                      lang="vi"
                      :dayNames="['T2', 'T3', 'T4', 'T5', 'T6', 'T7', 'CN']"
                      :monthNames="[Thg1]"
                      textInput
                      inlineWithInput
                      autoApply
                      tabindex="7"
                      ref="refIdentityDate"
                    >
                      <template #month="{ value }">
                        Tháng {{ value + 1 }}
                      </template>

                      <template #month-overlay="{ value }">
                        Tháng {{ value + 1 }}
                      </template>

                      <template #year="{ year }"> Năm {{ year }} </template>
                    </Datepicker>
                  </div>
                </div>

                <div class="noicap">
                  <div class="ms-input ms__editor">
                    <p class="ms__input--title">Nơi cấp</p>
                    <input
                      class="
                        input__fontFamily
                        noicap
                        input__noicap
                        border__input
                        input__height
                        fieldinput
                      "
                      v-model="employee.identityPlace"
                    />
                  </div>
                </div>
              </div>
            </div>

            <div class="employee__border">
              <div class="navigation__popup--tab">
                <div class="con__ms-ul--tabs tab__other">
                  <ul class="ul__tabs ms__tabs--ul ms__ul-tabs--left">
                    <li
                      class="
                        ms__tabs--li
                        flex
                        active__item active__item--tabother
                      "
                    >
                      <div type="button" tabindex="-1" class="ms__tabs--btn">
                        <div class="ms__label tab__label">
                          Thông tin liên hệ
                        </div>
                      </div>
                    </li>
                  </ul>
                </div>
              </div>
            </div>

            <div class="con__slot--tabs border">
              <div class="employee__content--center">
                <div class="diachi">
                  <p class="ms__input--title">Địa chỉ</p>
                  <input
                    class="input__diachi border__input input__height fieldinput"
                    v-model="employee.address"
                  />
                </div>
              </div>

              <div class="employee__content--bot">
                <div class="content__bot--a">
                  <div class="dt__didong">
                    <Popper hover content="Số điện thoại di động">
                      <p class="ms__input--title">ĐT di động</p>
                    </Popper>

                    <input
                      class="
                        input__fontFamily input__padding--10
                        border__input
                        input__height
                        fieldinput
                      "
                      v-model="employee.phoneNumber"
                    />
                  </div>

                  <div class="dt__codinh">
                    <Popper hover content="Số điện thoại cố định">
                      <p class="ms__input--title">ĐT cố định</p>
                    </Popper>
                    <input
                      class="
                        input__fontFamily input__padding--10
                        border__input
                        input__height
                        fieldinput
                      "
                      v-model="employee.phoneLandline"
                    />
                  </div>

                  <div class="email">
                    <p class="ms__input--title">Email</p>

                    <input
                      class="
                        input__fontFamily input__padding--10
                        border__input
                        input__height
                        fieldinput
                      "
                      ref="refEmail"
                      title="Email phải nhập đúng định dạng."
                      maxlength="100"
                      v-model="employee.email"
                    />
                  </div>
                </div>

                <div class="content__bot--a">
                  <div class="dt__didong">
                    <p class="ms__input--title">Tài khoản ngân hàng</p>

                    <input
                      v-model="employee.bankNumber"
                      class="
                        input__fontFamily input__padding--10
                        border__input
                        input__height
                        fieldinput
                      "
                      ref="refBankNumber"
                    />
                  </div>

                  <div class="dt__codinh">
                    <p class="ms__input--title">Tên ngân hàng</p>

                    <input
                      v-model="employee.bankName"
                      class="
                        input__fontFamily input__padding--10
                        border__input
                        input__height
                        fieldinput
                      "
                    />
                  </div>

                  <div class="email">
                    <p class="ms__input--title">Chi nhánh</p>

                    <input
                      v-model="employee.bankBranch"
                      class="
                        input__fontFamily input__padding--10
                        border__input
                        input__height
                        fieldinput
                      "
                    />
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>

        <div class="employee__footer">
          <div class="footer__left">
            <button class="button btn__huy" @click="btnCloseOnClick">
              Hủy
            </button>
          </div>

          <div class="footer__right">
            <div class="cut">
              <button class="button btn__cut" @click="btnSaveOnClick">
                Cắt
              </button>
            </div>
            <div class="cut__add">
              <button class="button btn__cut--add" @click="btnSaveMore">
                Cắt và thêm
              </button>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>

  <amisdialogerror
    v-if="amisDialogConfig.isShow"
    :text="amisDialogConfig.text"
    :body="errors"
    @onClose="btnOnClose"
    @onClickBtnYes="delEmployee"
    :iconmessage="iconmess"
  >
  </amisdialogerror>

  <amisdialogbase
    v-if="amisDialogBase.isShow"
    :text="amisDialogBase.text"
    @onClose="amisDialogBase.isShow = false"
    @onClickBtnYes="btnSaveOnClick"
    @onclickBtnNo="btnCloseDialog"
  >
  </amisdialogbase>
</template>

<script>
import { formMode, errorValidationMessageEmployee } from "../AmisEnum/enum.js";
import { ElSelect, ElOption, ElMessage } from "element-plus";
import Popper from "vue3-popper";
import Datepicker from "@vuepic/vue-datepicker";
import "@vuepic/vue-datepicker/dist/main.css";
import axios from "axios";
import amisdialogerror from "../bases/AmisDialogError.vue";
import amisbaseradio from "../bases/BaseRadio.vue";
import amisdialogbase from "../base/BaseDialog.vue";

export default {
  name: "EmployeeDetail",

  components: {
    Popper,
    amisdialogerror,
    amisbaseradio,
    amisdialogbase,
    Datepicker,
    ElSelect,
    ElOption,
  },

  created() {
    try {
      var me = this;
      axios
        .get("api/v2/Departments")
        .then((res) => {
          me.departments = res.data;
          console.log(me.departments);
        })
        .catch((err) => {
          console.log(err);
        });
    } catch (err) {
      console.log(err);
    }
  },

  methods: {
    /*************************SỬ LÝ SỰ KIỆN ĐÓNG FORM CHI TIẾT***
    /**
     * Sự kiện nút đóng (x) , Hiển thị form dialog bạn có muốn cất dữ liệu hay không ?
     * Author: ND_Tuan(13/07/2022)
     */
    btnCloseOnClick() {
      this.amisDialogBase = {
        isShow: true,
      };
    },

    /**
     * Sự kiện khi bấm vào nút không của file dialog
     * thì sẽ đóng form dialog(hủy, không , có) và form chi tiết nhân viên
     * Xóa border màu đỏ thông báo để trống của input.
     * Author: ND_Tuan(13/07/2022)
     */
    btnCloseDialog() {
      try {
        this.$refs["inputEmployeeCode"].classList.add("input-valid");
        this.$refs["inputFullName"].classList.remove("input-valid");
        document
          .querySelector('[name="emp-organization"]')
          .closest(".el-select")
          .classList.remove("class", "input-valid");

        this.amisDialogBase = {
          isShow: false,
        };
        this.$emit("isShowDialog", false);
      } catch (e) {
        console.log(e);
      }
    },

    /**************************ĐÓNG FORM ERROR */
    btnOnClose() {
      this.amisDialogConfig = {
        isShow: false,
      };
    },
    /*************************SỬ LÝ SỰ KIỆN NHÂN VIÊN***
    /**
     * Lấy mã nhân viên mới
     * Author: ND_Tuan (10/08/2022)
     */
    getNewEmployeeCode() {
      try {
        var me = this;
        axios
          .get("/api/v1/Employees/NewEmployeeCode")
          .then(function (res) {
            me.employee.employeeCode = res.data;
            me.$refs.inputEmployeeCode.focus();
          })
          .catch(function () {});
      } catch (err) {
        console.log(err);
      }
    },

    /**
     * Chọn giới Tính Radio
     * Author: ND_Tuan(07/08/2022)
     */
    changeGender(value) {
      this.employee.gender = value;
      console.log(this.employee.gender);
    },

    /*************************SỬ LÝ SỰ KIỆN THÊM, SỬA, XÓA***
    /**
     * Bắt sự kiện cho nút  Cất : Thực hiện lưu lại và đóng form
     * Nếu formMode là thêm thì thực hiện thao tác thêm
     * Nếu formMode là sửa thì thực hiện thao tác sửa
     * Author: ND_Tuan (18/07/2022)
     */
    btnSaveOnClick() {
      this.amisDialogBase = {
        isShow: false,
      };
      var me = this;
      try {
        //Thêm
        if (this.formMode == formMode.add) {
          axios
            .post("/api/v1/Employees", me.employee)
            .then(function () {
              me.$emit("isShowDialog", false);
              me.$emit("loadData");

              //Lấy mã nhân viên mới
              me.getNewEmployeeCode();
              this.$nextTick(() => this.$refs.inputEmployeeCode.focus());

              ElMessage({
                message: "Thêm mới thành công !",
                grouping: true,
                type: "success",
                duration: 2000,
              });
            })
            .catch(function (res) {
              console.log(res);
            });
          //Sửa
        } else if (this.formMode == formMode.update) {
          axios
            .put(`/api/v1/Employees`, me.employee)
            .then(function () {
              me.$emit("isShowDialog", false);
              // loading lạii dữ liệu
              me.$emit("loadData");
              ElMessage({
                message: "Sửa thành công !",
                grouping: true,
                type: "success",
                duration: 2000,
              });
            })
            .catch(function () {
              // nếu có lỗi nào đó thì hiển thị thông báo
            });
        } else if (this.formMode == formMode.replication) {
          axios
            .post("/api/v1/Employees", me.employee)
            .then(function () {
              me.$emit("isShowDialog", false);
              me.$emit("loadData");

              ElMessage({
                message: "Thêm mới thành công !",
                grouping: true,
                type: "success",
                duration: 2000,
              });

              //Lấy mã nhân viên mới
              me.getNewEmployeeCode();
            })
            .catch(function (res) {
              console.log(res);
            });
        }
      } catch (error) {
        console.log(error);
      }
    },

    /**
     * Hàm thực hiện thêm nhiều lần(Cất và Thêm)
     * Ấn thêm và cất thì dữ liệu vẫn sẽ được lưu nhưng form chi tiết không bị mất đi
     * Người dùng có thể thực hiện thêm nhiều lần tiếp theo
     * Author: ND_Tuan (18/07/2022)
     */
    btnSaveMore() {
      console.log("cất và thêm");
      this.amisDialogBase = {
        isShow: false,
      };

      // validate data
      // validate data
      if (!this.validateOnSubmit()) {
        // dừng hàm
        return;
      }
      var me = this;

      try {
        axios
          .post("/api/v1/Employees", me.employee)
          .then(function () {
            me.$emit("loadData");
            ElMessage({
              message: "Thêm mới thành công !",
              grouping: true,
              type: "success",
              duration: 2000,
            });

            me.employee = {};
            //thực hiện lấy mã mới

            me.getNewEmployeeCode();
          })
          .catch(function (res) {
            console.log(res);
          });
      } catch (error) {
        console.log(error);
      }
    },

    /*************************BLUR***
    /**
     * Validate không được bỏ trống tên và mã nhân viên, email chưa đúng định dạng
     * Aothur: ND_Tuan(04/08/2022)
     */
    // blurInputEmpName() {
    //   if (
    //     this.employee.employeeName === "" ||
    //     this.employee.employeeName === undefined
    //   ) {
    //     this.$refs["refEmployeeName"].classList.add("input-valid");
    //   } else {
    //     this.$refs["refEmployeeName"].classList.remove("input-valid");
    //   }
    // },

    // blurInputEmpCode() {
    //   if (
    //     this.employee.employeeCode === "" ||
    //     this.employee.employeeCode === undefined
    //   ) {
    //     this.$refs[""].classList.add("input-valid");
    //   } else {
    //     this.$refs[""].classList.remove("input-valid");
    //   }
    // },

    validateOnBlur($event) {
      try {
        const selectDepartmentEl = document.querySelector(
          '[name="emp-organization"]'
        );
        // lấy ra target của sự kiện blur
        const target = $event.currentTarget || $event.target;

        // nếu là thẻ input bên trong thẻ select department, xử lý theo cách riêng
        if (target.name == "emp-organization") {
          // lấy ra thẻ cha của input

          // cần delay 0.1 giây vì sự kiện blur xảy ra trước khi giá trị của input được set (ta sẽ blur trước khi chọn được giá trị trong ô select). Sau delay thì giá trị input mới được nhận
          setTimeout(function () {
            if (!target.value) {
              // set thuộc tính invalid cho thẻ select (cha của input)
              selectDepartmentEl
                .closest(".el-select")
                .classList.add("class", "input-valid");
            } else {
              // bỏ thuộc tính invalid ở cả cha và con (select và input)

              selectDepartmentEl
                .closest(".el-select")
                .classList.remove("class", "input-valid");
            }
          }, 100);
        } // nếu là thẻ input thông thường

        if (
          this.employee.employeeName === "" ||
          this.employee.employeeName === undefined
        ) {
          this.$refs["inputFullName"].classList.add("input-valid");
        } else {
          this.$refs["inputFullName"].classList.remove("input-valid");
        }

        if (
          this.employee.employeeCode === "" ||
          this.employee.employeeCode === undefined
        ) {
          this.$refs["inputEmployeeCode"].classList.add("input-valid");
        } else {
          this.$refs["inputEmployeeCode"].classList.remove("input-valid");
        }
      } catch (e) {
        console.log(e);
      }
    },

    /*************************VALIDATE***
    /**
     * Validate không được bỏ trống tên và mã nhân viên
     * Aothur: ND_Tuan(04/08/2022)
     */
    validateOnSubmit() {
      try {
        // biến lưu thông báo lỗi
        let errorMsg = "";
        // biến trạng thái form có valid hay không
        let isValid = true;

        // nếu trường employee code trống (check qua data employee được vì đã dùng v-model trong input control)
        if (!this.employee.employeeCode) {
          this.count++;
          // cập nhật biến valid
          isValid = false;
          // cập nhật biến error
          this.iconmess = "icon__message";
          this.amisDialogConfig = {
            isShow: true,
            text: "",
          };
          errorMsg = errorValidationMessageEmployee.employeeCode.required;
          this.$refs["inputEmployeeCode"].classList.add("input-valid");
        } else {
          this.$refs["inputEmployeeCode"].classList.remove("input-valid");
        }

        if (!this.employee.employeeName) {
          this.count++;
          // cập nhật biến valid
          isValid = false;
          // cập nhật biến error
          this.iconmess = "icon__message";
          this.amisDialogConfig = {
            isShow: true,
            text: "",
          };
          errorMsg = errorMsg
            ? errorMsg
            : errorValidationMessageEmployee.fullName.required;
          this.$refs["inputFullName"].classList.add("input-valid");
        } else {
          this.$refs["inputFullName"].classList.remove("input-valid");
        }

        // vì dùng element ui nên không thể set ref, nên element phải lấy trực tiếp từ DOM
        // lấy ra thẻ input bên trong el-select element. Lưu ý: đây là thẻ input chứ không phải thẻ select
        const selectDepartmentEl = document.querySelector(
          '[name="emp-organization"]'
        );
        console.log("khjsd", selectDepartmentEl);
        if (!this.employee.departmentId) {
          isValid = false;
          this.iconmess = "icon__message";
          this.amisDialogConfig = {
            isShow: true,
            text: "",
          };
          errorMsg = errorMsg
            ? errorMsg
            : errorValidationMessageEmployee.departmentId.required;
          // set thuộc tính invalid cho input control

          // set thuộc tính invalid cho thẻ select (cha của input)
          selectDepartmentEl
            .closest(".el-select")
            .classList.add("class", "input-valid");
        } else {
          // bỏ thuộc tính invalid ở cả cha và con (select và input)

          selectDepartmentEl
            .closest(".el-select")
            .classList.remove("class", "input-valid");
        }

        // reset data errors
        this.errors = [];
        // đẩy thông báo lỗi vào
        this.errors.push(errorMsg);
        // trả về trạng thái true/false

        console.log(this.errors);
        return isValid;
      } catch (e) {
        console.log(e);
      }
    },
  },

  watch: {
    newEmployeeCode: function (newValue) {
      this.employee.employeeCode = newValue;
      this.$refs.inputEmployeeCode.focus();
    },

    employeeSelectedId: function (value) {
      this.employee = value;
    },
  },

  props: {
    //isShow cho việc ẩn hiện form chi tiết nhân viên
    isShow: {
      type: Boolean,
      default: false,
    },

    //Id đc truyền từ bên ngoài vào cụ thể như nút xóa nhân viên
    employeeSelectedId: {
      type: String,
      default: "",
    },

    // formMode: quyết định cho sự kiện sửa hay thêm
    formMode: {
      type: String,
      default: "",
    },

    // mã nhân viên mới
    newEmployeeCode: {
      type: String,
      default: "",
    },
  },

  data() {
    return {
      //Data nhân viên
      employee: {
        employeeCode: "",
      },
      //Data đơn vị
      departments: {},
      //Data để truyền icon cho form dialog erro,(icon cảnh báo hoặc thêm thành công)
      iconmess: "",
      //Data quyết định việc ẩn hiện, truyền text cho amisdialogerror
      amisDialogConfig: {
        isShow: false,
        text: "",
      },
      //Data quyết định việc ẩn hiện cho amisDialogBasd
      amisDialogBase: {
        isShow: false,
      },

      //Màu boder input (đỏ) , dùng cho việc validate blur và bỏ trống
      borderErr: false,
      //Xóa border cho form input
      removeBorder: false,
      count: 0,
      errors: [],
    };
  },
};
</script>

<style scoped>
@import url("../../styles/pages/EmployeeDetail.css");

:deep(.popper) {
  background: #000;
  padding: 4px 10px;
  color: #fff;
  font-size: 11px;
  text-transform: uppercase;
  border-radius: 4px;
  margin: -16px 0px 0px 70px !important;
}

:deep(.popper:hover),
:deep(.popper:hover > #arrow::before) {
  background: #000;
}

:deep(.popper > #arrow) {
  top: -4px;
  position: absolute;
  left: 0px;
  transform: translate(162px, 89px);
}

:deep(.inline-block) {
  border: none !important;
  margin: 0 !important;
}

.employee__header :deep(.popper) {
  background: #000;
  padding: 4px 10px;
  color: #fff;
  font-size: 11px;
  text-transform: uppercase;
  border-radius: 4px;
  margin: -10px 0px 0px 20px !important;
}

.content__bot--a :deep(.inline-block) {
  display: block;
}

.input-valid {
  border: 1px solid red !important;
}

input[title]:hover::after {
  position: absolute;
  top: -100%;
  left: 0;
  background-color: #000;
}

.has-error {
  border-color: #f20;
}

.has-error .text-error {
  display: none;
}

.has-error:hover .text-error {
  display: inline-block;
  position: absolute;
  top: 100%;
  left: 0;
  background-color: #38393d;
  color: #fff;
  padding: 8px;
  z-index: 10;
}
</style>