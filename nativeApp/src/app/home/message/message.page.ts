import { ActivatedRoute } from '@angular/router';
import { NavController } from '@ionic/angular';
import { ChatService } from './../../_services/chat.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-message',
  templateUrl: './message.page.html',
  styleUrls: ['./message.page.scss'],
})
export class MessagePage implements OnInit {

  messages: any[] = [];
  constructor(private route: ActivatedRoute, private chatService: ChatService, private navController: NavController) { }

  ngOnInit() {
    this.chatService.getChatList().subscribe(res => {
      this.messages = res;
    });
  }

  chat(email: string) {
    this.navController.navigateForward(`chat/${email}`);
  }

  doRefresh(event: any) {
    setTimeout(() => {
      this.getMessages(() => {
        event.target.complete();
      });
    }, 500);
  }

  private getMessages(callback: Function = null) {
    this.chatService.getChatList().subscribe((result: any[]) => {
      this.messages = result;

      if (callback)
        callback();
    });
  }
}
