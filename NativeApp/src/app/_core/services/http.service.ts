import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { httpEndpoint } from 'src/environments/environment';

@Injectable({ providedIn: 'root' })
export class HttpService {

    private endpoint: string = httpEndpoint;
    constructor(private httpClient: HttpClient) {}

    get(url: string) {
        return this.httpClient.get(`${this.endpoint}${url}`);
    }
}