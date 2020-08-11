import { EmojiModule, EmojiService } from '@ctrl/ngx-emoji-mart/ngx-emoji';
import { IonicModule } from '@ionic/angular';
import { MessageBoxComponent } from './message-box/message-box.component';
import { HeaderComponent } from './header/header.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PickerModule } from '@ctrl/ngx-emoji-mart';

@NgModule({
  declarations: [
    HeaderComponent,
    MessageBoxComponent
  ],
  exports: [
    HeaderComponent,
    MessageBoxComponent
  ],
  imports: [
    CommonModule,
    IonicModule,
    EmojiModule,
    PickerModule
  ],
  providers: [
    EmojiService
  ]
})
export class ComponentsModule { }
