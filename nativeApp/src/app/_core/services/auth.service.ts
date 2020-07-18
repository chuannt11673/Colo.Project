import { HttpService } from './http.service';
import { Injectable } from '@angular/core';
import { UserManager, UserManagerSettings, User } from 'oidc-client';
import { NavController } from '@ionic/angular';
import { clientSetting } from 'src/environments/environment';

export function getClientSettings(): UserManagerSettings {
  return clientSetting;
}

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private claimTypes = {
    email: 'http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress',
    id: 'http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier'
  }
  private manager: UserManager;
  private user: User;

  constructor(private navController: NavController, private httpService: HttpService) {
    this.manager = new UserManager(getClientSettings());
  }

  initUser() {
    return this.manager.getUser().then(user => {
      this.user = user;
    });
  }

  isLoggedIn(): boolean {
    return this.user != null && !this.user.expired;
  }

  getClaims(): any {
    return this.user.profile;
  }

  getUserProfile(): any {
    return {
      email: this.user.profile[this.claimTypes.email],
      id: this.user.profile[this.claimTypes.id]
    };
  }

  getAccessToken() {
    return this.user.access_token;
  }

  getAuthorizationHeaderValue(): string {
    return `${this.user.token_type} ${this.user.access_token}`;
  }

  startAuthentication(): Promise<any> {
    return this.manager.signinPopup().then(user => {
      this.user = user;
      this.createUser((_: any) => {
        this.navController.navigateForward('/home');
      })
    }).catch(() => { });
  }

  completeAuthentication(): Promise<void> {
    return this.manager.signinPopupCallback().then(() => { }).catch(() => { });
  }

  signOut() {
    this.manager.signoutPopup().then(() => {
      this.navController.navigateForward('')
    })
  }

  completeSignOut() {
    this.manager.signoutPopupCallback().then(() => { }).catch(() => { });
  }

  private createUser(callback: Function) {
    let model = {
      email: null,
      firstName: null,
      lastName: null,
      gender: 1,
      birthDay: new Date(),
      address: null
    };
    this.httpService.post('api/user/register', model).subscribe(res => {
      this.user.profile.birthdate = res.birthday;
      this.user.profile.gender = res.gender
      callback();
    });
  }
}
