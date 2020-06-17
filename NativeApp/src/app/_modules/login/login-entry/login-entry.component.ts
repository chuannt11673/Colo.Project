import { AuthService } from './../../../_core/services/auth.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-login-entry',
  templateUrl: './login-entry.component.html',
  styleUrls: ['./login-entry.component.scss'],
})
export class LoginEntryComponent implements OnInit {

  constructor(private authService: AuthService) { }

  ngOnInit() {
    this.authService.completeSignOut();
  }

  logIn() {
    this.authService.startAuthentication();
  }
}
