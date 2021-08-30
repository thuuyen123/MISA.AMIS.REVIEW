import Vue from 'vue'
import App from './App.vue'
import axios from 'axios'
import VueAxios from 'vue-axios'
import VueRouter from 'vue-router'
export const eventBus = new Vue();

import TheEmployee from './view/employee/TheEmployee.vue';
import InUpdating from './view/InUpdating.vue';

const routes = [
  {path:'/',component: TheEmployee},
  {path:'/employee', name:'Employee', component: TheEmployee},
  {path:'/inUpdating', name:'InUpdating', component: InUpdating}
]; 

const router = new VueRouter({
  routes,
});

Vue.use(VueRouter)
Vue.use(VueAxios, axios)
Vue.config.productionTip = false

new Vue({
  router,
  render: h => h(App),
}).$mount('#app')
      
