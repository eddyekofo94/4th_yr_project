import Vue from 'vue';
import { Component } from 'vue-property-decorator';


interface MessageBubble {
    dateFormatted: string;
    message: string;
    messageTranslated: string;
}

@Component
export default class MessengerComponent extends Vue {
    msg : string = "Hello Vue";

    messages: MessageBubble[] = [];

    onClick(): void {
        window.alert(this.msg)
    }
}