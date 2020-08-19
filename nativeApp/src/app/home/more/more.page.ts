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

  currentUser: any;
  constructor(private authService: AuthService,
    private navController: NavController,
    private logoutActionSheet: LogoutActionSheet,
    private uploadProfileActionSheet: UploadProfileActionSheet,
    private uploadCoverActionSheet: UploadCoverActionSheet) { }

  ngOnInit() {
    this.currentUser = this.authService.getUserProfile();
  }

  userInfo() {
    this.navController.navigateForward(`user-info/${this.currentUser.email}`)
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
