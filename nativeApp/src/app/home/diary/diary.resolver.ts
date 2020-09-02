import { PostService } from './../../_services/post.service';
import { Injectable, Type } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { Observable } from 'rxjs';

@Injectable()
export class DiaryResolver implements Resolve<any> {

    constructor(public postService: PostService) {}

    resolve(
        route: ActivatedRouteSnapshot,
        state: RouterStateSnapshot
    ): Observable<any> | Promise<any> | any {
        let data = this.postService.data;
        
        if (!data)
            return this.postService.gets({ pageIndex: 1, pageSize: 10 });

        return false;
    }
}
