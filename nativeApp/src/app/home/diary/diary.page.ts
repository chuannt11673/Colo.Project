import { ModalController } from '@ionic/angular';
import { AuthService } from './../../_core/services/auth.service';
import { ActivatedRoute } from '@angular/router';
import { TranslateConfigService } from './../../_core/services/translate-config.service';
import { Component, OnInit } from '@angular/core';
import { CreatePostComponent } from 'src/app/_core/modals/create-post/create-post.component';

@Component({
  selector: 'app-diary',
  templateUrl: './diary.page.html',
  styleUrls: ['./diary.page.scss'],
})
export class DiaryPage implements OnInit {

  constructor(public translateConfigService: TranslateConfigService,
    public route: ActivatedRoute,
    public authService: AuthService,
    public modalController: ModalController) { }

  data: any;

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

}
