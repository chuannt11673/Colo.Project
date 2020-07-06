import { UserService } from './../_services/user.service';
import { TranslateConfigService } from './../_core/services/translate-config.service';
import { Component, OnInit } from '@angular/core';
import { AlertController, NavController } from '@ionic/angular';
import { typeWithParameters } from '@angular/compiler/src/render3/util';

@Component({
  selector: 'app-friend-request',
  templateUrl: './friend-request.page.html',
  styleUrls: ['./friend-request.page.scss'],
})
export class FriendRequestPage implements OnInit {

  requests: any[];
  constructor(public translateConfigService: TranslateConfigService, public alertController: AlertController, private navController: NavController,
    private userService: UserService) { }

  ngOnInit() {
    this.userService.getFriendRequest().subscribe(requests => {
      this.requests = requests;
    })
  }
}
