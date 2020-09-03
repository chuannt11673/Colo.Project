import { PipesModule } from './../../pipes/pipes.module';
import { IonicModule } from '@ionic/angular';
import { PostService } from './../../../_services/post.service';
import { CommentPostComponent } from './comment-post.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ComponentsModule } from '../../components/components.module';



@NgModule({
  declarations: [CommentPostComponent],
  entryComponents: [CommentPostComponent],
  providers: [
    PostService
  ],
  imports: [
    CommonModule,
    IonicModule,
    FormsModule,
    ComponentsModule,
    PipesModule
  ]
})
export class CommentPostModule { }
