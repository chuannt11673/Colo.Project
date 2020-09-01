import { PostService } from './../../../_services/post.service';
import { FileService } from './../../../_services/file.service';
import { TranslateConfigService } from './../../services/translate-config.service';
import { ComponentsModule } from 'src/app/_core/components/components.module';
import { IonicModule } from '@ionic/angular';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CreatePostComponent } from './create-post.component';
import { FormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    CreatePostComponent
  ],
  entryComponents: [
    CreatePostComponent
  ],  
  imports: [
    CommonModule,
    IonicModule,
    FormsModule,
    ComponentsModule
  ],
  providers: [
    TranslateConfigService,
    FileService,
    PostService
  ]
})
export class CreatePostModule { }
