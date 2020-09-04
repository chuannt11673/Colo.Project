import { SignalRService } from './../../_services/signal-r.service';
import { PipesModule } from './../../_core/pipes/pipes.module';
import { UserService } from './../../_services/user.service';
import { ComponentsModule } from 'src/app/_core/components/components.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { DatingPageRoutingModule } from './dating-routing.module';

import { DatingPage } from './dating.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    DatingPageRoutingModule,
    ComponentsModule,
    PipesModule
  ],
  providers: [
    UserService,
    SignalRService
  ],
  declarations: [DatingPage]
})
export class DatingPageModule {}
