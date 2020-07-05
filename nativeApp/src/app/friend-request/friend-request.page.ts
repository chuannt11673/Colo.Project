import { TranslateConfigService } from './../_core/services/translate-config.service';
import { Component, OnInit } from '@angular/core';
import { AlertController, NavController } from '@ionic/angular';

@Component({
  selector: 'app-friend-request',
  templateUrl: './friend-request.page.html',
  styleUrls: ['./friend-request.page.scss'],
})
export class FriendRequestPage implements OnInit {

  public email: string = '';
  constructor(public translateConfigService: TranslateConfigService, public alertController: AlertController, private navController: NavController) { }

  ngOnInit() {
  }
}
