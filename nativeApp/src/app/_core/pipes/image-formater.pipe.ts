import { Pipe, PipeTransform } from '@angular/core';
import { httpEndpoint } from 'src/environments/environment';

@Pipe({ name: 'imageUrl' })
export class ImageFormater implements PipeTransform {
    baseUrl: string = httpEndpoint;

    constructor() { }

    transform(value: any): any {
        if (value)
            return this.baseUrl + value;
        
        return 'https://images.unsplash.com/photo-1474552226712-ac0f0961a954?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=1351&q=80';
    }
}