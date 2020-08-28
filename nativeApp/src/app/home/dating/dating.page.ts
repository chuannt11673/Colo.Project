import { ActivatedRoute } from '@angular/router';
import { NavController } from '@ionic/angular';
import { UserService } from './../../_services/user.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-dating',
  templateUrl: './dating.page.html',
  styleUrls: ['./dating.page.scss'],
})
export class DatingPage implements OnInit {

  users: any[];
  constructor(public route: ActivatedRoute, private userService: UserService, private navController: NavController) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.users = data.data;
    });
  }

  userInfo(user: any) {
    this.navController.navigateForward(`user-info/${user.email}`);
  }

  chat(user: any) {
    this.navController.navigateForward(`chat/${user.email}`);
  }
}
