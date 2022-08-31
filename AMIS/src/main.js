


import { createApp } from 'vue'
import App from './App.vue'
import router from './router/router'
import axios from 'vue'
import VueAxios from 'vue-axios'

import ElementPlus from 'element-plus'
import 'element-plus/dist/index.css'


// import the package
import VueAwesomePaginate from "vue-awesome-paginate";

// import the necessary css file
import "vue-awesome-paginate/dist/style.css";
  



createApp(App).use(router, VueAxios, axios, VueAwesomePaginate,ElementPlus).mount('#app')



