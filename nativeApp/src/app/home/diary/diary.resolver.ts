import { PostService } from './../../_services/post.service';
import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { Observable } from 'rxjs';

@Injectable()
export class DiaryResolver implements Resolve<any> {

    constructor(public postService: PostService) {}

    resolve(
        route: ActivatedRouteSnapshot,
        state: RouterStateSnapshot
    ): Observable<any> | Promise<any> | any {
        return this.postService.gets({ pageIndex: 1, pageSize: 10 });
    }
}
