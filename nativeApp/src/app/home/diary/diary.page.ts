import { PostService } from './../../_services/post.service';
import { ModalController, IonInfiniteScroll } from '@ionic/angular';
import { AuthService } from './../../_core/services/auth.service';
import { ActivatedRoute } from '@angular/router';
import { TranslateConfigService } from './../../_core/services/translate-config.service';
import { Component, OnInit, ViewChild } from '@angular/core';
import { CreatePostComponent } from 'src/app/_core/modals/create-post/create-post.component';
import { CommentPostComponent } from 'src/app/_core/modals/comment-post/comment-post.component';

@Component({
  selector: 'app-diary',
  templateUrl: './diary.page.html',
  styleUrls: ['./diary.page.scss'],
})
export class DiaryPage implements OnInit {

  constructor(public translateConfigService: TranslateConfigService,
    public route: ActivatedRoute,
    public authService: AuthService,
    public modalController: ModalController,
    public postService: PostService) { }

  data: any = {};
  pageSize: number = 10;
  pageIndex: number = 1;

  @ViewChild('infiniteScroll') infiniteScroll: IonInfiniteScroll;

  ngOnInit() {
    this.route.data.subscribe(data => {
        this.data = data.data;
    });
  }

  async createPost() {
    const modal = this.modalController.create({
      component: CreatePostComponent
    });

    (await modal).present();
    (await modal).onWillDismiss().then(data => {
      if (data.data) {
        (this.data.items as any[]).unshift(data.data);
      }
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

  like(item: any) {
    if (item.isLiked)
      return;

    this.postService.like(item.id).subscribe(() => {
      item.likedUsers.push(this.authService.userProfile);
      item.isLiked = true;
    });
  }

  getData(callback: Function) {
    this.postService.gets({ pageSize: this.pageSize, pageIndex: this.pageIndex }).subscribe(data => {
      this.data = {
        ...data,
        items: this.data.items.concat(data.items)
      };
      callback();
    });
  }

  doRefresh(event: any) {
    setTimeout(() => {
      this.pageIndex = 1;
      this.data.items = [];

      this.getData(() => {
        event.target.complete();
        if (this.data.hasNextPage)
          this.infiniteScroll.disabled = false;
      })
    }, 500);
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
}
