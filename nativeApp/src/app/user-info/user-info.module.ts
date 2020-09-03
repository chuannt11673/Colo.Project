import { PostService } from 'src/app/_services/post.service';
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
import { CommentPostModule } from '../_core/modals/comment-post/comment-post.module';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    UserInfoPageRoutingModule,
    PipesModule,
    CommentPostModule
  ],
  providers: [
    UserService,
    UserInfoService,
    UserInfoResolver,
    PostService
  ],
  declarations: [
    UserInfoPage,
    DividerComponent
  ]
})
export class UserInfoPageModule {}
