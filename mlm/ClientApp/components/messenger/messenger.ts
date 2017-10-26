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

    onSend(msg: any) {
        // // console.log(this.msg);
        // axios.post("/api/Message/" , {
        //     headers:{
        //         'Content-Type': "application/text",
        //         "Accept": "application/text, text/plain, */*"
        //     },
        //     data: JSON.stringify(this.msg),
        //     body: this.msg
        // })
        //     .then(function (res: any) {
        //         console.log(res.data);
        //        
        //         return res.data;
        //     })
        //     .catch(function(res: any) {
        //         if(res instanceof Error) {
        //             console.log(res.message);
        //         } else {
        //             console.log(res.data);
        //         }
        //     });
        
        fetch("/api/Message/",
            {
                method: "POST",
                headers: {
                    'Content-Type': 'application/json'                },
                body: "Testing this program"
            })
            .then(function (res) { return res.json() })
            .then(function (data) {
                console.log(data)
            })
    }
}