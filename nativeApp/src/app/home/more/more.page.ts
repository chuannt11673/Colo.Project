import { TranslateConfigService } from './../../_core/services/translate-config.service';
import { LogoutActionSheet, UploadProfileActionSheet, UploadCoverActionSheet } from '../../_interface/action-sheet.template';
import { NavController } from '@ionic/angular';
import { AuthService } from './../../_core/services/auth.service';
import { Component, OnInit } from '@angular/core';
import { ActionSheetTemplate } from 'src/app/_interface/action-sheet.template';

@Component({
  selector: 'app-more',
  templateUrl: './more.page.html',
  styleUrls: ['./more.page.scss'],
})
export class MorePage implements OnInit {

  constructor(public authService: AuthService,
    private navController: NavController,
    private logoutActionSheet: LogoutActionSheet,
    private uploadProfileActionSheet: UploadProfileActionSheet,
    private uploadCoverActionSheet: UploadCoverActionSheet,
    public translateConfigService: TranslateConfigService) { }

  ngOnInit() {
  }

  userInfo() {
    this.navController.navigateForward(`user-info/${this.authService.userProfile.email}`)
  }

  changeLanguage() {
    this.navController.navigateForward('change-language');
  }

  updateInfo() {
    this.navController.navigateForward('update-info');
  }

  logout() {
    this.presentAlertConfirm(this.logoutActionSheet);
  }

  updateProfilePicture() {
    this.presentAlertConfirm(this.uploadProfileActionSheet);
  }

  updateCover() {
    this.presentAlertConfirm(this.uploadCoverActionSheet);
  }

  async presentAlertConfirm(actionSheetTemplate: ActionSheetTemplate) {
    await actionSheetTemplate.presentAsync();
  }
}
