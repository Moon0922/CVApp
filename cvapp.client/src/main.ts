import {registerPlugins} from './plugins'
import {createApp} from 'vue'
import App from './App.vue'
import router from "./router";

const app = createApp(App).use(router)

registerPlugins(app)

app.mount('#app')
