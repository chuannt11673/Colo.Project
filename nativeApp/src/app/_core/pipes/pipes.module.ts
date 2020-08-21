import { SafeHtmlPipe } from './safe-html.pipe';
import { NgModule } from '@angular/core';
import { ImageFormater } from './image-formater.pipe';



@NgModule({
  declarations: [
    SafeHtmlPipe,
    ImageFormater
  ],
  exports: [
    SafeHtmlPipe,
    ImageFormater
  ]
})
export class PipesModule {
}
