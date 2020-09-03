import { UserService } from './../../_services/user.service';
import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { Observable, of } from 'rxjs';

@Injectable()
export class FriendsResolver implements Resolve<any> {

    constructor(private userService: UserService) {}

    resolve(
        route: ActivatedRouteSnapshot,
        state: RouterStateSnapshot
    ): Observable<any> | Promise<any> | any {
        if (this.userService.getFriendsData)
            return of(this.userService.getFriendsData);

        return this.userService.getFriends();
    }
}
