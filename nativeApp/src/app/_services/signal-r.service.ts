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

  private messageSubject: Subject<any> = new Subject();
  messageObservable: Observable<any> = this.messageSubject.asObservable();

  constructor(private authService: AuthService, private httpService: HttpService) {
    this.buildConnection();
    this.startConnection();
    this.registerSignalEvents();
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

  private registerSignalEvents() {
    this.hubConnection.on('SendMessage', (data: any) => {
      this.messageSubject.next(data);
    });
  }

  public sendUser(userId: string, message: string, files: any[]) {
    return this.httpService.post(`${this.sendUserEndpoint}/${userId}`, { message: message, fileModels: files });
  }
}
