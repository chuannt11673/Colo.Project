import { Subject, Observable, of } from 'rxjs';
import { HttpService } from './../_core/services/http.service';
import { AuthService } from './../_core/services/auth.service';
import { Injectable } from '@angular/core';
import * as signalR from '@aspnet/signalr';
import { httpEndpoint } from 'src/environments/environment';

@Injectable()
export class SignalRService {
  private hubConnection: signalR.HubConnection;
  private endpoint = 'api/signalR';
  private sendUserEndpoint = this.endpoint + '/sendUser';
  private sendNotificationEndpoint = this.endpoint + '/sendNotification';
  private getNotificationsEndpoint = this.endpoint + '/getNotifications';

  constructor(private authService: AuthService, private httpService: HttpService) {
    this.buildConnection();
    this.startConnection();
  }

  registerSignalEvents(eventName: string, callback: Function) {
    this.hubConnection.on(eventName, (data: any) => {
      callback(data);
    });
  }

  turnOffEvents(eventName: string) {
    this.hubConnection.off(eventName);
  }

  sendUser(userId: string, message: string, files: any[]) {
    return this.httpService.post(`${this.sendUserEndpoint}/${userId}`, { message: message, fileModels: files });
  }

  sendNotification(model: any) {
    return this.httpService.post(this.sendNotificationEndpoint, model);
  }

  getNotification() {
    return this.httpService.get(this.getNotificationsEndpoint);
  }
  
  private buildConnection = () => {
    this.hubConnection = new signalR.HubConnectionBuilder()
      .withUrl(`${httpEndpoint}chatHub`, { accessTokenFactory: () => this.authService.getAccessToken() })
      .build();
  }

  private startConnection = () => {
    if (this.hubConnection.state == signalR.HubConnectionState.Connected)
      return;

    this.hubConnection.start().then((res: any) => {
    }).catch(err => {
      setTimeout(() => {
        this.startConnection();
      }, 2000);
      throw err;
    })
  }
}
