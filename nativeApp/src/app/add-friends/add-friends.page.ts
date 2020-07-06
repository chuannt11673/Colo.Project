import { UserInfoService } from './../_services/user-info.service';
import { UserService } from './../_services/user.service';
import { Component, OnInit } from '@angular/core';
import { TranslateConfigService } from '../_core/services/translate-config.service';
import { AlertController, NavController } from '@ionic/angular';

@Component({
  selector: 'app-add-friends',
  templateUrl: './add-friends.page.html',
  styleUrls: ['./add-friends.page.scss'],
})
export class AddFriendsPage implements OnInit {

  public email: string = '';
  isLoading: boolean = false;
  constructor(public translateConfigService: TranslateConfigService,
    public alertController: AlertController,
    private navController: NavController,
    private userService: UserService) { }

  ngOnInit() {
  }

  search() {
    if (!this.email)
      return;

    this.isLoading = true;
    this.userService.isAnyUserEmail(this.email).subscribe(isAny => {
      this.isLoading = false;
      if (isAny) {
        this.navController.navigateForward(`user-info/${this.email}`);
      }
      else
        this.presentAlert();
    });
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
