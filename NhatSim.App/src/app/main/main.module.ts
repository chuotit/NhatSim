import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MainComponent } from './main.component';

import { mainRoutes } from './main.routes';
import { Routes, RouterModule } from '@angular/router';

import { HomeModule } from './home/home.module';
import { SimNetworkModule } from './sim-network/sim-network.module';

@NgModule({
  imports: [
      CommonModule,
      HomeModule,
      SimNetworkModule,
      RouterModule.forChild(mainRoutes)
  ],
  declarations: [MainComponent]
})
export class MainModule { }
