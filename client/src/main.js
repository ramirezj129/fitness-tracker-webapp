
import { createApp } from 'vue'
import App from './App.vue'
import router from './router'
import store from './store/store'; // Make sure this path is correct



const app = createApp(App)

app.use(store);

app.use(router)

app.mount('#app')
