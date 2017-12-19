import Vue from 'vue';
import axios from 'axios';
import { Component } from 'vue-property-decorator';
import DateTimeFormat = Intl.DateTimeFormat;

interface MessageBubble {
    MessageText: string;
    MessageTime?: number;
    MessageTranslated?: string;
}

let MessageText: string;

@Component
export default class MessengerComponent extends Vue {
    messageBubble: MessageBubble[] = [];

    messageSent: MessageBubble = {
        MessageText: MessageText,
        MessageTime: Date.now()
    };

    // This button sends the text message to the API to be translated
    onSend() {
        console.log(JSON.stringify(this.messageSent));
        axios.post('/api/Message/', JSON.stringify(this.messageSent), {
            headers: {
                'Content-Type': 'application/json',
            }
        })
            .then(response => response.data as Promise<MessageBubble[]>)
            .then(data => {
                this.messageBubble = data;
                console.log(data)
            })
            .catch(function (error) {
                console.log(error, "Error, with the input or server");
            });
    }
}