import Vue from 'vue'
import VueRouter from 'vue-router'
import login from '@/components/login'
import addInfo from '@/components/addInfo'
import roomIndex from '@/components/roomIndex'
import addRooms from '@/components/addRooms'
import customerIndex from '@/components/customerIndex'
import addcustomer from'@/components/addcustomer'
import login1 from '@/components/login1'
Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'login',
    component: login
  },
  {
    path: '/addcustomer',
    name: 'addcustomer',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: addcustomer
  },
  {
    path:'/addInfo',
    name:'addInfo',
    component:addInfo
  },
  {
    path:'/roomIndex',
    name:'roomIndex',
    component:roomIndex
  },
  {
    path:'/addRooms',
    name:'addRooms',
    component:addRooms
  },
  {
    path:'/customerIndex',
    name:'customerIndex',
    component:customerIndex
  },
  {
    path:'/login1',
    name:'login1',
    component:login1
  }
]

const router = new VueRouter({
  routes
})

export default router
