import { HttpService } from './../_core/services/http.service';
import { Injectable } from '@angular/core';

@Injectable()
export class UserService {

  private endpoint = 'api/user/';
  private registerEndpoint = this.endpoint + 'register';
  private searchEmailEndpoint = this.endpoint + 'searchEmail';
  private addFriendEndpoint = this.endpoint + 'addFriend';
  private isAnyUserEmailEndpoint = this.endpoint + 'isAnyUserEmail';
  private getFriendRequestsEndpoint = this.endpoint + 'getFriendRequests';
  private getFriendsEndpoint = this.endpoint + 'getFriends';
  private acceptFriendEndpoint = this.endpoint + 'acceptFriend';
  private updateUserProfileImageEndpoint = this.endpoint + 'updateUserProfileImage';
  private updateUserCoverEndpoint = this.endpoint + 'updateUserCover';
  private updateUserInfoEndpoint = this.endpoint + 'updateUserInfo';
  constructor(private httpService: HttpService) { }

  register() {
    return this.httpService.get(this.registerEndpoint);
  }

  searchEmail(email: string) {
    return this.httpService.get(`${this.searchEmailEndpoint}/${email}`);
  }

  addFriend(userId: string) {
    return this.httpService.post(`${this.addFriendEndpoint}/${userId}`, {});
  }

  isAnyUserEmail(email: string) {
    return this.httpService.get(`${this.isAnyUserEmailEndpoint}/${email}`);
  }

  getFriendRequest() {
    return this.httpService.get(this.getFriendRequestsEndpoint);
  }

  getFriends() {
    return this.httpService.get(this.getFriendsEndpoint);
  }

  acceptFriend(userId: string) {
    return this.httpService.get(`${this.acceptFriendEndpoint}/${userId}`);
  }

  updateUserProfileImage(model: any) {
    return this.httpService.post(this.updateUserProfileImageEndpoint, model);
  }

  updateUserCover(model: any) {
    return this.httpService.post(this.updateUserCoverEndpoint, model);
  }

  updateUserInfo(model: any) {
    return this.httpService.post(this.updateUserInfoEndpoint, model);
  }
}
