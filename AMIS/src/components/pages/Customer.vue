<!--  <template>

    
<div id="layout-dictionary-body" class="body">

        <div class="content__table grid flex bg-white">
                <div class="grid-model-control">
                    <div class="ms-grid-viewer table-scroll">


                        <table id="tbEmployeeList" class="m-table" >
                            <thead> 
                                <th class="ms-out-left-white-16" style="top: -87px;"></th>


                                <th  style="min-width: 30px" class="th__ckeckall">
                                    <input id="checkall" type="checkbox" >
                                </th>
                                <div class="dis-contents ms-tbody-viewer">
                                    <th  style="min-width: 150px">MÃ NHÂN VIÊN</th>
                                    <th style="min-width: 131px; width: 131px;">TÊN NHÂN VIÊN</th>
                                    <th style="min-width: 131px; width: 131px;">GIỚI TÍNH</th>
                                    <th style="min-width: 167px; width: 167px" >NGÀY SINH</th>
                                    <th style="min-width: 119px; width: 119px">SỐ CMND</th>
                                    <th style="min-width: 167px; width: 167px"  >CHỨC DANH</th>
                                    <th style="min-width: 167px; width: 167px"  >TÊN ĐƠN VỊ</th>
                                    <th style="min-width: 167px; width: 167px" >SỐ TÀI KHOẢN</th>
                                    <th style="min-width: 167px; width: 167px" >NGÂN HÀNG</th>
                                    <th style="min-width: 167px; width: 167px" >CHI NHÁNH</th>
                                </div>
                                <th style="min-width: 70px; width: 70px" class="ms-th-viewer ms-th-wiget ">CHỨC NĂNG</th>
                                <th  class="ms-out-right-white-30" style="top: -87px;"></th>
                                <th  class="ms-out-right-grey-30" style="top: -87px;"></th>
                            </thead>
                            <tbody>
                                
                            </tbody>
                        </table>

    

                    

                    </div>

                    
                </div>
                    
                    
        </div>  

</div>

<ul class="flex-container">
      <li v-for="item in listItems" :key="item.id" class="flex-item">
        <h4>Passenger: {{item.EmployeeName}}</h4>
       
      </li>
      <li v-if="listItems.length === 0" class="flex-item center">No Record Found</li>
    </ul>

 <ul class="showItems">
      <li>Show Items:
        <select @change="onChangeRecordsPerPage" v-model="recordsPerPage">
          <option :value="10">10</option>
          <option :value="20">20</option>
          <option :value="30">30</option>
          <option :value="40">40</option>
          <option :value="50">50</option>
        </select>
      </li>
      <li>
        Go to Page <input type="text" v-model="enterpageno"><button type="button" @click.prevent="gotoPage">Go</button>
      </li>
    </ul>
    <Pagination v-if="listItems" :total-pages="totalPages" :per-page="recordsPerPage" :current-page="page" @pagechanged="onPageChange" />

    
     
</template>

<script>
 import axios from 'axios'
import Pagination from './paginate.vue'



export default {

name:"AmisCustomer",
   


  components: {
    Pagination,

  },
  data () {
    return {
      showLoader: false,
      listItems: [],
      page: 1,
      totalPages: 0,
      totalRecords: 0,
      recordsPerPage: 10,
      enterpageno: ''
    }
  },
  created () {
    this.loadListItem()
  },
  methods: {
    loadListItem () {
         var me = this;
      me.showLoader = true;
      axios.get(`https://amis.manhnv.net/api/v1/Employees/filter?pageNumber=${me.page}&pageSize=${me.recordsPerPage}`)
        .then(response => {
          console.log('response', response)
          me.showLoader = false

        me.listItems = response.data["Data"];
                         
        //   this.listItems = response.data
           me.totalPages = Math.floor(response.data.TotalPage ) // Calculate total records
 
           me.totalRecords = response.data.TotalPage
        })
    },
    onPageChange (page) {
      this.page = page
      this.loadListItem()
    },
    onChangeRecordsPerPage () {
      this.loadListItem()
    },
    gotoPage () {
      if (!isNaN(parseInt(this.enterpageno))) {
        this.page = parseInt(this.enterpageno)
        this.loadListItem()
      }
    }
  }
}
 


</script>

<style>


</style> -->

