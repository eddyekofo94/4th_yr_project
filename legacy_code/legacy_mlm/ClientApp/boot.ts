import './css/site.css';
import 'bootstrap';
import 'bulma/css/bulma.css'
import * as firebase from 'firebase'
import Vue from 'vue';
import VueRouter from 'vue-router';
// import VueFire from 'vuefire';
// import Vuetify from 'vuetify';


// Vue.use(Vuetify)
Vue.use(VueRouter);

const routes = [
    { path: '/', component: require('./components/home/home.vue.html') },
    { path: '/counter', component: require('./components/counter/counter.vue.html') },
    { path: '/fetchdata', component: require('./components/fetchdata/fetchdata.vue.html') },
    { path: '/messenger', component: require('./components/messenger/messenger.vue.html') }
];

new Vue({
    el: '#app-root',
    router: new VueRouter({ mode: 'history', routes: routes }),
    render: h => h(require('./components/app/app.vue.html')),
    created() {
        firebase.initializeApp({
            apiKey: "AIzaSyDUlYQ4GoSHNRlQnxGvVgbY_ZBYIISWY5I",
            authDomain: "mlm-firebase.firebaseapp.com",
            databaseURL: "https://mlm-firebase.firebaseio.com",
            storageBucket: "mlm-firebase"
        })
    }});
