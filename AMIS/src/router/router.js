import {createRouter, createWebHistory} from "vue-router"
import EmployeeList from "../components/pages/Employee.vue"
import AmisCustomer from "../components/pages/Customer.vue"


 const routers = [
    { path: "/empl", component: EmployeeList},
    { path: "/cus", component: AmisCustomer},
 ]



const router = createRouter({
    history: createWebHistory(),
    routes: routers,
})


export default router
