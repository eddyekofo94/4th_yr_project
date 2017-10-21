import Vue from 'vue';
import { Component } from 'vue-property-decorator';

@Component
export default class MessengerComponent extends Vue {
    msg : string = "Hello Vue";

    onClick(): void {
        window.alert(this.msg)
    }
}