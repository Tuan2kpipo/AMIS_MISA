<template>
  <div class="router-view fix-view">
    <div class="router__content">
      <div class="content__area--content">
        <div>
          <div class="layout-dictionary">
            <div class="content__top">
              <div class="header-di">
                <span>Nhân viên</span>

                <div class="container__button" id="btn__addEmploy">
                  <button class="btn-add" @click="btnAddEmployyee">
                    Thêm mới nhân viên
                  </button>
                </div>
              </div>

              <div class="black-all-di">
                <div class="mi-chevron-left--primary"></div>

                <div class="danhmuc__aa">
                  <a class="danhmuc__a">Tất cả danh mục</a>
                </div>
              </div>
            </div>

            <div
              id="layout-dictionary-body"
              class="body"
              v-on:scroll="handleScroll"
            >
              <div class="content_toolbar grid-list-data sticky left-0">
                <div class="content__toolbar--left">
                  <div class="ms__con">
                    <button @click="btnExcuteAll" class="ms__con--dropdown">
                      Thực hiện hàng loạt
                    </button>

                    <div
                      icon="expand-more"
                      iconpack="material-icons"
                      class="mi__arrow--up"
                    ></div>
                  </div>

                  <div class="partner__list" v-if="isPartNerList">
                    <div class="partner-item" @click="deleteMany">
                      Xóa nhiều
                    </div>
                  </div>
                </div>

                <div class="content__toolbar--right">
                  <div class="content__input">
                    <input
                      class="input__bordernone ms-inputx input__search"
                      placeholder="Tìm kiếm theo mã, tên nhân viên"
                      v-model="search"
                      @keyup="searchData"
                    />

                    <div
                      icon="mi-search"
                      class="
                        icon-inputx
                        notranslate
                        ms-input--icon
                        icon-after icon-no-border
                        mi-search mi mi-16
                      "
                    ></div>
                  </div>
                  <Popper hover content="Tải trang">
                    <button
                      id="btnRefresh"
                      class="icon__refresh"
                      @click="loadData()"
                    ></button>
                  </Popper>
                  <Popper hover content="Xuất Excel">
                    <button
                      id="btnRefresh"
                      class="icon__excel"
                      @click="exportData()"
                    ></button>
                  </Popper>

                  <!-- <Popper hover content="Cài đặt">
                    <button
                      id="btnRefresh"
                      class="icon__dasb"
                      @click="loadData()"
                    ></button>
                  </Popper> -->
                </div>
              </div>

              <div class="content__table grid flex bg-white">
                <div class="grid-model-control">
                  <div class="ms-grid-viewer table-scroll">
                    <employeeTable
                      :employees="employees"
                      @toggleTableOption="toggleTableOption"
                      @rowDbOnClick="rowDbOnClick"
                      @btnUpdate="btnUpdate"
                      @btnDeleteMany="btnDeleteMany"
                    >
                    </employeeTable>
                  </div>
                </div>
              </div>
              <div class="ms-pagination grid-list-data sticky left-0">
                <div
                  class="
                    flex
                    items-center
                    justify-between
                    w-full
                    row-size
                    pagination-bar pagination__employeee
                  "
                >
                  <ul class="showItems">
                    <div class="pagination__left">
                      <li>Tổng số : {{ pageEmployee }} bản ghi</li>
                    </div>

                    <div class="pagination__right">
                      <div class="pagination__right--list">
                        <li>
                          <el-select
                            placeholder="10 bản ghi trên 1 trang"
                            class="sel-footer-right"
                            v-model="pageSizing.id"
                            size="large"
                            :autocomplete="on"
                            v-on:change="pageTest"
                            :filterable="true"
                          >
                            <el-option
                              class="ops-footer-right"
                              v-for="item in pageSizing"
                              :key="item.id"
                              :label="item.title"
                              :value="item.id"
                            />
                          </el-select>
                        </li>
                        <li>
                          <el-pagination
                            v-model:currentPage="page"
                            v-model:page-size="recordsPerPage"
                            @current-change="pageChangeClick"
                            @size-change="handleSizeChange"
                            :pager-count="4"
                            small
                            background
                            layout="prev, pager, next"
                            prev-text="Trước"
                            next-text="Sau"
                            :total="pageEmployee"
                            class="mt-4"
                          />
                        </li>
                      </div>

                      <!-- <div class="ms-out-right-grey"></div> -->
                    </div>
                  </ul>
                </div>
                <td class="ms-out-right-white-30" data-v-39f4ca35=""></td>
                <td class="ms-out-right-grey-30" data-v-39f4ca35=""></td>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>

  <employeeOption
    v-if="employeeTableOptionConfig.isShow"
    v-bind="{ ...employeeTableOptionConfig }"
    @onClose="closeemployeeTableOption"
    :employeeId="employeeSelectedId"
    @isShowDialog="showEmployeeDetailDialog"
    @loadData="loadData"
    @onClickBtnDel="onClickBtnDel"
    @onClickReplication="onClickReplication"
  >
  </employeeOption>

  <EmployeeDetail
    :isShow="isShowDialog"
    @isShowDialog="showEmployeeDetailDialog"
    :employeeSelectedId="employeeSelectedId"
    :formMode="formDetailMode"
    @loadData="loadData"
    :newEmployeeCode="newEmployeeCode"
  >
  </EmployeeDetail>

  <amisdialog
    v-if="amisDialogConfig.isShow"
    :text="amisDialogConfig.text"
    @onClose="amisDialogConfig.isShow = false"
    @onClickBtnYes="delEmployee"
  >
  </amisdialog>

  <amisdialog
    v-if="amisDialogManyEmployee.isShow"
    :text="amisDialogManyEmployee.text"
    @onClose="amisDialogManyEmployee.isShow = false"
    @onClickBtnYes="delManyEmployee"
  >
  </amisdialog>

  <amisLoading class="amis__loading" :isShowLoading="loading__none">
  </amisLoading>
