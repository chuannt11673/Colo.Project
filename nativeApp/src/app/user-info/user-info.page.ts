import { PostService } from 'src/app/_services/post.service';
import { map } from 'rxjs/operators';
import { NavController, ModalController } from '@ionic/angular';
import { AuthService } from './../_core/services/auth.service';
import { TranslateConfigService } from './../_core/services/translate-config.service';
import { Component, OnInit } from '@angular/core';
import { UserService } from '../_services/user.service';
import { ActivatedRoute } from '@angular/router';
import { CommentPostComponent } from '../_core/modals/comment-post/comment-post.component';

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
  constructor(public translateConfigService: TranslateConfigService,
    public modalController: ModalController,
    private route: ActivatedRoute,
    private userService: UserService,
    private authService: AuthService,
    private postService: PostService,
    private navController: NavController) { }

  pageIndex: number = 1;
  pageSize: number = 10;
  postsData: any = {};

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.user = data.data;
      this.user.isFriend = (this.user.friends as any[]).findIndex(x => x.id == this.authService.userProfile.id) != -1;
      this.isMe = this.authService.userProfile.id == this.user.id;

      this.postService.getPostsByUser(this.user.id, { pageIndex: this.pageIndex, pageSize: this.pageSize }).subscribe(res => {
        this.postsData = res;
      });
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
  
  async commentPost(item: any) {
    const modal = this.modalController.create({
      component: CommentPostComponent,
      componentProps: {
        item: item
      }
    });

    (await modal).present();
    (await modal).onWillDismiss().then(data => {
    });
  }
  
  getData(callback: Function) {
    this.postService.gets({ pageSize: this.pageSize, pageIndex: this.pageIndex }).subscribe(data => {
      this.postsData = {
        ...data,
        items: this.postsData.items.concat(data.items)
      };
      callback();
    });
  }
  
  loadData(event: any) {
    setTimeout(() => {
      this.pageIndex += 1;

      this.getData(() => {
        event.target.complete();
        if (!this.postsData.hasNextPage)
          event.target.disabled = true;
      });
    }, 500);
  }

  
  like(item: any) {
    if (item.isLiked)
      return;

    this.postService.like(item.id).subscribe(() => {
      item.likedUsers.push(this.authService.userProfile);
      item.isLiked = true;
    });
  }
}
