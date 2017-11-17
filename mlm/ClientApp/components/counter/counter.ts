import Vue from 'vue';
import  Component  from 'vue-class-component';

@Component
export default class CounterComponent extends Vue {
    currentcount: number = 0;

    incrementCounter() {
        this.currentcount++;
    }
    mounted(){
        console.log();

    }
    
}
