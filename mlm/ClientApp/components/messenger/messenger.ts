import Vue from 'vue';
import { Component } from 'vue-property-decorator';

interface Messages {
    messageFrom: string;
    messageRecieved: string;
}

@Component
export default class FetchMessages extends Vue {
    message: string = 'Hello!'
    // Component methods can be declared as instance methods

    onClick(): void {
        console.log(this.message)
    }

    // messages: Messages[] = [];

    // mounted() {
    //     fetch('api/TranslateText/Messages')
    //         .then(response => response.json() as Promise<Messages[]>)
    //         .then(data => {
    //             this.messages = data;
    //         });
    // }
}