import { Injectable } from '@angular/core';
import { Subject, Observable } from 'rxjs';

@Injectable()
export class UserInfoService {

  private userSubject: Subject<any> = new Subject();
  userObs: Observable<any> = this.userSubject.asObservable();
  constructor() { }

  nextUser(user: any) {
    this.userSubject.next(user);
  }
}
