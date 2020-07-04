import { NavController } from '@ionic/angular';
import { TranslateConfigService } from './../../services/translate-config.service';
import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss'],
})
export class HeaderComponent implements OnInit {

  @Input() enableChatbubble: boolean = false;
  @Input() enableAdd: boolean = false;
  @Input() enablePersonAdd: boolean = false;
  constructor(public translateConfigService: TranslateConfigService, private navController: NavController) { }

  ngOnInit() {}

  addFriend() {
    this.navController.navigateForward('friend-request');
  }

}
