import { IonicModule } from '@ionic/angular';
import { FormsModule } from '@angular/forms';
import { ImageReviewComponent } from './image-review.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';



@NgModule({
  declarations: [
    ImageReviewComponent
  ],
  entryComponents: [
    ImageReviewComponent
  ],
  imports: [
    CommonModule,
    IonicModule,
    FormsModule
  ]  
})
export class ImageReviewModule { }
