import { PipesModule } from './../../_core/pipes/pipes.module';
import { SafeHtmlPipe } from './../../_core/pipes/safe-html.pipe';
import { ChatService } from './../../_services/chat.service';
import { HeaderComponent } from './../../_core/components/header/header.component';
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
    PipesModule
  ],
  declarations: [
    MessagePage,
    HeaderComponent
  ],
  providers: [
    ChatService
  ]
})
export class MessagePageModule {}
