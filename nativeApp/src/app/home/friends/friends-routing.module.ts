import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { FriendsPage } from './friends.page';
import { FriendsResolver } from './friends.resolver';

const routes: Routes = [
  {
    path: '',
    component: FriendsPage,
    resolve: {
      friends: FriendsResolver
    }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class FriendsPageRoutingModule {}
