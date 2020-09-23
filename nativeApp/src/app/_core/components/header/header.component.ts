import { SignalRService } from './../../../_services/signal-r.service';
import { NavController } from '@ionic/angular';
import { TranslateConfigService } from './../../services/translate-config.service';
import { Component, Input, OnDestroy, OnInit } from '@angular/core';
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
    this.signalRService.registerSignalEvents(this.eventName, (data: any) => {
      this.notifications.push(data);
      this.localNotifications.schedule({
        id: data.id,
        title: 'Notification',
        text: `You received a like!`,
        smallIcon: 'res://ic_action_remove',
        icon: 'res://icon'
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
