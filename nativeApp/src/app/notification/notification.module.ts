import { PipesModule } from './../_core/pipes/pipes.module';
import { NotificationResolver } from './notification.resolver';
import { SignalRService } from './../_services/signal-r.service';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { NotificationPageRoutingModule } from './notification-routing.module';

import { NotificationPage } from './notification.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    NotificationPageRoutingModule,
    PipesModule
  ],
  providers: [
    SignalRService,
    NotificationResolver
  ],
  declarations: [NotificationPage]
})
export class NotificationPageModule {}
