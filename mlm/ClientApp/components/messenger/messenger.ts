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
        fetch("/api/Message/",
                {
                    method: "POST",
                    headers: {
                        "Content-Type": "application/json"
                    },
                    //The varibles must match those of the Model else, it won't work.
                    body: JSON.stringify(this.messageSent)
                })
            .then(response => response.json() as Promise<MessageBubble[]>)
            .then(data =>{
                this.messageBubble = data;
                console.log(data)
            })
            .catch(function() {
                console.log("Error, with the input or server");
            });
    }
}