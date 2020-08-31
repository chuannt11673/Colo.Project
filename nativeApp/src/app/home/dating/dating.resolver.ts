import { UserService } from './../../_services/user.service';
import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { Observable, forkJoin } from 'rxjs';

@Injectable()
export class DatingResolver implements Resolve<any> {

    constructor(private userServicer: UserService) {}

    resolve(
        route: ActivatedRouteSnapshot,
        state: RouterStateSnapshot
    ): Observable<any> | Promise<any> | any {
        let suggestFriends = this.userServicer.suggestFriends();
        let getUserLikes = this.userServicer.getUserLikes();
        return forkJoin({
            suggestFriends: suggestFriends,
            userLikes: getUserLikes
        });
    }
}
