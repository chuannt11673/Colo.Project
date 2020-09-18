import { SignalRService } from './../../../_services/signal-r.service';
import { NavController } from '@ionic/angular';
import { TranslateConfigService } from './../../services/translate-config.service';
import { Component, Input, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { LocalNotifications } from '@ionic-native/local-notifications/ngx';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit, OnDestroy {

  notifications: any[] = [];

  @Input() enableChatbubble: boolean = false;
  @Input() enableMore: boolean = false;
  @Input() enablePersonAdd: boolean = false;
  @Input() enableNotification: boolean = false;

  constructor(public translateConfigService: TranslateConfigService,
    private navController: NavController,
    private signalRService: SignalRService,
    private localNotifications: LocalNotifications) { }

  private eventName: string = 'Notification';
  
  ngOnInit() {
    this.signalRService.registerSignalEvents(this.eventName, (data) => {
      this.notifications.push(data);
      this.localNotifications.schedule({
        id: data.id,
        title: '',
        text: 'Someone liked you',
        icon: 'https://img.icons8.com/bubbles/50/000000/bookmark.png'
      });
    });
    this.enableMore = false;
  }

  addFriend() {
    this.navController.navigateForward('add-friends');
  }

  notify() {
    this.navController.navigateForward('notification');
  }

  ngOnDestroy(): void {
    this.signalRService.turnOffEvents(this.eventName);
  }
}
