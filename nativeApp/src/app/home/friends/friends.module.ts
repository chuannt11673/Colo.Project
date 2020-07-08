import { UserService } from './../../_services/user.service';
import { WeatherForecastService } from './../../_services/weather-forecast.service';
import { HeaderComponent } from './../../_core/components/header/header.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { FriendsPageRoutingModule } from './friends-routing.module';

import { FriendsPage } from './friends.page';
import { FriendsResolver } from './friends.resolver';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    FriendsPageRoutingModule
  ],
  declarations: [
    FriendsPage,
    HeaderComponent
  ],
  providers: [
    WeatherForecastService,
    UserService,
    FriendsResolver
  ]
})
export class FriendsPageModule {}
