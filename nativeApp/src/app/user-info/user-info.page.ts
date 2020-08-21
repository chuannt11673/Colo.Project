import { NavController } from '@ionic/angular';
import { AuthService } from './../_core/services/auth.service';
import { TranslateConfigService } from './../_core/services/translate-config.service';
import { Component, OnInit } from '@angular/core';
import { UserService } from '../_services/user.service';
import { ActivatedRoute } from '@angular/router';
import { User } from 'oidc-client';

@Component({
  selector: 'app-user-info',
  templateUrl: './user-info.page.html',
  styleUrls: ['./user-info.page.scss'],
})
export class UserInfoPage implements OnInit {
  
  modeTypes = {
    diary: 1,
    album: 2
  }
  mode: number = this.modeTypes.diary;
  user: any;
  loggedInUser: any;
  constructor(public translateConfigService: TranslateConfigService, private route: ActivatedRoute,
    private userService: UserService,
    private authService: AuthService,
    private navController: NavController) { }

  ngOnInit() {
    this.loggedInUser = this.authService.getUserProfile();
    this.route.data.subscribe(data => {
      this.user = data.userInfo;
    });
  }

  addFriend() {
    this.userService.addFriend(this.user.id).subscribe(_ => {
      this.user.isFriend = true;
    });
  }

  chat() {
    this.navController.navigateForward(`chat/${this.user.email}`);
  }
}
