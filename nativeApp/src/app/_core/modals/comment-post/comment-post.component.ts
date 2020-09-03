import { Component, OnInit, Input } from '@angular/core';
import { ModalController } from '@ionic/angular';
import { TranslateConfigService } from '../../services/translate-config.service';
import { PostService } from 'src/app/_services/post.service';

@Component({
  selector: 'app-comment-post',
  templateUrl: './comment-post.component.html',
  styleUrls: ['./comment-post.component.scss'],
})
export class CommentPostComponent implements OnInit {

  constructor(public modalController: ModalController,
    public translateConfigService: TranslateConfigService,
    private postService: PostService) { }

  @Input('item') item: any;

  ngOnInit() {
    this.postService.getComments(this.item.id).subscribe(res => {
      this.item.comments = res;
    });
  }

  dismiss() {
    this.modalController.dismiss();
  }

  onSend(event: any) {
    if (!event.message)
      return;

    let model = {
      postId: this.item.id,
      content: event.message
    };

    this.postService.comment(model).subscribe(res => {
      (this.item.comments as any[]).unshift(res);
    });
  }

  like() {
    if (this.item.isLiked)
      return;

    this.postService.like(this.item.id).subscribe(() => {
      this.item.isLiked = true;
    });
  }
}
