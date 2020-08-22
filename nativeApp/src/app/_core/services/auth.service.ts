import { LocalstorageService } from './localstorage.service';
import { map, concatMap } from 'rxjs/operators';
import { Observable, from } from 'rxjs';
import { HttpService } from './http.service';
import { Injectable } from '@angular/core';
import { UserManager, User, Profile } from 'oidc-client';
import { NavController } from '@ionic/angular';
import { clientSetting } from 'src/environments/environment';

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
  
  userProfile: Profile;

  clientSetting = clientSetting;

  constructor(private navController: NavController, private httpService: HttpService, private localStorage: LocalstorageService) {
    this.manager = new UserManager(this.clientSetting);
  }

  initUser() {
    return this.manager.getUser().then(user => {
      this.user = user;
      this.userProfile = JSON.parse(localStorage.getItem('userProfile'));
    });
  }

  createUserManager(prompt: string) {
    let setting = {
      ...this.clientSetting,
      prompt
    };
    this.manager = new UserManager(setting);
  }

  isLoggedIn(): boolean {
    return this.user != null && !this.user.expired;
  }

  getClaims(): any {
    return this.user.profile;
  }

  getUserProfile(): any {
    return this.userProfile;
  }

  getAccessToken() {
    return this.user.access_token;
  }

  getAuthorizationHeaderValue(): string {
    return `${this.user.token_type} ${this.user.access_token}`;
  }

  startAuthentication(prompt: string = null): Observable<any> {
    this.createUserManager(prompt);

    let signIn = this.manager.signinPopup();
    return from(signIn).pipe(
      concatMap(user => {
        this.user = user;
        return this.createUser();
      })
    );
  }

  completeAuthentication(): Promise<void> {
    return this.manager.signinPopupCallback().then(() => {
    }).catch(() => { });
  }

  signOut() {
    this.manager.signoutPopup().then(() => {
      this.navController.navigateRoot('');
    });
  }

  //  must handle the callback in order to the popup can be closed, this callback will be called before the response for signoutPopup above
  completeSignOut() {
    this.manager.signoutPopupCallback().then(() => {
    }).catch(() => { });
  }

  refreshToken() {
    return from(this.manager.signinSilent().then(user => {
      this.user = user;
      return true;
    }).catch(() => false));
  }

  updateUserProfile(value: any) {
    this.userProfile = {
      ...this.userProfile,
      ...value,
      gender: value.gender.toString()
    };

    this.localStorage.set('userProfile', JSON.stringify(this.userProfile));
  }

  private createUser(): Observable<any> {
    return this.httpService.get('api/user/getUserInfo').pipe(map(user => {

      let value = {
        ...this.user.profile,
        id: this.user.profile[this.claimTypes.id],
        email: this.user.profile[this.claimTypes.email],
        avatar: user.avatar,
        cover: user.cover,
        name: user.name,
        phone: user.phone,
        birthday: user.birthday,
        gender: user.gender
      };

      this.updateUserProfile(value);
    }));
  }
}
