import Vue from 'vue';
import axios from 'axios';
import { Component } from 'vue-property-decorator';

class MessageBubble {
    dateSent: Date;
    message: string;
    messageTranslated: string;
}

@Component
export default class MessengerComponent extends Vue {
msg: string = "Hello";

    onSend(msg: string) {
        // console.log(this.msg);

        axios.post("/api/Message/" , {
            headers:{
                'Content-Type': "application/text"
            },
            data: this.msg
        })
            .then(function (res: any) {
                console.log(res.data);
                
                return res;
            })
            .catch(function(res: any) {
                if(res instanceof Error) {
                    console.log(res.message);
                } else {
                    console.log(res.data);
                }
            });
        
        // fetch("/api/SendMessage/",
        //     {
        //         method: "POST",
        //         headers: {
        //             'Accept': 'application/json, text/plain, */*',
        //             'Content-Type': 'application/json'                },
        //         body: {"message": this.msg}
        //     })
        //     .then(function (res) { return res.text() })
        //     .then(function (data) {
        //         console.log(data)
        //     })
    }
}