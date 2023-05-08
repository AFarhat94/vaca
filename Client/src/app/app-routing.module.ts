import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MapComponent } from './map/map.component';
import { AuthGuard } from './core/guards/auth.guard';

const routes: Routes = [
  { path: '', 
    canActivate: [AuthGuard],
    component: MapComponent 
  },
  { path: 'account', loadChildren: () => import("../app/account/account.module").then(m => m.AccountModule) }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
