﻿import { Component, OnInit } from '@angular/core';
import { OAuthService } from 'angular-oauth2-oidc';

import { LoginModel, UtilityService, NotificationsService } from '@app/core';
import { ControlBase, ControlTextbox } from '@app/shared';

@Component({
    selector: 'appc-login',
    styleUrls: ['./login.component.scss'],
    templateUrl: './login.component.html'
})
export class LoginComponent implements OnInit {
    public loginModel: LoginModel;
    public controls: any;

    constructor(
        public oAuthService: OAuthService,
        public us: UtilityService,
        private ns: NotificationsService) { }
    public login(model: LoginModel): void {
        this.oAuthService.fetchTokenUsingPasswordFlow(model.username, model.password)
            .then((x: any) => {
                localStorage.setItem('id_token', x.id_token);
                this.oAuthService.setupAutomaticSilentRefresh();
                this.us.navigate('');
            })
            .catch(err => this.ns.error('Error getting token', err));
    }

    public ngOnInit() {
        const controls: Array<ControlBase<any>> = [
            new ControlTextbox({
                key: 'username',
                label: 'Email',
                placeholder: 'Email',
                value: '',
                type: 'email',
                required: true,
                order: 1
            }),
            new ControlTextbox({
                key: 'password',
                label: 'Password',
                placeholder: 'Password',
                value: '',
                type: 'password',
                required: true,
                order: 2
            })
        ];

        this.controls = controls;
    }
}
