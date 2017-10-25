import Vue from 'vue';
import { Component } from 'vue-property-decorator';


interface MessageBubble {
    dateFormatted: string;
    message: string;
    messageTranslated: string;
}

@Component
export default class MessengerComponent extends Vue {
    msg: string = "Hello Vue";

    messages: MessageBubble[] = [];

    onClick(): void {
        // console.log(this.msg)
        fetch("/api/TextTranslate/",
            {
                method: "POST",
                body: this.msg
            })
            .then(function (res) { return res.json() })
            .then(function (data) {
                console.log(JSON.stringify(data))
            })
    }
}