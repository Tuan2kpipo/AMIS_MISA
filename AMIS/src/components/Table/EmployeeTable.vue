<template>
  <table id="tbEmployeeList" class="m-table">
    <thead>
      <th class="ms-out-left-white-16" style="top: -87px"></th>
      <th style="min-width: 30px" class="th__ckeckall">
        <input
          type="checkbox"
          :checked="isCheckedAll"
          @change="btnCheckBoxAll()"
        />
      </th>
      <th class="ms-tbody-viewer ms-th-employeecode" style="min-width: 150px">
        MÃ NHÂN VIÊN
      </th>
      <th class="ms-tbody-viewer" style="min-width: 256px; width: 256px">
        TÊN NHÂN VIÊN
      </th>
      <th class="ms-tbody-viewer" style="min-width: 120px; width: 120px">
        GIỚI TÍNH
      </th>
      <th class="ms-tbody-viewer" style="min-width: 250px; width: 250px">
        NGÀY SINH
      </th>
      <th class="ms-tbody-viewer" style="min-width: 120px; width: 120px">
        SỐ CMND
      </th>
      <th class="ms-tbody-viewer" style="min-width: 250px; width: 250px">
        CHỨC DANH
      </th>
      <th class="ms-tbody-viewer" style="min-width: 250px; width: 250px">
        TÊN ĐƠN VỊ
      </th>
      <th class="ms-tbody-viewer" style="min-width: 250px; width: 250px">
        EMAIL
      </th>
      <th class="ms-tbody-viewer" style="min-width: 180px; width: 180px">
        NGÂN HÀNG
      </th>
      <th class="ms-tbody-viewer" style="min-width: 180px; width: 180px">
        CHI NHÁNH
      </th>

      <th
        style="min-width: 120px; width: 120px"
        class="ms-th-viewer ms-th-wiget"
      >
        CHỨC NĂNG
      </th>
      <th class="ms-out-right-white-30" style="top: -87px"></th>
      <th class="ms-out-right-grey-30" style="top: -87px"></th>
    </thead>

    <tbody v-for="(employee, index) in employees" :key="employee.employeeID">
      <tr class="ms-tr-viewer" @dblclick="rowDbOnClick(employee)">
        <td class="ms-out-left-white-16"></td>
        <td class="ms-td-viewer ms-td-multi">
          <input
            type="checkbox"
            :checked="isChecked"
            v-model="employeeListId"
            :value="employee.employeeID"
            v-bind:[attributeName]="true"
            @change="inputCheckBoxChecked(employee, index)"
          />
        </td>
        <td class="ms-td-viewer ms-td-employeecode">
          {{ employee.employeeCode }}
        </td>
        <td class="ms-td-viewer">{{ employee.employeeName }}</td>
        <td class="ms-td-viewer">{{ formatName(employee.gender) }}</td>
        <td class="ms-td-viewer text__center">
          {{ formatDate(employee.dateOfBirth) }}
        </td>
        <td class="ms-td-viewer">{{ employee.identityNumber }}</td>
        <td class="ms-td-viewer">{{ employee.positionName }}</td>
        <td class="ms-td-viewer">{{ employee.departmentName }}</td>
        <td class="ms-td-viewer">{{ employee.email }}</td>
        <td class="ms-td-viewer">{{ employee.bankName }}</td>
        <td class="ms-td-viewer">{{ employee.bankBranch }}</td>

        <td
          class="td__dropdown drop__sticky ms-td-viewer ms-td-wiget text-right"
        >
          <div class="wrap-dropdown">
            <div class="dropdown dropdown--modal">
              <div class="dropdown-title" @click="btnUpdate(employee)">
                <p data-dropdown-item="1">Sửa</p>
              </div>
              <button
                class="dropdown-img"
                @click="toggleDropdown($event, employee)"
              ></button>
            </div>
          </div>
        </td>
        <td class="ms-out-right-white-30"></td>
        <td class="ms-out-right-grey-30"></td>
      </tr>
    </tbody>
  </table>
