import { NavController } from '@ionic/angular';
import { AuthService } from './../services/auth.service';
import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpHandler, HttpRequest } from '@angular/common/http';


@Injectable()
export class HttpRequetsInterceptor implements HttpInterceptor {

    constructor(private authService: AuthService, private navController: NavController) {}

    intercept(req: HttpRequest<any>, next: HttpHandler) {
        return next.handle(this.injectToken(req));
    }

    private injectToken(req: HttpRequest<any>) {
        if (!this.authService.isLoggedIn())
            return req;

        return req.clone({
            setHeaders: {
                'Authorization': this.authService.getAuthorizationHeaderValue()
            }
        });
    }
}