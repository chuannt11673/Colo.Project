import { UserService } from './../_services/user.service';
import { FriendRequestResolver } from './friend-request.resolver';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { FriendRequestPageRoutingModule } from './friend-request-routing.module';

import { FriendRequestPage } from './friend-request.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    FriendRequestPageRoutingModule
  ],
  providers: [
    UserService,
    FriendRequestResolver
  ],
  declarations: [FriendRequestPage]
})
export class FriendRequestPageModule {}
