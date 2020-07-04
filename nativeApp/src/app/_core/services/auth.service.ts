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

  private manager: UserManager;
  private user: User;

  constructor(private navController: NavController) {
    this.manager = new UserManager(getClientSettings());
  }

  isLoggedIn(): boolean {
    return this.user != null && !this.user.expired;
  }

  getClaims(): any {
    return this.user.profile;
  }

  getAuthorizationHeaderValue(): string {
    return `${this.user.token_type} ${this.user.access_token}`;
  }

  startAuthentication(): Promise<any> {
    return this.manager.signinPopup().then(user => {
      this.user = user;
      this.navController.navigateForward('/home');
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
}
