import { ComponentsModule } from './../../_core/components/components.module';
import { PipesModule } from './../../_core/pipes/pipes.module';
import { ChatService } from './../../_services/chat.service';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { MessagePageRoutingModule } from './message-routing.module';

import { MessagePage } from './message.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    MessagePageRoutingModule,
    PipesModule,
    ComponentsModule
  ],
  declarations: [
    MessagePage
  ],
  providers: [
    ChatService
  ]
})
export class MessagePageModule {}
