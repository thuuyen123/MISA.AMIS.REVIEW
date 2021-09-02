import Vue from 'vue'
import App from './App.vue'
import axios from 'axios'
import VueAxios from 'vue-axios'
import VueRouter from 'vue-router'
import VTooltip from 'v-tooltip'
import DatePicker from 'vue2-datepicker';
import 'vue2-datepicker/index.css';
import Toast from "vue-toastification";
import "vue-toastification/dist/index.css";
import Paginate from 'vuejs-paginate'

export const eventBus = new Vue();
require("./js/common/prototype");
import TheEmployee from './view/employee/TheEmployee.vue';
import InUpdating from './view/InUpdating.vue';

const routes = [
  { path: '/employee', name: 'Employee', component: TheEmployee },
  { path: '/inUpdating', name: 'InUpdating', component: InUpdating }
];

const router = new VueRouter({
  routes,
});

Vue.component('paginate', Paginate)

Vue.use(Toast, {
  transition: "Vue-Toastification__bounce",
  maxToasts: 10,
  newestOnTop: true
});
Vue.component('datepicker', DatePicker);
Vue.use(VTooltip)
Vue.use(VueRouter)
Vue.use(VueAxios, axios)
Vue.config.productionTip = false

new Vue({
  router,
  render: h => h(App),
}).$mount('#app')

