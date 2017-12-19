import Vue from 'vue';
import Component from 'vue-class-component';

@Component({
    components: {
        MenuComponent: require('../layout/layout.vue.html')
    }
})
export default class HomeComponent extends Vue {
    
}
