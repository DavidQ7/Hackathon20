import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class PhotoService {

  constructor() { }

  GetPhoto(fetchURL) {
    return fetch(fetchURL, {headers: {
      'Access-Control-Allow-Origin': '*'
      }, })
  .then(response => response.blob())
  .then(async blob => {
      return await this.loadImage(blob);
  }).catch((err) => console.log(err));
  }
  loadImage(src) {
    return new Promise(resolve => {
      const reader = new FileReader() ;
      reader.readAsDataURL(src);
      reader.onload = () => {
        resolve(reader.result);
      };
    });
  }
}