</template>
<script>
import { gender } from "../AmisEnum/enum.js";
export default {
  props: {
    employees: {
      type: Object,
      default: null,
    },
  },

  data() {
    return {
      isCheckedAll: false,
      isChecked: false,
      employeeListId: [],
      attributeName: "",
    };
  },

  methods: {
    /**
     * Hàm format ngày 2_tháng
     * Author: ND_Tuan (13/07/2022)
     */
    formatDate(date) {
      try {
        if (date) {
          date = new Date(date);
          let newDate = date.getDate();
          let month = date.getMonth() + 1;
          let year = date.getFullYear();
          if (newDate < 10) newDate = "0" + newDate;
          if (month < 10) month = "0" + month;

          return `${newDate}/${month}/${year}`;
        }
      } catch (error) {
        console.log(error);
      }
    },

    /**
     * Định dạng tình trạng giới tính
     * Author: ND_Tuan (7/7/2022)
     * @param {*} value
     */

    formatName(value) {
      if (value == gender.boy) {
        return "Nam";
      } else if (value == gender.girl) {
        return "Nữ";
      } else {
        return "Khác";
      }
    },

    /**
     * Hàm đóng mở dropdown
     * Author: ND_Tuan (27/08/2022)
     */
    toggleDropdown(event, employee) {
      let left = event.clientX;
      let top = event.clientY;
      this.$emit("toggleTableOption", { left, top, employee: employee });
    },

    /**
     * Hàm thực hiện chức năng sửa
     * Sử dụng lại hàm btnUpdate bên form Employee.vue dòng 490
     * Author: ND_Tuan(27/07/2022)
     */
    btnUpdate(employee) {
      this.$emit("btnUpdate", { employee: employee });
    },

    /**
     * Hàm double click vô thanh tr
     * Hiển thị dữ liệu lên trên form thông tin nhân viên
     * Sử dụng lại hàm rowDbOnClick bên form Employee.vue dòng 512
     * Author: ND_Tuan (27/08/2022)
     */
    rowDbOnClick(employee) {
      this.$emit("rowDbOnClick", { employee: employee });
    },

    /**
     *CheckAll
     * Author: ND_Tuan (27/08/2022)
     */

    btnCheckBoxAll() {
      if (this.isCheckedAll == true) {
        this.attributeName = "";
        this.isCheckedAll = false;
        for (var k = 0; k < this.employeeListId.length; k++) {
          for (var t = 0; t < this.employees.length; t++) {
            if (this.employeeListId[k] == this.employees[t].employeeID) {
              this.employeeListId.splice(k, 1);
            }
          }
        }
      } else {
        this.isCheckedAll = true;
        this.attributeName = "checked";

        //check trùng id trong employeeListId
        //Không thực hiện thêm id vào mảng
        var isDupli = false;
        for (var i = 0; i < this.employees.length; i++) {
          for (var j = 0; j < this.employeeListId.length; j++) {
            if (this.employees[i].employeeID == this.employeeListId[j]) {
              isDupli = true;
              break;
            }
          }
          if (isDupli == true) {
            isDupli = false;
          } else {
            this.employeeListId.push(this.employees[i].employeeID);
          }
        }
      }
      console.log("hello", this.employeeListId);
      this.$emit("btnDeleteMany", this.employeeListId);
    },

    inputCheckBoxChecked(employee) {
      //duyệt để xem đã tồn tại chưa thì thực hiện xóa
      for (var k = 0; k < this.employeeListId.length; k++) {
        if (employee.employeeCode == this.employeeListId[k]) {
          this.employeeListId.splice(k, 1);
        }
      }
      this.$emit("btnDeleteMany", this.employeeListId);
    },
  },
};
</script>

<style scoped>
@import url("../../styles/bases/AmisTable.css");

tr {
  cursor: pointer;
}

.dropdown-title p {
  color: #0075ff;
  font-weight: 600;
}
.text__center {
  text-align: center !important;
}
</style>