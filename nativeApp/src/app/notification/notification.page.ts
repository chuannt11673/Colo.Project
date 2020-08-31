import { NavController } from '@ionic/angular';
import { ActivatedRoute } from '@angular/router';
import { TranslateConfigService } from './../_core/services/translate-config.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-notification',
  templateUrl: './notification.page.html',
  styleUrls: ['./notification.page.scss'],
})
export class NotificationPage implements OnInit {

  notifications: any[];
  constructor(public translateConfigService: TranslateConfigService,
    public route: ActivatedRoute,
    public navController: NavController) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.notifications = data.data;
      });
  }

  onClick(notification: any) {
    let email = this.getUserEmail(notification.message);
    
    if (email)
      this.navController.navigateForward(`user-info/${email}`);
  }

  private getUserEmail(text: string) {

    let match = text.match(/[a-zA-z0-9.]+@[a-zA-Z0-9.]+/g);
    
    if (match && match.length > 0)
      return match[0];
    
    return null;
  }
}
