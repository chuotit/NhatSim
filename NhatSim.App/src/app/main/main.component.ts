import { Component, OnInit } from '@angular/core';
import { AuthenService } from '../core/services/authen.service';
import { UrlConstants } from '../core/commons/url.constants';
import { SystemConstants } from '../core/commons/system.constants';
import { Router } from '@angular/router';
import { LoggedInUser } from '../core/domain/loggedin.user';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.css']
})
export class MainComponent implements OnInit {
  public userInfo: LoggedInUser;
  constructor(
    private authenService: AuthenService,
    private router: Router
  ) { }

  ngOnInit() {
    this.userInfo = this.authenService.getLoggedInUser();
  }

  logout() {
    this.authenService.logout();
    this.router.navigate([UrlConstants.LOGIN]);
  }
}
