import { map } from 'rxjs/operators';
import { HttpService } from './../_core/services/http.service';
import { Injectable } from '@angular/core';

@Injectable()
export class PostService {

  constructor(private httpService: HttpService) { }

  private endpoint = 'api/posts/';
  private getEndpoint = this.endpoint + 'gets';
  private createEndpoint = this.endpoint + 'create';

  data: any;

  gets(paginationModel: any) {
    return this.httpService.post(this.getEndpoint, paginationModel).pipe(map(res => {
      this.data = res;
      return res;
    }));
  }

  create(model: any) {
    return this.httpService.post(this.createEndpoint, model);
  }
}
