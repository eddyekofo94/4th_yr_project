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
var MessageText;
var MessengerComponent = (function (_super) {
    __extends(MessengerComponent, _super);
    function MessengerComponent() {
        var _this = _super !== null && _super.apply(this, arguments) || this;
        _this.messageBubble = {
            MessageText: MessageText,
            MessageTime: Date.now()
        };
        return _this;
    }
    // This button sends the text message to the API to be translated
    MessengerComponent.prototype.onSend = function () {
        console.log(JSON.stringify(this.messageBubble));
        fetch("/api/Message/", {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            //The varibles must match those of the Model else, it won't work.
            body: JSON.stringify(this.messageBubble)
        })
            .then(function (res) {
            if (!res.ok) {
                throw Error(res.statusText);
            }
            return res.json();
        })
            .then(function (data) {
            console.log(data);
        })
            .catch(function () {
            console.log("Error, with the input or server");
        });
    };
    return MessengerComponent;
}(Vue));
MessengerComponent = __decorate([
    Component
], MessengerComponent);
export default MessengerComponent;
//# sourceMappingURL=messenger.js.map