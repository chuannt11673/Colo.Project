import { NavController } from '@ionic/angular';
import { Component, OnInit } from '@angular/core';
import { TranslateConfigService } from '../_core/services/translate-config.service';
import { AuthService } from '../_core/services/auth.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-login',
  templateUrl: './login.page.html',
  styleUrls: ['./login.page.scss'],
})
export class LoginPage implements OnInit {

  loading = false;
  constructor(public translateConfigService: TranslateConfigService,
    private authService: AuthService,
    private navController: NavController) { }

  ngOnInit() {
    if (!environment.production)
      this.authService.completeSignOut();
  }

  changeLanguage(code: string) {
    this.translateConfigService.setLanguage(code);
  }

  logIn() {
    this.loading = true;
    this.authService.startAuthentication().subscribe(() => {
      this.navigateToHome();
    }, err => {
      this.loading = false;
    });;
  }

  register() {
    this.loading = true;
    this.authService.startAuthentication('create').subscribe(() => {
      this.navigateToHome();
    }, err => {
      this.loading = false;
    });
  }

  googleLogin() {
    this.loading = true;
    this.authService.startAuthentication('google').subscribe(() => {
      this.navigateToHome();
    }, err => {
      this.loading = false;
    });
  }

  private navigateToHome() {
    setTimeout(() => {
      this.navController.navigateRoot('/home').then(() => this.loading = false);
    }, 1000);
  }
}
