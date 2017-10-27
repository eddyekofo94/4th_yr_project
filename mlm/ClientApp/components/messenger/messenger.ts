import Vue from 'vue';
import axios from 'axios';
import { Component } from 'vue-property-decorator';

interface MessageBubble {
    MessageText: string;
}

@Component
export default class MessengerComponent extends Vue {
msg: string = "Hello, This is a test text";
messageBubble: MessageBubble;

    onSend() {
      
        fetch("/api/Message/",
            {
                method: "POST",
                headers: {
                    "Content-Type": "application/json"  
                },
                body: JSON.stringify({"MessageText": this.msg})
            })
            .then(function (res) { return res.text() })
            .then(function (data) {
                console.log(data)
            })
    }
}