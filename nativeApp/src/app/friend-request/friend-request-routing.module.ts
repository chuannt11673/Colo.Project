import { FriendRequestResolver } from './friend-request.resolver';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { FriendRequestPage } from './friend-request.page';

const routes: Routes = [
  {
    path: '',
    resolve: [FriendRequestResolver],
    component: FriendRequestPage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class FriendRequestPageRoutingModule {}
