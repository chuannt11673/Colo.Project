import { TranslateConfigService } from './../../_core/services/translate-config.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-diary',
  templateUrl: './diary.page.html',
  styleUrls: ['./diary.page.scss'],
})
export class DiaryPage implements OnInit {

  constructor(public translateConfigService: TranslateConfigService) { }

  ngOnInit() {
  }

}
