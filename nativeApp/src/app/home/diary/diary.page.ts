import { TranslateConfigService } from './../../_core/services/translate-config.service';
import { Component, OnInit } from '@angular/core';
import { from } from 'rxjs';
import { mergeMap, switchMap, map, delay, flatMap, concatMap } from 'rxjs/operators';

@Component({
  selector: 'app-diary',
  templateUrl: './diary.page.html',
  styleUrls: ['./diary.page.scss'],
})
export class DiaryPage implements OnInit {

  constructor(public translateConfigService: TranslateConfigService) { }

  ngOnInit() {
    this.switchMapFunc();
  }

  switchMapFunc() {
    let time1 = performance.now();
    let name1 = ['a', 'b'];

    from(name1).pipe(
      switchMap(res => {
        return from([`${res}x`]).pipe(delay(this.randomTime()));
      })
    )
    .subscribe(res => {
      let time2 = performance.now();
      console.log(`result ${res} in ${time2 - time1} miliseconds`);
    });
  }

  randomTime() {
    return Math.floor(Math.random() * 100);
  }
}
