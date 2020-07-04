import { HttpService } from './../_core/services/http.service';
import { Injectable } from '@angular/core';

@Injectable()
export class WeatherForecastService {

  private endpoint = 'weatherforecast';
  private getEndpoint = this.endpoint;
  constructor(private httpService: HttpService) { }

  get() {
    return this.httpService.get(this.getEndpoint);
  }
}
