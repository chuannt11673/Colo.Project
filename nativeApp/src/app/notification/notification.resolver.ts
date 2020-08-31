import { SignalRService } from './../_services/signal-r.service';
import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { Observable } from 'rxjs';

@Injectable()
export class NotificationResolver implements Resolve<any> {

    constructor(private signalRService: SignalRService) {}

    resolve(
        route: ActivatedRouteSnapshot,
        state: RouterStateSnapshot
    ): Observable<any> | Promise<any> | any {
        return this.signalRService.getNotification();
    }
}
