import { ActionSheetController, NavController } from '@ionic/angular';
import { AuthService } from './../../_core/services/auth.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-more',
  templateUrl: './more.page.html',
  styleUrls: ['./more.page.scss'],
})
export class MorePage implements OnInit {

  currentUser: any;
  constructor(private authService: AuthService, private actionSheetController: ActionSheetController, private navController: NavController) { }

  ngOnInit() {
    this.currentUser = this.authService.getUserProfile();
  }

  userInfo() {
    this.navController.navigateForward(`user-info/${this.currentUser.email}`)
  }

  logout() {
    this.presentAlertConfirm();
  }

  async presentAlertConfirm() {
    const actionSheet = await this.actionSheetController.create({
      header: "Log out this account?",
      buttons: [{
        text: 'Log out',
        cssClass: 'danger',
        handler: () => {
          this.authService.signOut();
        }
      },
      {
        text: 'Cancel',
        role: 'cancel'
      }
      ]
    });
    await actionSheet.present();
  }
}
