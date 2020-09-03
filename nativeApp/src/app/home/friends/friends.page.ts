import { ActivatedRoute } from '@angular/router';
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
  constructor(public route: ActivatedRoute, public translateConfigService: TranslateConfigService, private navController: NavController,
    private userService: UserService) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.friends = data.data;
    });
  }

  navigateToFriendRequests() {
    this.navController.navigateForward('friend-request');
  }

  userInfo(friend: any) {
    this.navController.navigateForward(`user-info/${friend.email}`);
  }

  doRefresh(event: any) {
    setTimeout(() => {
      this.getFriends(() => {
        event.target.complete();
      });
    }, 500);
  }

  private getFriends(callback: Function = null)   {
    this.userService.getFriends().subscribe(friends => {
      this.friends = friends;
      if (callback)
        callback();
    });
  }
}
