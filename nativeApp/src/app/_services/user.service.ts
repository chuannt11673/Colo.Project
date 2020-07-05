import { HttpService } from './../_core/services/http.service';
import { Injectable } from '@angular/core';

@Injectable()
export class UserService {

  private endpoint = 'api/user/';
  private registerEndpoint = this.endpoint + 'register';
  private searchEmailEndpoint = this.endpoint + 'searchEmail';
  constructor(private httpService: HttpService) { }

  register() {
    return this.httpService.get(this.registerEndpoint);
  }

  searchEmail(email: string) {
    return this.httpService.get(`${this.searchEmailEndpoint}/${email}`);
  }
}
