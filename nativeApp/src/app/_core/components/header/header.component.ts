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

  private subscription: Subscription;
  notifications: any[] = [];

  @Input() enableChatbubble: boolean = false;
  @Input() enableMore: boolean = false;
  @Input() enablePersonAdd: boolean = false;
  @Input() enableNotification: boolean = false;

  constructor(public translateConfigService: TranslateConfigService,
    private navController: NavController,
    private signalRService: SignalRService,
    private localNotifications: LocalNotifications) { }
  
  ngOnInit() {
    this.signalRService.registerSignalEvents('Notification');
    this.subscription = this.signalRService.messageObservable.subscribe(res => {
      this.notifications.push(res);
      this.localNotifications.schedule({
        id: res.id,
        title: '',
        text: 'Someone liked you',
        icon: '/assets/SVG/icons8-heart.svg'
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
    this.subscription.unsubscribe();
  }
}
