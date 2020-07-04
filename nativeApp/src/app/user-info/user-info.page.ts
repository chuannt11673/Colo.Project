import { TranslateConfigService } from './../_core/services/translate-config.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-user-info',
  templateUrl: './user-info.page.html',
  styleUrls: ['./user-info.page.scss'],
})
export class UserInfoPage implements OnInit {
  
  modeTypes = {
    diary: 1,
    album: 2
  }
  mode: number = this.modeTypes.diary;
  constructor(public translateConfigService: TranslateConfigService) { }

  ngOnInit() {
  }

}
