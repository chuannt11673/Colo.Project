import { AuthService } from './../_core/services/auth.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-chat',
  templateUrl: './chat.page.html',
  styleUrls: ['./chat.page.scss'],
})
export class ChatPage implements OnInit {

  currentUser: any;
  messages: any[] = [];
  constructor(private authService: AuthService) { }

  ngOnInit() {
    this.currentUser = this.authService.getUserProfile();
  }

}
