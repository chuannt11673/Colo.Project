import { UserService } from './../../_services/user.service';
import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { Observable, forkJoin, of } from 'rxjs';

@Injectable()
export class DatingResolver implements Resolve<any> {

    constructor(private userService: UserService) {}

    resolve(
        route: ActivatedRouteSnapshot,
        state: RouterStateSnapshot
    ): Observable<any> | Promise<any> | any {
        if (this.userService.suggestFriendsData && this.userService.getUserLikesData)
            return of({
                suggestFriends: this.userService.suggestFriendsData,
                userLikes: this.userService.getUserLikesData
            });

        let suggestFriends = this.userService.suggestFriends({ pageIndex: 1, pageSize: 10 });
        let getUserLikes = this.userService.getUserLikes();
        return forkJoin({
            suggestFriends: suggestFriends,
            userLikes: getUserLikes
        });
    }
}
