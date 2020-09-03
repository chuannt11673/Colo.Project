import { ChatService } from './../../_services/chat.service';
import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { Observable, of } from 'rxjs';

@Injectable()
export class MessageResolver implements Resolve<any> {

    constructor(private chatService: ChatService) {}

    resolve(
        route: ActivatedRouteSnapshot,
        state: RouterStateSnapshot
    ): Observable<any> | Promise<any> | any {
        if (this.chatService.getChatListData)
            return of(this.chatService.getChatListData);

        return this.chatService.getChatList();
    }
}
