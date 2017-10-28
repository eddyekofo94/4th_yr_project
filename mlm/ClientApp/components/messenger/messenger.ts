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
    
    messageBubble: MessageBubble = {
        MessageText: MessageText,
        MessageTime: Date.now()
    };

    // This button sends the text message to the API to be translated
    onSend() {
        console.log(JSON.stringify(this.messageBubble));
        fetch("/api/Message/",
                {
                    method: "POST",
                    headers: {
                        "Content-Type": "application/json"
                    },
                    //The varibles must match those of the Model else, it won't work.
                    body: JSON.stringify(this.messageBubble)
                })
            .then(function(res) {
                if (!res.ok) {
                    throw Error(res.statusText);
                }
                return res.json() 
            })
            .then(function(data) {
                console.log(data)
            })
            .catch(function() {
                console.log("Error, with the input or server");
            });
    }
}