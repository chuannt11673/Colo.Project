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
  messages: any[] = [];
  constructor(private el: ElementRef, private route: ActivatedRoute, private authService: AuthService, private signalRService: SignalRService, private userService: UserService) { }
  
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
        this.messages.push(res);
        this.scrollToBottom();
      });
  }

  ngAfterViewInit(): void {
    this.ionContent = this.el.nativeElement.querySelector('ion-content');
  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }

  private getUser() {
    let email = this.route.snapshot.paramMap.get('email');
    this.userService.searchEmail(email).subscribe(user => {
      this.user = user;
    });
  }

  send(event: any) {
    if (!event.message) return;

    this.signalRService.sendUser(this.user.id, event.message).subscribe(_ => {
      this.messages.push({
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
}
