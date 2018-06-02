// Подключение модуля vue и стартового компонента приложения
import Vue from 'vue'
import App from './App.vue'

// Подключение модуля Vuetify для создания CRUD таблиц и необходимых стилей
import Vuetify from 'vuetify'
import 'vuetify/dist/vuetify.min.css'
import 'material-design-icons-iconfont/dist/material-design-icons.css'

// Подключение модуля vue-resource для работы с запросами
import VueResource from 'vue-resource'

// Подключение модуля vue-route и списка маршрутов
import VueRouter from 'vue-router'
import router from './routes'

// Регистрация подключенных модулей
Vue.use(VueRouter)
Vue.use(Vuetify)
Vue.use(VueResource)

// Создание экземпляра приложения
new Vue({
  el: '#app',
  render: h => h(App),
  router
})