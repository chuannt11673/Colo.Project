import { Component } from '@angular/core';

import { Platform, NavController } from '@ionic/angular';
import { SplashScreen } from '@ionic-native/splash-screen/ngx';
import { StatusBar } from '@ionic-native/status-bar/ngx';
import { Deeplinks } from '@ionic-native/deeplinks/ngx';
import { AuthCallbackComponent } from './_modules/login/auth-callback/auth-callback.component';

@Component({
  selector: 'app-root',
  templateUrl: 'app.component.html',
  styleUrls: ['app.component.scss']
})
export class AppComponent {
  constructor(
    private platform: Platform, private splashScreen: SplashScreen, private statusBar: StatusBar, private deeplinks: Deeplinks, private navController: NavController) {
    this.initializeApp();
  }

  initializeApp() {
    this.platform.ready().then(() => {
      
      this.statusBar.hide();
      this.splashScreen.hide();
      this.registerDeeplinks();
    });
  }

  registerDeeplinks() {
    this.deeplinks.route({
      '/auth-callback': AuthCallbackComponent
    }).subscribe((match: any) => {
      console.log(match);
      this.navController.navigateForward('auth-callback');
    });
  }
}
