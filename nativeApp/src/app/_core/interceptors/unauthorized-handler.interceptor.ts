import { NavController } from '@ionic/angular';
import { AuthService } from './../services/auth.service';
import { Injectable, Inject } from '@angular/core';
import { HttpInterceptor, HttpHandler, HttpRequest, HttpErrorResponse } from '@angular/common/http';
import { catchError, switchMap } from 'rxjs/operators';
import { throwError } from 'rxjs';

@Injectable()
export class UnAuthorizedHandlerInterceptor implements HttpInterceptor {

    constructor(private authService: AuthService, private navController: NavController) { }

    intercept(req: HttpRequest<any>, next: HttpHandler) {
        return next.handle(req).pipe(catchError(err => {
            if (err instanceof HttpErrorResponse && err.status === 401)
                return this.authService.refreshToken().pipe(switchMap(res => {
                    if (res)
                        return next.handle(this.injectToken(req));

                    this.navController.navigateRoot('');
                }));

            return throwError(err);
        }));
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