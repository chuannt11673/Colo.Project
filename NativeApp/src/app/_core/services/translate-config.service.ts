import { LocalstorageService } from './localstorage.service';
import { Injectable } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { take } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class TranslateConfigService {

  private key: string = 'language-code';
  text: any = {};
  constructor(private translateService: TranslateService, private localstorageService: LocalstorageService) {
    this.initial();
  }

  private initial() {
    let languageCode = this.localstorageService.get(this.key);
    let defaultLanguage = 'en';
    if (!languageCode)
      this.translateService.setDefaultLang(defaultLanguage);

    this.setLanguage(languageCode || defaultLanguage);
  }

  setLanguage(languageCode: string) {
    this.translateService.use(languageCode);
    this.localstorageService.set(this.key, languageCode);
    this.setBrowserLanguage(languageCode);
  }

  private setBrowserLanguage(languageCode: string) {
    this.translateService.getTranslation(languageCode).pipe(take(1)).subscribe(res => {
      this.text = res;
    });
  }
}