</template>


<script>
import Popper from "vue3-popper";
import { ElPagination, ElSelect, ElOption, ElMessage } from "element-plus";

import axios from "axios";
import EmployeeDetail from "../pages/EmployeeDetail.vue";
import amisLoading from "../bases/BaseLoading.vue";
import employeeTable from "../Table/EmployeeTable.vue";
import employeeOption from "./EmployeeOption.vue";
import amisdialog from "../bases/AmisDialog.vue";
export default {
  name: "EmployeeItems",

  components: {
    ElSelect,
    ElOption,
    ElPagination,
    Popper,
    EmployeeDetail,
    amisLoading,
    employeeTable,
    employeeOption,
    amisdialog,
  },
  /************************************************
   * Thực hiện load dữ liệu từ api đổ về table
   */
  created() {
    try {
      this.loadData();
    } catch (error) {
      console.log(error);
      alert("Có lỗi xảy ra khi tải dữ liệu về.");
    }
  },

  data() {
    return {
      // data truyền vào để thực hiện công việc tìm kiếm
      search: "",
      //danh sách nhân viên
      employees: null,
      //Data ẩn hiện form chi tiết
      isShowDialog: false,
      //Data xác định id của nhân viên khi chọn
      employeeSelectedId: {},
      //Data để truyền tên
      employeeSectedName: null,
      //Data để xác định cho việc đó là form thêm hay sửa
      formDetailMode: 0,
      //Ẩn hiện loading
      loading__none: false,
      //Data đếm bản ghi
      pageEmployee: 0,
      //Xác định chiều dài của page
      tableWidth: 0,
      //Mã nhân viên mới
      newEmployeeCode: null,
      employeeModify: {},
      // data cho phân trang
      //Danh sách item 1,2,3,4... để phân trang
      listItems: [],
      //Trang hiện tại là 1
      page: 1,
      //số lượng bản ghi trên 1 trang
      recordsPerPage: 10,

      // data cho drop nhân bản , xóa ,..
      employeeTableOptionConfig: {
        isShow: false,
        top: 0,
        left: 0,
      },

      //data cho amisdialog sử dụng cho việc xóa 1 nhân viên (ẩn hiện và truyền text)
      amisDialogConfig: {
        isShow: false,
        text: "",
      },
      //data cho amisdialog sử dụng cho việc xóa nhiều nhân viên khi ấn checkboxs(ẩn hiện và truyền text)
      amisDialogManyEmployee: {
        isShow: false,
        text: "",
      },
      //xác định cho việc ẩn hiện btn xóa nhiều
      isPartNerList: false,

      // data lưu trữ danh sách nhân viên khi ấn checkbox
      employeeListId: [],

      pageSizing: [
        { id: 10, title: "10 bản ghi trên 1 trang" },
        { id: 20, title: "20 bản ghi trên 1 trang" },
        { id: 30, title: "30 bản ghi trên 1 trang" },
        { id: 50, title: "50 bản ghi trên 1 trang" },
        { id: 100, title: "100 bản ghi trên 1 trang" },
      ],
    };
  },

  watch: {
    //Lắng nghe sự kiện  tìm kiếm
    search: function () {
      clearTimeout(this.debounce);
      this.debounce = setTimeout(() => {
        //khi txtSearch rỗng
        if (this.search == "") {
          this.loadListItem();
        } else {
          this.page = 1;
          //khi filter rỗng thì lấy ra bản ghi theo số trang và số bản ghi
          this.loadListItem();
        }
      }, 750);
    },
  },
  methods: {
    pageTest() {
      this.recordsPerPage = this.pageSizing.id;
      this.handleSizeChange();
    },
    /******************************************************
     * Trang thay đổi
     */
    pageChangeClick() {
      try {
        this.loadListItem();
      } catch (error) {
        console.log(error);
        alert("Có lỗi xảy ra khi tải dữ liệu về.");
      }
    },

    handleSizeChange() {
      try {
        this.loadListItem();
      } catch (error) {
        console.log(error);
        alert("Có lỗi xảy ra khi tải dữ liệu về.");
      }
    },

    /**************************EXCEL*/
    /**
     * Xuất ra file excel
     * Author: ND_Tuan (20/08/2022)
     * **/
    exportData() {
      window.open("http://localhost:5262/api/v1/Employees/export");
    },

    /***************************THỰC HIỆN HÀNG LOẠT*/
    /**
     * click thực hiện hàng loạt
     * Author: ND_Tuan (20/08/2022)
     * **/
    btnExcuteAll() {
      //hiển thị nút xóa nhiều
      //1.Nếu mảng chứa các id cần xóa có giá trị thì kiểm tra
      //Nếu nút xóa nhiều đang bật thì tắt đi và ngược lại
      if (this.employeeListId.length > 0) {
        if (this.isPartNerList) {
          this.isPartNerList = false;
        } else {
          this.isPartNerList = true;
        }
      } else {
        this.isPartNerList = false;
      }
    },
    /***************************LOAD TOÀN BỘ BẢN GHI*/
    /**
     * Loadata , load toàn bộ data nhân viên
     * Author: ND_Tuan (07/07/2022)
     *
     */

    loadData() {
      var me = this;
      me.loading__none = false;
      axios
        .get(
          `/api/v1/Employees/filter?pageIndex=${this.page}&pageSize=${this.recordsPerPage}&filter=${this.search}`
        )

        .then((response) => {
          me.employees = response.data.data;
          this.pageEmployee = response.data.totalRecord;
          setTimeout(() => (me.loading__none = true), 1000);
        })
        .catch((error) => console.error(error));
    },

    /***************************LOAD SỐ BẢN GHI*/
    /**
     * Load data để phân trang
     * Author: ND_Tuan (25/07/2022)
     */
    loadListItem() {
      var me = this;
      me.loading__none = false;
      axios
        .get(
          `/api/v1/Employees/filter?pageIndex=${this.page}&pageSize=${this.recordsPerPage}&filter=${this.search}`
        )
        .then((response) => {
          me.employees = response.data.data;
          this.pageEmployee = response.data.totalRecord;
          me.loading__none = true;
          // me.totalPages = Math.floor(response.data.totalPage);
          // me.totalRecords = response.data.totalPage;
        })
        .catch((error) => console.error(error));
    },

    /***************************LẤY MÃ MỚI*/
    /**
     * Thực hiện gọi API lấy mã nhân viênnpm
     * Author: ND_Tuan(25/07/2022)
     */
    getNewEmployeeCode() {
      try {
        var me = this;
        axios
          .get("/api/v1/Employees/NewEmployeeCode")
          .then((res) => {
            me.newEmployeeCode = res.data;
          })
          .catch((err) => {
            console.log(err);
          });
      } catch (err) {
        console.log(err);
      }
    },

    /***************************TABLE OPTION */
    /**
     * Hàm click vào icon down.
     * Gán employee đang được chọn và hiển thị dropdown ở phần chức năng
     * @param {object} data Gồm các thông tin về left, top và thông tin nhân viên
     * Author: ND_Tuan(25/07/2022)
     */
    toggleTableOption(data) {
      let me = this;
      let newLeft = data.left - 100;
      let newTop = data.top + 16;

      let windowHeight = window.innerHeight;

      if (newTop > windowHeight / 2) {
        newTop -= 132;
      }

      me.employeeTableOptionConfig = {
        isShow: true,
        top: newTop,
        left: newLeft,
      };

      this.employeeModify = data.employee;
    },

    /**
     * Hàm đóng dropdown chức năng nhân viên
     * Author: ND_Tuan (25/07/2022)
     */
    closeemployeeTableOption() {
      this.employee = null;
      this.employeeTableOptionConfig = {
        isShow: false,
        top: 0,
        left: 0,
      };
    },

    /***************************CUỘN TRANG */
    /**
     * Hàm thực hiện chức năng scroll bảng table
     * Nếu table scroll lên top thì layout nhân viên- thêm nhân viên sẽ được đẩy lên trên
     * Author: ND_Tuan(25/07/2022)
     */
    handleScroll() {
      var scrolls = document.querySelector(".layout-dictionary");

      if (document.querySelector(".body").scrollTop > 50) {
        scrolls
          .querySelector(".content__top")
          .classList.add("scroll__content-top");
      } else {
        scrolls
          .querySelector(".content__top")
          .classList.remove("scroll__content-top");
      }
    },
    /***************************ẨN HIỆN FORM CHI TIẾT */
    /**
     * Hiển thị form "Chi tiết nhân viên"
     * Author: ND_Tuan (13/07/2022)
     */
    showEmployeeDetailDialog(isShow) {
      this.isShowDialog = isShow;
    },
    /***************************DOUBLE CLICK ROW */
    /**
     * Hàm sử lý sự kiện click vào dòng trong table thì sẽ hiển thị form nhân viên
     * Author: ND_Tuan (13/07/2022)
     */
    rowDbOnClick(employee) {
      this.formDetailMode = 0;
      this.employeeSelectedId = employee.employee;
      this.showEmployeeDetailDialog(true);
    },

    /***************************THÊM */
    /**
     * Hàm click nút "thêm mới nhân viên"
     * Author:ND_Tuan  (14/07/2022)
     */
    btnAddEmployyee() {
      this.formDetailMode = 1;
      this.employeeSelectedId = {};
      this.showEmployeeDetailDialog(true);
      this.newEmployeeCode = {};
      this.getNewEmployeeCode();
    },

    /****************************SỬA */
    /**
     * Hàm click nút "Sửa nhân viên"
     * Author:ND_Tuan (17/07/2022)
     */
    btnUpdate(employee) {
      // this.formDetailMode = 0;
      this.employeeSelectedId = employee.employee;
      console.log(this.employeeSelectedId);
      this.showEmployeeDetailDialog(true);
    },

    /*********************XÓA ÍT */
    /**
     * Chức năng xóa
     * Author:ND_Tuan (24/07/2022)
     */
    onClickBtnDel() {
      this.employeeTableOptionConfig = {
        isShow: false,
        top: 0,
        left: 0,
      };

      if (this.employeeModify) {
        this.amisDialogConfig = {
          isShow: true,
          text: `Bạn có thực sự muốn xóa Nhân viên <${this.employeeModify.employeeCode}> không?`,
        };
      }
    },

    /**
     * Khi bấm "có" thực hiện việc ẩn dialog và gọi tới hàm xóa
     * Author: ND_Tuan(01/08/2022)
     */
    delEmployee() {
      this.amisDialogConfig = {
        isShow: false,
        text: "",
      };

      if (this.employeeModify) {
        this.onClickkBtnDel(this.employeeModify.employeeID);
      }
    },

    /**Thực hiện xóa
     * Author: ND_Tuan (01/08/2022)
     */
    onClickkBtnDel(employeeId) {
      var me = this;
      axios
        .delete(`/api/v1/Employees/${employeeId}`)
        .then(function () {
          me.loading__none = true;
          me.employeeModify = {};
          me.loadData();
          ElMessage({
            message: "Xóa thành công !",
            grouping: true,
            type: "success",
            duration: 2000,
          });
        })
        .catch(function () {
          // nếu có lỗi nào đó thì hiển thị thông báo
        });
    },

    /************************NHÂN BẢN*/
    /**Nhân bản
     * Author: ND_Tuan (01/08/2022)
     */
    onClickReplication() {
      this.employeeTableOptionConfig = {
        isShow: false,
        top: 0,
        left: 0,
      };

      if (this.employeeModify) {
        this.accetReplication(this.employeeModify);
      }
    },

    /**Thực hiện nhân bản
     * Author: ND_Tuan (01/08/2022)
     */
    accetReplication(employee) {
      this.formDetailMode = 2;
      this.employeeSelectedId = employee;
      this.newEmployeeCode = {};
      this.getNewEmployeeCode();
      this.loadData();
      this.showEmployeeDetailDialog(true);
    },

    /**
     * Hàm sử dụng chức năng loading__none
     * Author: ND_Tuan 21/07/2022
     */
    showLoadingAmis(isShowLoad) {
      this.loading__none = isShowLoad;
    },

    /***************************XÓA NHIỀU */
    /**
     * Xóa nhiều
     * Author: ND_Tuan (14/08/2022)
     *
     */
    btnDeleteMany(employee) {
      this.employeeListId = employee;
      console.log(this.employeeListId);
    },

    /**
     * Hiển thị dialog xóa nhiều
     * Author: ND_Tuan (15/08/2022)
     *
     */
    deleteMany() {
      this.amisDialogManyEmployee = {
        isShow: true,
        text: `Bạn có thực sự muốn xóa những nhân viên đã chọn không?`,
      };
    },

    /**Xác nhân xóa nhiều sau khi bấm "có"
     * Author: ND_Tuan (15/08/2022)
     */
    delManyEmployee() {
      this.amisDialogManyEmployee = {
        isShow: false,
        text: "",
      };

      this.accectDeleteMany();
    },

    /**
     * Thực hiện xóa nhiều
     * Author: ND_Tuan (15/08/2022)
     */
    accectDeleteMany() {
      //Thực hiện xóa khi ấn nút xóa hàng loạt
      var me = this;
      me.employeeListId.forEach((element) => {
        axios
          .delete(`/api/v1/Employees/${element}`)
          .then(function () {
            me.loading__none = true;
            me.employeeModify = {};
            me.loadData();
            ElMessage({
              message: "Xóa thành công !",
              grouping: true,
              type: "success",
              duration: 2000,
            });
          })
          .catch(function () {
            // nếu có lỗi nào đó thì hiển thị thông báo
          });
      });
    },
  },
};
</script >

<style scoped>
@import url("../../styles/pages/Employee.css");
@import url("../../styles/icon/icon.css");
@import url("../../styles/bases/AmisTable.css");
@import url("../../styles/bases/dopdown.css");
@import url("../../styles/bases/AmisButton.css");

:deep(.popper) {
  background: #000;
  padding: 4px 10px;
  color: #fff;
  font-size: 11px;
  text-transform: uppercase;
  border-radius: 4px;
  margin: -14px 0px 0px 5px !important;
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
</style>