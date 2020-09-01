import { HttpService } from './../_core/services/http.service';
import { Injectable } from '@angular/core';

@Injectable()
export class PostService {

  constructor(private httpService: HttpService) { }

  private endpoint = 'api/posts/';
  private getEndpoint = this.endpoint + 'gets';
  private createEndpoint = this.endpoint + 'create';

  gets(paginationModel: any) {
    return this.httpService.post(this.getEndpoint, paginationModel);
  }

  create(model: any) {
    return this.httpService.post(this.createEndpoint, model);
  }
}
