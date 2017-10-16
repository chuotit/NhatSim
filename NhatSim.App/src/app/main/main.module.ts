import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpModule } from '@angular/http';

import { MainComponent } from './main.component';

import { mainRoutes } from './main.routes';
import { Routes, RouterModule } from '@angular/router';

import { AuthenService } from '../core/services/authen.service';

import { HomeModule } from './home/home.module';
import { SimNetworkModule } from './sim-network/sim-network.module';

@NgModule({
  imports: [
      HttpModule,
      CommonModule,
      HomeModule,
      SimNetworkModule,
      RouterModule.forChild(mainRoutes)
  ],
  providers: [AuthenService],
  declarations: [MainComponent]
})
export class MainModule { }
