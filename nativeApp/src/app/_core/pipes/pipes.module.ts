import { SafeHtmlPipe } from './safe-html.pipe';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';



@NgModule({
  declarations: [SafeHtmlPipe],
  exports: [SafeHtmlPipe]
})
export class PipesModule {
}
