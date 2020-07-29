import { HttpService } from './../_core/services/http.service';
import { Injectable } from '@angular/core';

@Injectable()
export class FileService {

  private endpoint = 'api/file/';
  private uploadEndpoint = this.endpoint + 'upload';
  private uploadMultipleEndpoint = this.endpoint + 'uploadMultiple';
  constructor(private httpService: HttpService) { }

  upload(model: any) {
    return this.httpService.post(this.uploadEndpoint, model);
  }

  uploadMultiple(models: any[]) {
    return this.httpService.post(this.uploadMultipleEndpoint, models);
  }
}
