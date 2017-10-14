import { Routes } from '@angular/router';
import { MainComponent } from './main.component';

export const mainRoutes: Routes = [
  //main/
  {
    path: '', component: MainComponent, children: [
      { path: '', redirectTo: 'home', pathMatch: 'full' },
      //main/home
      { path: 'home', loadChildren: './home/home.module#HomeModule' },
      //main/sim-network
      { path: 'sim-network', loadChildren: './sim-network/sim-network.module#SimNetworkModule' }
    ]
  }
]
