import './css/site.css';
import 'bulma/css/bulma.css';
import Vue from 'vue';
import VueRouter from 'vue-router';
Vue.use(VueRouter);
// Vue.use(axios);
var routes = [
    { path: '/', component: require('./components/home/home.vue.html') },
    { path: '/counter', component: require('./components/counter/counter.vue.html') },
    { path: '/fetchdata', component: require('./components/fetchdata/fetchdata.vue.html') },
    { path: '/messenger', component: require('./components/messenger/messenger.vue.html') },
    { path: '/messenger', component: require('./components/login/login.vue.html') }
];
new Vue({
    el: '#app-root',
    router: new VueRouter({ mode: 'history', routes: routes }),
    render: function (h) { return h(require('./components/app/app.vue.html')); }
});
//# sourceMappingURL=boot.js.map