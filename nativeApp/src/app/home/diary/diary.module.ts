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
    ComponentsModule
  ],
  providers: [
  ],
  declarations: [DiaryPage]
})
export class DiaryPageModule {}
