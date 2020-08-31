import { SignalRService } from './../../_services/signal-r.service';
import { AuthService } from './../../_core/services/auth.service';
import { ActivatedRoute } from '@angular/router';
import { NavController } from '@ionic/angular';
import { UserService } from './../../_services/user.service';
import { Component, OnInit } from '@angular/core';
import { forkJoin } from 'rxjs';

@Component({
  selector: 'app-dating',
  templateUrl: './dating.page.html',
  styleUrls: ['./dating.page.scss'],
})
export class DatingPage implements OnInit {

  users: any[];
  userLikes: any[];
  constructor(public route: ActivatedRoute,
    public authService: AuthService,
    private signalRService: SignalRService,
    private userService: UserService,
    private navController: NavController) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.userLikes = data.data.userLikes;
      this.users = data.data.suggestFriends.map((res: any) => {
        return {
          ...res,
          isLiked: this.userLikes.findIndex(x => x.receiverId == res.id) != -1
        }
      });
    });
  }

  userInfo(user: any) {
    this.navController.navigateForward(`user-info/${user.email}`);
  }

  chat(user: any) {
    this.navController.navigateForward(`chat/${user.email}`);
  }

  like(user: any) {
    let likeUser = this.userService.likeUser(user.id);
    let sendNotification = this.signalRService.sendNotification(this.buildLikeUserModel(user));
    forkJoin(likeUser, sendNotification).subscribe(_ => {
      user.isLiked = true;
    })
  }

  private buildLikeUserModel(user: any) {
    let userProfile = this.authService.userProfile;
    return {
      message: `<span style="color:#3880ff;" userId="${userProfile.id}" userEmail="${userProfile.email}">${userProfile.name}</span> liked you`,
      type: 2,
      forAllUser: false,
      userId: user.id
    };
  }
}
