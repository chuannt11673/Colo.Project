import { NavController } from '@ionic/angular';
import { TranslateConfigService } from './../../_core/services/translate-config.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-friends',
  templateUrl: './friends.page.html',
  styleUrls: ['./friends.page.scss'],
})
export class FriendsPage implements OnInit {

  constructor(public translateConfigService: TranslateConfigService, private navController: NavController) { }

  ngOnInit() {
  }

  navigateToFriendRequests() {
    this.navController.navigateForward('friend-request');
  }
}
