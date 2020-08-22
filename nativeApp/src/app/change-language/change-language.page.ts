import { TranslateConfigService } from './../_core/services/translate-config.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-change-language',
  templateUrl: './change-language.page.html',
  styleUrls: ['./change-language.page.scss'],
})
export class ChangeLanguagePage implements OnInit {

  language: string;
  constructor(private translateConfigService: TranslateConfigService) { }

  ngOnInit() {
    this.language = this.translateConfigService.getCurrentLanguageCode();
  }

  changeLanguage(code: string) {
    this.translateConfigService.setLanguage(code);
  }

}
