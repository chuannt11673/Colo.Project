import { ImageReviewModule } from './../_core/modals/image-review/image-review.module';
import { ComponentsModule } from './../_core/components/components.module';
import { FileService } from './../_services/file.service';
import { ChatService } from './../_services/chat.service';
import { PipesModule } from './../_core/pipes/pipes.module';
import { SignalRService } from './../_services/signal-r.service';
import { UserService } from './../_services/user.service';
import { Camera } from '@ionic-native/Camera/ngx';
import { Keyboard } from '@ionic-native/keyboard/ngx';
import { NgModule } from '@angular/core';
import { CommonModule, DatePipe } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { ChatPageRoutingModule } from './chat-routing.module';

import { ChatPage } from './chat.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    ChatPageRoutingModule,
    PipesModule,
    ComponentsModule,
    ImageReviewModule
  ],
  providers: [
    Keyboard,
    Camera,
    SignalRService,
    UserService,
    ChatService,
    FileService,
    DatePipe
  ],
  declarations: [
    ChatPage
  ]
})
export class ChatPageModule { }
