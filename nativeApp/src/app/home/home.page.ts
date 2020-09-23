import { Component, OnInit } from '@angular/core';
import { TranslateConfigService } from '../_core/services/translate-config.service';
import { LocalNotifications } from '@ionic-native/local-notifications/ngx';

@Component({
  selector: 'app-home',
  templateUrl: 'home.page.html',
  styleUrls: ['home.page.scss'],
})
export class HomePage implements OnInit {

  constructor(public translateConfigService: TranslateConfigService,
    private localNotifications: LocalNotifications) { }

  ngOnInit(): void {
  }

  notify() {
    this.localNotifications.schedule({
      id: 1,
      title: 'Notification',
      text: `Let's start discovering Colo App!`,
      smallIcon: 'res://ic_action_remove',
      icon: 'res://icon'
    });
  }
}
