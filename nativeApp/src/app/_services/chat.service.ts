import { Injectable } from '@angular/core';
import { HttpService } from '../_core/services/http.service';

@Injectable()
export class ChatService {

  private endpoint = 'api/chat/';
  private getsEndpoint = this.endpoint + 'gets';

  constructor(private httpService: HttpService) { }

  gets(model: any) {
    return this.httpService.post(this.getsEndpoint, model);
  }
}
