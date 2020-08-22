import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { MessagePage } from './message.page';
import { MessageResolver } from './message.resolver';

const routes: Routes = [
  {
    path: '',
    component: MessagePage,
    resolve: {
      data: MessageResolver
    }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  providers: [
    MessageResolver
  ],
  exports: [RouterModule],
})
export class MessagePageRoutingModule {}
