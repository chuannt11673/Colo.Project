import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { UserInfoPage } from './user-info.page';
import { UserInfoResolver } from './user-info.resolver';

const routes: Routes = [
  {
    path: '',
    component: UserInfoPage,
    resolve: {
      userInfo: UserInfoResolver
    }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class UserInfoPageRoutingModule {}