<!-- <template>
  <div
    class="pagination"
  >
    <div>
      Tổng số: <b>{{ totalRecord }}</b> bản ghi
    </div>
    <div class="pagination-right">
      <PageSizeAutocomplete
        :value="pageSize"
        :suggestions="[
          { value: 10, text: '10 bản ghi trên trang' },
          { value: 20, text: '20 bản ghi trên trang' },
          { value: 30, text: '30 bản ghi trên trang' },
          { value: 50, text: '50 bản ghi trên trang' },
          { value: 100, text: '100 bản ghi trên trang'},
        ]"
        @update:value="$emit('update:pageSize', $event)"
      />
      <div class="pager" v-if="totalPages > 1 && page >= 1 && page <= totalPages">
        <div
          class="page"
          :class="{ disable: page == 1 }"
          @click.prevent="$emit('onChangePage', page - 1)"
        >
          Trước
        </div>

        <div
          class="page"
          :class="{ active: page == 1 }"
          @click.prevent="$emit('onChangePage', 1)"
        >
          1
        </div>

        <div v-if="page > 3" class="page disable">...</div>

        <div
          v-for="p in pages"
          :key="p"
          class="page"
          :class="{ active: page == p }"
          @click.prevent="$emit('onChangePage', p)"
        >
          {{ p }}
        </div>

        <div v-if="page < totalPages - 3" class="page disable">...</div>

        <div
          class="page"
          :class="{ active: page == totalPages }"
          @click.prevent="$emit('onChangePage', totalPages)"
        >
          {{ totalPages }}
        </div>

        <div
          class="page"
          :class="{ disable: page == totalPages }"
          @click.prevent="$emit('onChangePage', page + 1)"
        >
          Sau
        </div>
      </div>
    </div>
  </div>
</template>

<script>
// import PageSizeAutocomplete from "./PageSizeAutocomplete.vue";

//#region export
export default {
  name: "AmisCustomer",
  //#region components
  components: {
    // PageSizeAutocomplete,
  },
  //#endregion

  //#region props
  props: {
    /**
     * Prop tổng số trang.
     * CreatedBy: NVDAT (09/05/2021)
     */
    totalPages: {
      type: Number,
      default: 0,
    },

    /**
     * Tổng số bản ghi
     * CreatedBy: NVDAT (10/05/2021)
     */
    totalRecord: {
      type: Number,
      default: 0,
    },

    /**
     * Prop trang hiện tại
     * CreatedBy: NVDAT (09/05/2021)
     */
    page: {
      type: Number,
      default: 1,
    },

    /**
     * Tổng số bản ghi trên trang.
     * CreatedBy: NVDAT (11/05/2021)
     */
    pageSize: {
      type: Number,
      default: 1,
    },
  },
  //#endregion

  //#region computed
  computed: {
    pages: function () {
      let ps = [];
      let start = this.page > 3 ? this.page - 1 : 2;
      let end =
        this.page < this.totalPages - 3 ? this.page + 1 : this.totalPages - 1;
      for (let i = start; i <= end; i++) ps.push(i);
      return ps;
    },
  },
  //#endregion
};
//#endregion
</script> -->


<template>
  <div>Hello</div>
</template>


<script>
export default {
  name: "AmisCustomer",

  components: {},
};
</script >

<style scoped>
@import url("../../styles/pages/Employee.css");
@import url("../../styles/icon/icon.css");
@import url("../../styles/bases/AmisTable.css");
@import url("../../styles/bases/dopdown.css");

.bg-white {
  background: #fff;
}

.flex {
  display: flex !important;
}

.fix-view {
  padding: 0 !important;
}
.router-view .router__content {
  padding-top: 48px;
  padding-left: 10px;
  background-color: #eceef1;
}

.layout-dictionary {
  position: relative;
  display: flex;
  flex-direction: column;
  height: calc(100vh - 48px);
}

.layout-dictionary .body {
  padding: calc(24px + 24px + 36px + 3px) 10px 0 0;
  overflow: auto;
  scroll-behavior: smooth;
  position: relative;
  flex: 1;
  min-height: 0;
  overflow-x: -moz-scrollbars-none;
  -ms-overflow-style: none;
}

.layout-dictionary .body::-webkit-scrollbar {
  width: 0 !important;
  display: none;
}
.ms-pagination {
  width: 1705px;
  position: sticky;
  bottom: 0;
  z-index: 30;
  background-color: #fff;
  display: flex;
  margin: 0 38px 0 10px;
}

.pagination__employeee {
  width: 100%;
}

.showItems {
  display: flex;
  align-items: center;
  justify-content: space-between;
  width: 100%;
}
.pagination__right {
  display: flex;
  position: sticky;
  border: none;
  z-index: 25;
  padding: 0;
  right: -10px !important;
}

.pagination__right--list {
  display: flex;
  align-items: center;
}

.pagination__left {
  position: sticky;
  left: 16px;
  border: 0;
  z-index: 25;
  padding: 0;
}

.ms-out-right-grey {
  position: sticky;
  border: none;
  width: 10px;
  z-index: 25;
  padding: 0;
  background: #eceef1;
  height: 56px;
  margin-left: 12px;
}
.pagination__right li {
  margin-right: 14px;
}
.black-all-di {
  cursor: pointer;
  width: max-content;
  display: flex;
  justify-items: center;
  align-items: center;
  color: #0075c0;
}

.mi {
  background: url("../../assets/img/Sprites.64af8f61.svg") no-repeat -227px -360px;
  width: 8px;
  height: 12px;
  cursor: pointer;
}

.mi-16 {
  display: inline-block;
  width: 16px;
  height: 16px;
  min-width: 16px;
  min-height: 16px;
}

.danhmuc__aa {
  display: flex;
  align-items: center;
  justify-content: center;
  display: inline-block;
}
.danhmuc__a {
  font-size: 12px;
  display: inline-block;
  width: 100px;
  height: 16px;
  min-width: 100px;
  min-height: 16px;
}
</style> -->
