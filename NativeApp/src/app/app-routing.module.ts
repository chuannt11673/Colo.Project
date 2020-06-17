import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: '', loadChildren: () => import('./_modules/login/login.module').then(m => m.LoginModule)
  },
  {
    path: 'home', loadChildren: () => import('./_modules/home/home.module').then(m => m.HomeModule)
  }
];
@NgModule({
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
