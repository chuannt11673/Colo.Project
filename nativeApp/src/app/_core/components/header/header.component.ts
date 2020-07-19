import { SignalRService } from './../../../_services/signal-r.service';
import { NavController } from '@ionic/angular';
import { TranslateConfigService } from './../../services/translate-config.service';
import { Component, OnInit, Input, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnDestroy {

  private subscription: Subscription;
  notifications: any[] = [];

  @Input() enableChatbubble: boolean = false;
  @Input() enableAdd: boolean = false;
  @Input() enablePersonAdd: boolean = false;  

  constructor(public translateConfigService: TranslateConfigService, private navController: NavController, private signalRService: SignalRService) { }
  
  ngOnInit() {
    this.subscription = this.signalRService.messageObservable.subscribe(res => {
      this.notifications.push(res);
    });
  }

  addFriend() {
    this.navController.navigateForward('add-friends');
  }

  notify() {

  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }
}
