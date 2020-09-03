import { map } from 'rxjs/operators';
import { Injectable } from '@angular/core';
import { HttpService } from '../_core/services/http.service';

@Injectable()
export class ChatService {

  private endpoint = 'api/chat/';
  private getsEndpoint = this.endpoint + 'gets';
  private getChatListEndpoint = this.endpoint + 'getChatList';

  constructor(private httpService: HttpService) { }

  getChatListData: any;

  gets(model: any) {
    return this.httpService.post(this.getsEndpoint, model);
  }

  getChatList() {
    return this.httpService.get(this.getChatListEndpoint).pipe(map(res => {
      this.getChatListData = res;
      return res;
    }));
  }
}
