import VueRouter from 'vue-router'
import Employees from './Pages/Employees'
import Companies from './Pages/Companies'

export default new VueRouter({
    routes: [
        {
            path: '/employees',
            component: Employees
        },
        {
            path: '/companies',
            component: Companies
        },
        {
            path: '*',
            component: Employees
        }
    ],
    mode: 'history'
})
