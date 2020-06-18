import { AuthService } from './../../../_core/services/auth.service';
import { Component, OnInit } from '@angular/core';
import { TranslateConfigService } from 'src/app/_core/services/translate-config.service';

@Component({
  selector: 'app-login-entry',
  templateUrl: './login-entry.component.html',
  styleUrls: ['./login-entry.component.scss'],
})
export class LoginEntryComponent implements OnInit {

  constructor(private authService: AuthService, public translateConfigService: TranslateConfigService) { }

  ngOnInit() {
    this.authService.completeSignOut();
  }

  logIn() {
    this.authService.startAuthentication();
  }

  changeLanguage(code: string) {
    this.translateConfigService.setLanguage(code);
  }
}
