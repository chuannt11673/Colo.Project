import { Component, OnInit } from '@angular/core';
import { TranslateConfigService } from '../_core/services/translate-config.service';
import { AuthService } from '../_core/services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.page.html',
  styleUrls: ['./login.page.scss'],
})
export class LoginPage implements OnInit {

  constructor(public translateConfigService: TranslateConfigService, private authService: AuthService) { }

  ngOnInit() {
    this.authService.completeSignOut();
  }

  changeLanguage(code: string) {
    this.translateConfigService.setLanguage(code);
  }

  logIn() {
    this.authService.startAuthentication('login');
  }

  register() {
    this.authService.startAuthentication('create');
  }

  googleLogin() {
    this.authService.startAuthentication('google');
  }
}
