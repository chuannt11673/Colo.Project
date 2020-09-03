import { PostService } from './../../_services/post.service';
import { Injectable, Type } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { Observable, of } from 'rxjs';

@Injectable()
export class DiaryResolver implements Resolve<any> {

    constructor(public postService: PostService) {}

    resolve(
        route: ActivatedRouteSnapshot,
        state: RouterStateSnapshot
    ): Observable<any> | Promise<any> | any {
        if (this.postService.getsData)
            return of(this.postService.getsData);
        
        return this.postService.gets({ pageIndex: 1, pageSize: 10 });
    }
}
