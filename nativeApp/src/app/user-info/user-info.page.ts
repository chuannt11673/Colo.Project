import { AuthService } from './../_core/services/auth.service';
import { TranslateConfigService } from './../_core/services/translate-config.service';
import { Component, OnInit } from '@angular/core';
import { UserService } from '../_services/user.service';
import { ActivatedRoute } from '@angular/router';
import { User } from 'oidc-client';

@Component({
  selector: 'app-user-info',
  templateUrl: './user-info.page.html',
  styleUrls: ['./user-info.page.scss'],
})
export class UserInfoPage implements OnInit {
  
  modeTypes = {
    diary: 1,
    album: 2
  }
  mode: number = this.modeTypes.diary;
  user: any;
  loggedInUser: User;
  constructor(public translateConfigService: TranslateConfigService, private route: ActivatedRoute,
    private userService: UserService,
    private authService: AuthService) { }

  ngOnInit() {
    this.loggedInUser = this.authService.getUserProfile();
    let email = this.route.snapshot.params['email'];
    this.userService.searchEmail(email).subscribe(user => {
      this.user = user;
    });
  }

}
