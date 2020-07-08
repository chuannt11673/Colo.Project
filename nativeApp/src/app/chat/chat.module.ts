import { Camera } from '@ionic-native/Camera/ngx';
import { Keyboard } from '@ionic-native/keyboard/ngx';
import { MessageBoxComponent } from './../_core/components/message-box/message-box.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
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
    PickerModule
  ],
  providers: [
    Keyboard,
    Camera,
    EmojiService
  ],
  declarations: [
    ChatPage,
    MessageBoxComponent
  ]
})
export class ChatPageModule { }
