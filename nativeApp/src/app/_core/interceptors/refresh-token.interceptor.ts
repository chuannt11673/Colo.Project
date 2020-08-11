import { catchError, switchMap, flatMap, concatMap, mergeMap } from 'rxjs/operators';
import { AuthService } from './../services/auth.service';
import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpEvent, HttpHandler, HttpRequest, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';

@Injectable()
export class RefreshTokenInterceptor implements HttpInterceptor {

    constructor(private authService: AuthService) {
    }

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        return next.handle(req).pipe(catchError(err => {
            if (err instanceof HttpErrorResponse && err.status === 401) {
                return this.authService.refreshToken().pipe(switchMap((res) => {
                    return next.handle(this.injectToken(req));
                }));
            }

            return throwError(err);
        }));
    }

    private injectToken(req: HttpRequest<any>) {
        return req.clone({
            setHeaders: {
                'Authorization': this.authService.getAuthorizationHeaderValue()
            }
        });
    }
}