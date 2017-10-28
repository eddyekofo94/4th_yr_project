import Vue from 'vue';
import axios from 'axios';
import { Component } from 'vue-property-decorator';
import DateTimeFormat = Intl.DateTimeFormat;

interface MessageBubble {
    MessageText: string;
    MessageTime? : number;
    MessageTranslated? : string;
}

@Component
export default class MessengerComponent extends Vue {
msg: string = "Hello";
messageBubble: MessageBubble = {
    MessageText: this.msg,
    MessageTime: Date.now(),
    MessageTranslated: this.msg
};
    // This button sends the text message to the API to be translated
    onSend() {
        console.log(this.messageBubble);
        fetch("/api/Message/",
            {
                method: "POST",
                headers: {
                    "Content-Type": "application/json"  
                },
                //The varibles must match those of the Model else, it won't work.
                body: JSON.stringify({"MessageText": this.msg})
                // body: JSON.stringify(this.messageBubble)
            })
            .then(function (res) { return res.json() })
            .then(function (data) {
                console.log(data)
            })
    }
}