import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class LocalstorageService {

  private storage = window.localStorage;
  constructor() { }

  set(key: string, value: string) {
    this.storage.setItem(key, value);
  }

  get(key: string): string {
    let value = this.storage.getItem(key);
    return value;
  }

  remove(key: string) {
    this.storage.removeItem(key);
  }

  clear() {
    this.storage.clear();
  }
}
