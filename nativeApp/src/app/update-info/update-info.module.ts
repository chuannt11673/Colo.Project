import { AuthService } from './../_core/services/auth.service';
import { UserService } from './../_services/user.service';
import { MaterialsModule } from './../_core/materials/materials.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { UpdateInfoPageRoutingModule } from './update-info-routing.module';

import { UpdateInfoPage } from './update-info.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    UpdateInfoPageRoutingModule,
    ReactiveFormsModule
  ],
  providers: [
    UserService
  ],
  declarations: [UpdateInfoPage]
})
export class UpdateInfoPageModule {}
