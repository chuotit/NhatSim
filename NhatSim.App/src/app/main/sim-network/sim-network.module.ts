import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SimNetworkComponent } from './sim-network.component';

import { Routes, RouterModule } from '@angular/router';

export const sinNetworkRoutes: Routes = [
  { path: '', redirectTo: 'index', pathMatch: 'full' },
  { path: 'index', component: SimNetworkComponent }
]

@NgModule({
  imports: [
      CommonModule,
      RouterModule.forChild(sinNetworkRoutes)
  ],
    declarations: [SimNetworkComponent]
})
export class SimNetworkModule { }
