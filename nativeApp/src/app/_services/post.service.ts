import { AuthService } from './../_core/services/auth.service';
import { map } from 'rxjs/operators';
import { HttpService } from './../_core/services/http.service';
import { Injectable } from '@angular/core';

@Injectable()
export class PostService {

  constructor(private httpService: HttpService, private authService: AuthService) {
  }

  private endpoint = 'api/posts/';
  private getEndpoint = this.endpoint + 'gets';
  private createEndpoint = this.endpoint + 'create';
  private likeEndpoint = this.endpoint + 'like';
  private commentEndpoint = this.endpoint + 'comment';
  private getCommentsEndpoint = this.endpoint + 'getComments';
  private getPostsByUserEndpoint = this.endpoint + 'getPostsByUser';

  gets(paginationModel: any) {
    return this.httpService.post(this.getEndpoint, paginationModel).pipe(map(res => {
      res.items.map((item: any) => {
        item.isLiked = (item.likedUsers as any[]).findIndex(x => x.id == this.authService.userProfile.id) != -1;
      });
      return res;
    }));
  }

  create(model: any) {
    return this.httpService.post(this.createEndpoint, model);
  }

  like(postId: string) {
    return this.httpService.get(`${this.likeEndpoint}/${postId}`);
  }

  comment(model: any) {
    return this.httpService.post(this.commentEndpoint, model);
  }

  getComments(postId: string) {
    return this.httpService.get(`${this.getCommentsEndpoint}/${postId}`);
  }

  getPostsByUser(userId: string, paginationModel: any) {
    return this.httpService.post(`${this.getPostsByUserEndpoint}/${userId}`, paginationModel).pipe(map(res => {
      res.items.map((item: any) => {
        item.isLiked = (item.likedUsers as any[]).findIndex(x => x.id == this.authService.userProfile.id) != -1;
      });

      return res;
    }));;
  }
}
