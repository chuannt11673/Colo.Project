import { Injectable } from '@angular/core';
import { retry, catchError } from 'rxjs/operators';
import {
    HttpInterceptor, HttpHandler, HttpRequest
} from '@angular/common/http';
import { throwError } from 'rxjs';
import { ToastController } from '@ionic/angular';

@Injectable({ providedIn: 'root' })
export class ExceptionInterceptor implements HttpInterceptor {

    constructor(private toast: ToastController) { }

    intercept(req: HttpRequest<any>, next: HttpHandler) {
        console.log('hehee')
        return next.handle(req)
            .pipe(retry(0), catchError(error => {
                return throwError(error);
            }));
    }

}