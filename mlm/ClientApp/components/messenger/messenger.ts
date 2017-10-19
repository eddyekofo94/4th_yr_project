import Vue from 'vue';
import { Component } from 'vue-property-decorator';

interface Messages{
    messageFrom: string;
    messageRecieved: string;
}

@Component
export default class FetchMessages extends Vue{
    msg: string = "Hello"
    onClick(): void {
        window.alert(this.msg)
    }

    // messages: Messages[] = [];
    // mounted() {
    //     fetch('api/TranslateTest/Messages')
    //         .then(response => response.json() as Promise<Messages[]>)
    //         .then(data => {
    //             this.messages = data;
    //         });
    // }
}