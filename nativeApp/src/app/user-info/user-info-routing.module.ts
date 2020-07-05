import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { UserInfoPage } from './user-info.page';
import { UserInfoResolver } from './user-info.resolver';

const routes: Routes = [
  {
    path: '',
    resolve: [UserInfoResolver],
    component: UserInfoPage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class UserInfoPageRoutingModule {}
