import { map } from 'rxjs/operators';
import { NavController } from '@ionic/angular';
import { AuthService } from './../_core/services/auth.service';
import { TranslateConfigService } from './../_core/services/translate-config.service';
import { Component, OnInit } from '@angular/core';
import { UserService } from '../_services/user.service';
import { ActivatedRoute } from '@angular/router';

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

  userState = {
    none: 0,
    requested: 1,
    accepted: 2,
    declined: 3,
    blocked: 4
  }

  mode: number = this.modeTypes.diary;
  user: any;
  isMe: boolean = false;
  constructor(public translateConfigService: TranslateConfigService, private route: ActivatedRoute,
    private userService: UserService,
    private authService: AuthService,
    private navController: NavController) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.user = data.data;
      this.user.isFriend = (this.user.friends as any[]).findIndex(x => x.id == this.authService.userProfile.id) != -1;
      this.isMe = this.authService.userProfile.id == this.user.id;
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

  accept() {
    this.userService.acceptFriend(this.user.id).subscribe(_ => {
      this.user.isFriend = true;
      this.user.friendShip.state = this.userState.accepted;
    });
  }
}
