import { UserService } from './../_services/user.service';
import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot, RouterStateSnapshot, ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';

@Injectable()
export class UserInfoResolver implements Resolve<any> {

    constructor(private userService: UserService, private route: ActivatedRoute) {}

    resolve(
        route: ActivatedRouteSnapshot,
        state: RouterStateSnapshot
    ): Observable<any> | Promise<any> | any {
        let email = this.route.snapshot.params['email'];
        return this.userService.searchEmail(email);
    }
}
