var __extends = (this && this.__extends) || (function () {
    var extendStatics = Object.setPrototypeOf ||
        ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
        function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import Vue from 'vue';
import { Component } from 'vue-property-decorator';
var MessageBubble = (function () {
    function MessageBubble() {
    }
    return MessageBubble;
}());
var MessengerComponent = (function (_super) {
    __extends(MessengerComponent, _super);
    function MessengerComponent() {
        var _this = _super !== null && _super.apply(this, arguments) || this;
        _this.msg = "Hello";
        return _this;
    }
    MessengerComponent.prototype.onSend = function (msg) {
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
        fetch("/api/Message/", {
            method: "POST",
            headers: {
                'Content-Type': 'application/json'
            },
            body: "Testing this program"
        })
            .then(function (res) { return res.json(); })
            .then(function (data) {
            console.log(data);
        });
    };
    return MessengerComponent;
}(Vue));
MessengerComponent = __decorate([
    Component
], MessengerComponent);
export default MessengerComponent;
//# sourceMappingURL=messenger.js.map