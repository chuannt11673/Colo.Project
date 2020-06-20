import { AuthService } from './../../../_core/services/auth.service';
import { HttpService } from './../../../_core/services/http.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-message',
  templateUrl: './message.component.html',
  styleUrls: ['./message.component.scss'],
})
export class MessageComponent implements OnInit {

  constructor(private httpService: HttpService, private authService: AuthService) { }

  ngOnInit() {
    this.httpService.get('weatherforecast').subscribe(res => {
      
    });
  }

  logout() {
    this.authService.signOut();
  }
}
