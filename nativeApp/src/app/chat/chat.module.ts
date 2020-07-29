import { FileService } from './../_services/file.service';
import { ChatService } from './../_services/chat.service';
import { PipesModule } from './../_core/pipes/pipes.module';
import { SignalRService } from './../_services/signal-r.service';
import { UserService } from './../_services/user.service';
import { Camera } from '@ionic-native/Camera/ngx';
import { Keyboard } from '@ionic-native/keyboard/ngx';
import { MessageBoxComponent } from './../_core/components/message-box/message-box.component';
import { NgModule } from '@angular/core';
import { CommonModule, DatePipe } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { ChatPageRoutingModule } from './chat-routing.module';

import { ChatPage } from './chat.page';
import { EmojiModule, EmojiService } from '@ctrl/ngx-emoji-mart/ngx-emoji';
import { PickerModule } from '@ctrl/ngx-emoji-mart';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    ChatPageRoutingModule,
    EmojiModule,
    PickerModule,
    PipesModule
  ],
  providers: [
    Keyboard,
    Camera,
    EmojiService,
    SignalRService,
    UserService,
    ChatService,
    FileService,
    DatePipe
  ],
  declarations: [
    ChatPage,
    MessageBoxComponent
  ]
})
export class ChatPageModule { }
