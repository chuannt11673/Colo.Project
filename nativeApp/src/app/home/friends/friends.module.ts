import { PipesModule } from './../../_core/pipes/pipes.module';
import { ComponentsModule } from './../../_core/components/components.module';
import { UserService } from './../../_services/user.service';
import { WeatherForecastService } from './../../_services/weather-forecast.service';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { FriendsPageRoutingModule } from './friends-routing.module';

import { FriendsPage } from './friends.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    FriendsPageRoutingModule,
    ComponentsModule,
    PipesModule
  ],
  declarations: [
    FriendsPage
  ],
  providers: [
    WeatherForecastService,
    UserService
  ]
})
export class FriendsPageModule {}
