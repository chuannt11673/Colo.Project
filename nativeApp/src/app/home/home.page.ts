import { Component } from '@angular/core';
import { TranslateConfigService } from '../_core/services/translate-config.service';

@Component({
  selector: 'app-home',
  templateUrl: 'home.page.html',
  styleUrls: ['home.page.scss'],
})
export class HomePage {

  constructor(public translateConfigService: TranslateConfigService) {}

}
