import { PipesModule } from './../../_core/pipes/pipes.module';
import { UserService } from './../../_services/user.service';
import { FileService } from './../../_services/file.service';
import { ImageReviewModule } from './../../_core/modals/image-review/image-review.module';
import { LogoutActionSheet, UploadProfileActionSheet, UploadCoverActionSheet } from '../../_interface/action-sheet.template';
import { Camera } from '@ionic-native/Camera/ngx';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { MorePageRoutingModule } from './more-routing.module';

import { ComponentsModule } from 'src/app/_core/components/components.module';

import { MorePage } from './more.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    MorePageRoutingModule,
    ComponentsModule,
    ImageReviewModule,
    PipesModule
  ],
  providers: [
    Camera,
    FileService,
    UserService,
    LogoutActionSheet,
    UploadProfileActionSheet,
    UploadCoverActionSheet
  ],
  declarations: [
    MorePage
  ]
})
export class MorePageModule {}
