import { ChatService } from './../_services/chat.service';
import { UserService } from './../_services/user.service';
import { SignalRService } from './../_services/signal-r.service';
import { AuthService } from './../_core/services/auth.service';
import { Component, OnInit, OnDestroy, AfterViewInit, ElementRef } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { map } from 'rxjs/operators';

@Component({
  selector: 'app-chat',
  templateUrl: './chat.page.html',
  styleUrls: ['./chat.page.scss']
})
export class ChatPage implements OnInit, OnDestroy, AfterViewInit {

  private subscription: Subscription;
  private ionContent: any;
  currentUser: any;
  user: any;
  chatHistory: any = {
    items: []
  };
  constructor(private el: ElementRef, private route: ActivatedRoute, private authService: AuthService,
    private signalRService: SignalRService, private userService: UserService, private chatService: ChatService) { }
  
  ngOnInit() {
    this.currentUser = this.authService.getUserProfile();
    this.getUser();
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
        this.chatHistory.items.push(res);
        this.scrollToBottom();
      });
  }

  ngAfterViewInit(): void {
    this.ionContent = this.el.nativeElement.querySelector('ion-content');
  }

  private getChatHistory(userId: string) {
    this.chatService.gets({ userId: userId, pageIndex: 1, pageSize: 50 }).subscribe(res => {
      this.chatHistory = {
        ...res,
        items: this.chatHistory.items.concat(this.chatHistory.items, res.items.map(item => this.convertItem(item)))
      };
    });
  }

  private convertItem(item: any) {
    return {
      userEmail: item.fromUserId == this.currentUser.id ? item.fromUserEmail : item.toUserEmail,
      isMyself: item.fromUserId == this.currentUser.id,
      message: item.message,
      time: new Date()
    };
  }
 
  private getUser() {
    let email = this.route.snapshot.paramMap.get('email');
    this.userService.searchEmail(email)
    .pipe(map(res => {
      this.getChatHistory(res.id);
      return res;
    }))
    .subscribe(user => {
      this.user = user;
    });
  }

  send(event: any) {
    if (!event.message) return;

    this.signalRService.sendUser(this.user.id, event.message).subscribe(_ => {
      this.chatHistory.items.push({
        userEmail: this.currentUser.email,
        isMyself: true,
        message: event.message,
        time: new Date()
      });
      this.scrollToBottom();
    });
  }

  private scrollToBottom() {
    setTimeout(() => {
      this.ionContent.scrollToBottom();
    }, 1);
  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }
}
