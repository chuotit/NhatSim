import { Component, OnInit } from '@angular/core';
import { NotificationService } from '../core/services/notification.service';
import { AuthenService } from '../core/services/authen.service';
import { MessageContstants } from '../core/commons/message.constants';
import { UrlConstants } from '../core/commons/url.constants';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loading = false;
  model: any = {};
  returnUrl: string;

  constructor(
    private authenService: AuthenService,
    private notificationService: NotificationService,
    private route: ActivatedRoute,
    private router: Router
  ) { }

  ngOnInit() {
  }
  loginSubmit() {
    this.loading = true;
    this.authenService.login(this.model.username, this.model.password).subscribe(data => {
      let redirectUrl = this.route.snapshot.queryParams['returnUrl'] ? this.route.snapshot.queryParams['returnUrl'] : UrlConstants.HOME;
      this.router.navigate([redirectUrl]);
    }, error => {
      this.notificationService.printErrorMessage(MessageContstants.SYSTEM_ERROR_MSG);
      this.loading = false;
    });
  }
}
