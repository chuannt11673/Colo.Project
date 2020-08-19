import { ModalController } from '@ionic/angular';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-image-review',
  templateUrl: './image-review.component.html',
  styleUrls: ['./image-review.component.scss'],
})
export class ImageReviewComponent implements OnInit {

  base64: string;
  message: string;
  constructor(public modalController: ModalController) { }

  ngOnInit(): void {
    this.base64 = 'data:image/jpeg;base64,' + this.base64;
  }

  send() {
    this.modalController.dismiss({
      message: this.message
    });
  }

  close() {
    this.modalController.dismiss();
  }
}
