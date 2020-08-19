import { ActivatedRoute } from '@angular/router';
import { UserService } from './../_services/user.service';
import { TranslateConfigService } from './../_core/services/translate-config.service';
import { Component, OnInit } from '@angular/core';
import { AlertController, NavController } from '@ionic/angular';

@Component({
  selector: 'app-friend-request',
  templateUrl: './friend-request.page.html',
  styleUrls: ['./friend-request.page.scss'],
})
export class FriendRequestPage implements OnInit {

  requests: any[];
  constructor(public route: ActivatedRoute, public translateConfigService: TranslateConfigService, public alertController: AlertController, private navController: NavController,
    private userService: UserService) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.requests = data.requests;
    });
  }

  accept(userId: string, index: number) {
    this.userService.acceptFriend(userId).subscribe(_ => {
      this.requests.splice(index, 1);
    });
  }
}
