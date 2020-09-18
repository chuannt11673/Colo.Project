import { AuthService } from './../../_core/services/auth.service';
import { Subscription } from 'rxjs';
import { SignalRService } from './../../_services/signal-r.service';
import { ActivatedRoute } from '@angular/router';
import { NavController } from '@ionic/angular';
import { ChatService } from './../../_services/chat.service';
import { Component, OnInit, OnDestroy } from '@angular/core';
import { map } from 'rxjs/operators';

@Component({
  selector: 'app-message',
  templateUrl: './message.page.html',
  styleUrls: ['./message.page.scss'],
})
export class MessagePage implements OnInit, OnDestroy {

  messages: any[] = [];
  constructor(private route: ActivatedRoute, private chatService: ChatService,
    private authService: AuthService,
    private navController: NavController,
    private signalRService: SignalRService) { }
 
  private subscription: Subscription;
  private eventName: string = 'Message';
  currentUser: any;

  ngOnInit() {
    this.currentUser = this.authService.getUserProfile();

    this.chatService.getChatList().subscribe(res => {
      this.messages = res;
    });

    this.signalRService.registerSignalEvents(this.eventName);
    this.subscription = this.signalRService.messageObservable
      .pipe(map(res => {
        let obj = JSON.parse(res);
        return {
          userEmail: obj.UserEmail,
          isMyself: obj.UserEmail == this.currentUser.email,
          message: obj.Message,
          time: new Date()
        };
      }))
      .subscribe(res => {
        let message = this.messages.find(x => x.userEmail == res.userEmail);
        if (message) {
          message.message = res.message;
        }
        else {
          this.messages.push(res);
        }
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

  ngOnDestroy(): void {
    this.signalRService.turnOffEvents(this.eventName);
    this.subscription.unsubscribe();
  }
}
