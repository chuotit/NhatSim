import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpModule } from '@angular/http';
import { LoginComponent } from './login.component';
import { Routes, RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';

import { NotificationService } from '../core/services/notification.service';
import { AuthenService } from '../core/services/authen.service';

export const loginRoutes: Routes = [
  //login/
  { path: '', component: LoginComponent }
]

@NgModule({
  imports: [
    HttpModule,
    CommonModule,
    FormsModule,
    RouterModule.forChild(loginRoutes)
  ],
  providers: [AuthenService, NotificationService],
  declarations: [LoginComponent]
})
export class LoginModule { }
