import { NavController } from '@ionic/angular';
import { map } from 'rxjs/operators';
import { ChatService } from './../../_services/chat.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-message',
  templateUrl: './message.page.html',
  styleUrls: ['./message.page.scss'],
})
export class MessagePage implements OnInit {

  messages: any[] = [];
  constructor(private chatService: ChatService, private navController: NavController) { }

  ngOnInit() {
    this.getMessages();
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
    this.chatService.getChatList()
    .pipe(map((res: any[]) => {
      res.forEach((element: any) => {
        element.message = element.message ?? '';
      });
      return res;
    }))
    .subscribe((result: any[]) => {
      this.messages = result;
      if (callback)
        callback();
    });
  }
}
