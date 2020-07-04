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

  search() {
    this.navController.navigateForward('user-info');
  }

  async presentAlert() {
    const alert = await this.alertController.create({
      header: this.translateConfigService.text.friend_request_title,
      message: this.translateConfigService.text.friend_request_notfound,
      buttons: ['OK']
    });

    await alert.present();
  }
}
