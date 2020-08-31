import { httpEndpoint } from 'src/environments/environment';
import { AlertController, IonicSafeString, NavController, ModalController } from '@ionic/angular';
import { FileService } from './../_services/file.service';
import { ChatService } from './../_services/chat.service';
import { UserService } from './../_services/user.service';
import { SignalRService } from './../_services/signal-r.service';
import { AuthService } from './../_core/services/auth.service';
import { Component, OnInit, OnDestroy, AfterViewInit, ElementRef } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { map } from 'rxjs/operators';
import { DatePipe } from '@angular/common';
import { ImageReviewComponent } from '../_core/modals/image-review/image-review.component';

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
    pageIndex: 1,
    hasNextPage: true,
    hasPreviousPage: false,
    items: []
  };
  constructor(private el: ElementRef, private route: ActivatedRoute, private authService: AuthService,
    private signalRService: SignalRService,
    private userService: UserService,
    private chatService: ChatService,
    private fileService: FileService,
    private datePipe: DatePipe,
    private modalController: ModalController,
    private navController: NavController) { }
  
  ngOnInit() {
    this.currentUser = this.authService.getUserProfile();
    this.getUser();

    this.signalRService.registerSignalEvents('Message');
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

  private getChatHistory(userId: string, callback: Function = null) {
    this.chatService.gets({ userId: userId, pageIndex: this.chatHistory.pageIndex, pageSize: 10 }).subscribe(res => {
      this.chatHistory = {
        ...res,
        items: res.items.map(item => this.convertItem(item)).reverse().concat(this.chatHistory.items)
      };
      if (callback)
        callback();
    });
  }

  private convertItem(item: any) {
    return {
      userEmail: item.fromUserEmail,
      isMyself: item.fromUserId == this.currentUser.id,
      hasImage: item.fileModels.length > 0,
      message: this.getMessage(item)
    };
  }

  private getMessage(item: any) {
    return this.getImages(item.fileModels) + item.message + `<br /><div style="font-size: 13px;color:rgba(0, 0, 0, 0.5)">${this.datePipe.transform(item.createdDateTime, 'short')}</div>`;
  }

  private getImages(fileModels: any[]) {
    var res = '';
    fileModels.forEach(file => {
      res += `<img src="${httpEndpoint}${file.url}">`;
    });

    return res;
  }
 
  private getUser() {
    let email = this.route.snapshot.paramMap.get('email');
    let kidahaIndex = this.getRandomArbitrary(2, 12);
    this.userService.searchEmail(email)
    .pipe(map(res => {
      this.getChatHistory(res.id, () => this.scrollToBottom());
      return res;
    }))
    .subscribe(user => {
      this.user = {
        ...user,
        avatar: `/assets/SVG/kidaha-${kidahaIndex}.svg`
      };
    });
  }

  send(event: any, files: any[] = []) {
    if (!event.message) return;

    this.signalRService.sendUser(this.user.id, event.message, files).subscribe(_ => {
      this.chatHistory.items.push({
        userEmail: this.currentUser.email,
        isMyself: true,
        message: this.getMessage({
          message: event.message,
          fileModels: files,
          createdDateTime: new Date()
        }),
        time: new Date()
      });
      this.scrollToBottom();
    });
  }

  userInfo() {
    this.navController.navigateForward(`user-info/${this.user.email}`);
  }

  doRefresh(event: any) {
    setTimeout(() => {
      if (!this.chatHistory.hasNextPage) {
        event.target.complete();
        return;
      }
      this.chatHistory.pageIndex += 1;
      this.getChatHistory(this.user.id, () => {
        event.target.complete();
      });
    }, 500);
  }

  async onSelectImage(base64: string) {

    const modal = await this.modalController.create({
      component: ImageReviewComponent,
      componentProps: {
        'base64': base64
      }
    });

    await modal.present();

    const { data } = await modal.onWillDismiss();
    if (data) {
      this.uploadPicture(data.message, base64);
    }
  }

  private getRandomArbitrary(min: number, max: number) {
    min = Math.ceil(min);
    max = Math.floor(max);
    let res = Math.floor(Math.random() * (max - min + 1)) + min;

    return res.toString().length > 1 ? res : `0${res}`;
  }
  
  private scrollToBottom() {
    setTimeout(() => {
      this.ionContent.scrollToBottom();
    }, 1);
  }

  private uploadPicture(message:string, base64: string) {
    this.fileService.uploadMultiple([{ base64: base64 }]).subscribe(res => {
      this.send({ message: message }, res);
    });
  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }
}
