import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { FriendRequestPage } from './friend-request.page';

const routes: Routes = [
  {
    path: '',
    component: FriendRequestPage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class FriendRequestPageRoutingModule {}
