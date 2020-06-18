import { AuthService } from './../services/auth.service';
import { Injectable } from '@angular/core';
import {
    HttpInterceptor, HttpHandler, HttpRequest
} from '@angular/common/http';

@Injectable({ providedIn: 'root' })
export class HttpRequestInterceptor implements HttpInterceptor {

    constructor(private authService: AuthService) {}

    intercept(req: HttpRequest<any>, next: HttpHandler) {
        if (this.authService.isLoggedIn()) {
            req = req.clone({
                setHeaders: {
                    'Authorization': `${this.authService.getAuthorizationHeaderValue()}`
                }
            });
        }
        return next.handle(req);
    }
}