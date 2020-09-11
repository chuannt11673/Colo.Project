import { map } from 'rxjs/operators';
import { SignalRService } from './../../_services/signal-r.service';
import { AuthService } from './../../_core/services/auth.service';
import { ActivatedRoute } from '@angular/router';
import { NavController, IonInfiniteScroll } from '@ionic/angular';
import { UserService } from './../../_services/user.service';
import { Component, OnInit, ViewChild, OnDestroy } from '@angular/core';
import { forkJoin } from 'rxjs';

@Component({
  selector: 'app-dating',
  templateUrl: './dating.page.html',
  styleUrls: ['./dating.page.scss'],
})
export class DatingPage implements OnInit {

  data: any = {};
  userLikes: any[];
  constructor(public route: ActivatedRoute,
    public authService: AuthService,
    private signalRService: SignalRService,
    private userService: UserService,
    private navController: NavController) { }

  @ViewChild('infiniteScroll') infiniteScroll: IonInfiniteScroll;
  pageIndex: number = 1;
  pageSize: number = 10;

  ngOnInit() {
    let suggestFriends = this.userService.suggestFriends({ pageIndex: 1, pageSize: 10 });
    let getUserLikes = this.userService.getUserLikes();

    forkJoin({
      suggestFriends: suggestFriends,
      userLikes: getUserLikes
    }).subscribe(res => {
      this.userLikes = res.userLikes;
      this.data = {
        ...res.suggestFriends,
        items: res.suggestFriends.items.map((res: any) => {
          return {
            ...res,
            isLiked: this.userLikes.findIndex(x => x.receiverId == res.id) != -1
          }
        })
      };
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

  getData(callback: Function) {
    this.userService.suggestFriends({ pageSize: this.pageSize, pageIndex: this.pageIndex }).subscribe(data => {
      let items = data.items.map(res => {
        return {
          ...res,
          isLiked: this.userLikes.findIndex(x => x.receiverId == res.id) != -1
        }
      });

      this.data = {
        ...data,
        items: this.data.items.concat(items)
      };

      callback();
    });
  }

  loadData(event: any) {
    setTimeout(() => {
      this.pageIndex += 1;

      this.getData(() => {
        event.target.complete();
        if (!this.data.hasNextPage)
          event.target.disabled = true;
      });
    }, 500);
  }
  
  doRefresh(event: any) {
    setTimeout(() => {
      this.pageIndex = 1;
      this.data.items = [];
      this.getData(() => {
        event.target.complete();
      });
    }, 500);
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
