import { Injectable } from '@angular/core';
import { Http, Headers, RequestOptions, Response } from '@angular/http';
import 'rxjs/add/operator/map';
import { LoggedInUser } from '../domain/loggedin.user';
import { SystemConstants } from '../commons/system.constants';

@Injectable()
export class AuthenService {

    constructor(private _http: Http) { }

    login(userName: string, password: string) {
        let body = 'username=' + encodeURIComponent(userName)
            + '&password=' + encodeURIComponent(password)
            + '&grant_type=password';

        let headers = new Headers();
        headers.append('Content_Type', 'applycation/x-www-form-urlencoded');

        let options = new RequestOptions({ headers: headers });

        return this._http.post(SystemConstants.BASE_API + '/api/oauth/token', body, options).map((response: Response) => {
            let userInfo: LoggedInUser = response.json();
            if (userInfo && userInfo.access_token) {
                localStorage.removeItem(SystemConstants.CURRENT_USER);
                localStorage.setItem(SystemConstants.CURRENT_USER, JSON.stringify(userInfo));
            }
        });
    }

    logout() {
        localStorage.removeItem(SystemConstants.CURRENT_USER);
    }

    isUserAuthenticated(): boolean {
        let isAuth = false;
        let userInfo = localStorage.getItem(SystemConstants.CURRENT_USER);
        if (userInfo != null) {
            isAuth = true;
        }
        return isAuth;
    }

    getLoggedInUser(): LoggedInUser {
        let userInfo: LoggedInUser;
        if (this.isUserAuthenticated()) {
          let userData = JSON.parse(localStorage.getItem(SystemConstants.CURRENT_USER));
          userInfo = new LoggedInUser(userData.access_token, userData.fullname, userData.username, userData.email,
            userData.agentId);
        } else {
            userInfo = null;
        }
        return userInfo;
    }
}
