import { PipesModule } from './../_core/pipes/pipes.module';
import { UserInfoResolver } from './user-info.resolver';
import { UserService } from './../_services/user.service';
import { UserInfoService } from './../_services/user-info.service';
import { DividerComponent } from './../_core/components/divider/divider.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { UserInfoPageRoutingModule } from './user-info-routing.module';

import { UserInfoPage } from './user-info.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    UserInfoPageRoutingModule,
    PipesModule
  ],
  providers: [
    UserService,
    UserInfoService,
    UserInfoResolver
  ],
  declarations: [
    UserInfoPage,
    DividerComponent
  ]
})
export class UserInfoPageModule {}
