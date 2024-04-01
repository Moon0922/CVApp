import '@mdi/font/css/materialdesignicons.css'
import 'vuetify/styles'

import {createVuetify} from 'vuetify'

const myCustomLightTheme = {
    dark: false,
    colors: {
        primary: '#6200EE',
    }
}
export default createVuetify({
    theme: {
        themes: {
            light: {
                dark: false,
                colors: {
                    primary: '#30abcc',
                    secondary: '#F1FAFF',
                    accent: '#E52F37',
                },
            },
        },
    },
});
