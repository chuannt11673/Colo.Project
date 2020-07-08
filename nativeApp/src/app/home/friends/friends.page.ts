import { UserService } from './../../_services/user.service';
import { NavController } from '@ionic/angular';
import { TranslateConfigService } from './../../_core/services/translate-config.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-friends',
  templateUrl: './friends.page.html',
  styleUrls: ['./friends.page.scss'],
})
export class FriendsPage implements OnInit {

  friends: any[] = [];
  constructor(public translateConfigService: TranslateConfigService, private navController: NavController,
    private userService: UserService) { }

  ngOnInit() {
  }

  ionViewWillEnter() {
    this.userService.getFriends().subscribe(friends => {
      this.friends = friends;
    });
  }

  navigateToFriendRequests() {
    this.navController.navigateForward('friend-request');
  }

  userInfo(friend: any) {
    console.log('friend', friend);
    this.navController.navigateForward(`user-info/${friend.email}`);
  }
}
