<template>
  <ul class="pagination">
      <li class="pagination-item">
        <a href="#" @click.prevent="onClickFirstPage" :class="isInFirstPage? 'disabled':''" :disabled="isInFirstPage">Trước</a>
      </li>
      <li class="pagination-item">
        <a href="#" @click.prevent="onClickPreviousPage" :class="isInFirstPage? 'disabled':''" :disabled="isInFirstPage">«</a>
      </li>
      <li :key="page.id" v-for="page in pages" class="pagination-item">
        <a href="#" @click.prevent="onClickPage(page.name)" 
        :disabled="page.isDisabled"
        :class="{ active: isPageActive(page.name) }"> {{ page.name }} </a>
      </li>
      <li class="pagination-item">
        <a href="#" @click.prevent="onClickNextPage" :class="isInLastPage? 'disabled':''" :disabled="isInLastPage">»</a>
      </li>
      <li class="pagination-item">
        <a href="#" @click.prevent="onClickLastPage" :class="isInLastPage? 'disabled':''" :disabled="isInLastPage">Sau</a>
      </li>
  </ul>
</template>

<script>
export default {
  name: 'AmisPagination',
  props: {
/**
 * Số btn hiển thị , tối đa 3
 * Author: ND_Tuan (26/07/2022)
 */
    maxVisibleButtons: {
      type: Number,
      required: false,
      default: 3
    },
/**
 * Tổng số trang
 * Author: ND_Tuan (26/07/2022)
 */
    totalPages: {
      type: Number,
      required: true
    },

    perPage: {
      type: Number,
      required: true
    },
/**
 * Trang hiện tại
 * Author: ND_Tuan (26/07/2022)
 */
    currentPage: {
      type: Number,
      required: true
    }
  },
  computed: {
/**
 * Kiểm tra trang Trước
 * Author: ND_Tuan (26/07/2022)
 */
    isInFirstPage () {
      return this.currentPage === 1
    },
/**Kiển tra trang sau
 * Author: ND_Tuan (26/07/2022)
 */
    isInLastPage () {
      if (this.totalPages === 0) {
        return true
      }
      return this.currentPage === this.totalPages
    },
/**
 * Trang đầu tiên , trang cuối
 */
    startPage () {
      // trang đầu tiên
      if (this.currentPage === 1) {
        return 1
      }
      // trang cuối cùng
      if (this.totalPages < this.maxVisibleButtons) {
        return 1
      }

      if (this.currentPage === this.totalPages) {
        return this.totalPages - this.maxVisibleButtons + 1
      }
      //khi ở trang giữa
      return this.currentPage - 1
    },
/**
 * Trang cuối cùng
 * Author: ND_Tuan (26/07/2022)
 */
    endPage () {
      if (this.totalPages === 0) {
        return 1
      }
      if (this.totalPages < this.maxVisibleButtons) {
        return this.totalPages
      }
      return Math.min(this.startPage + this.maxVisibleButtons - 1, this.totalPages)
    },
/**
 * Trang
 * Author: ND_Tuan (26/07/2022)
 */
    pages () {
      const range = []
      for (let i = this.startPage; i <= this.endPage; i++) {
        range.push({
          name: i,
          isDisabled: i === this.currentPage
        })
      }
      return range
    }
  },
  
  methods: {
/**
 * Click vào trang trước
 * Author: ND_Tuan (26/07/2022)
 */
    onClickFirstPage () {
      if (this.isInFirstPage) {
        return false
      }
      this.$emit('pagechanged', 1)
    },
/**
 * Click nút tiến về trước
 * Author: ND_Tuan (26/07/2022)
 */
    onClickPreviousPage () {
      if (this.isInFirstPage) {
        return false
      }
      this.$emit('pagechanged', this.currentPage - 1)
    },
/**
 * Click vô trang
 * Author: ND_Tuan (26/07/2022)
 * @param {*} page 
 */
    onClickPage (page) {
      this.$emit('pagechanged', page)
    },
/**
 * Click vô nút tiến về Sau
 * Author: ND_Tuan (26/07/2022)
 */
    onClickNextPage () {
      if (this.isInLastPage) {
        return false
      }
      this.$emit('pagechanged', this.currentPage + 1)
    },
/**
 * Click vô nút Sau
 * Author: ND_Tuan (26/07/2022)
 */
    onClickLastPage () {
      console.log('onClickLastPage')
      if (this.isInLastPage) {
        return false
      }
      this.$emit('pagechanged', this.totalPages)
    },
/**
 * Trang 
 * Author: ND_Tuan (26/07/2022)
 * @param {*} page 
 */
    isPageActive (page) {
      return this.currentPage === page
    }
  }
}
</script>
<style  scoped>
.pagination {
    list-style-type: none;
    margin: 10px 0;
  }
.pagination-item {
      display: inline-block;
      color: #ddd;}
      
.pagination-item a {
        text-decoration: none;
        margin: 5px;
        color: #2c3e50;
      }
.pagination-item   a.disabled {
        color: #ccc;
        cursor: no-drop;
      }
.pagination-item  .active {
        background-color: #01B075;
        color: #ffffff !important;
        font-weight: bold;
        padding: 3px 8px;
      }
    
  
button[disabled], html input[disabled] {
    cursor: default;
    color: lightgray;
  }

</style>
