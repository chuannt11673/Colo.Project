import { CommentPostModule } from './../../_core/modals/comment-post/comment-post.module';
import { CreatePostModule } from './../../_core/modals/create-post/create-post.module';
import { PipesModule } from './../../_core/pipes/pipes.module';
import { PostService } from './../../_services/post.service';
import { ComponentsModule } from 'src/app/_core/components/components.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { DiaryPageRoutingModule } from './diary-routing.module';

import { DiaryPage } from './diary.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    DiaryPageRoutingModule,
    ComponentsModule,
    PipesModule,
    CreatePostModule,
    CommentPostModule
  ],
  providers: [
    PostService
  ],
  declarations: [DiaryPage]
})
export class DiaryPageModule {}
