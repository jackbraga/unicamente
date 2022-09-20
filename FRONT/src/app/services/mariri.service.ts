import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import {Mariri} from './../models/Mariri';

@Injectable()
export class MaririService {
  public baseUrl ='https://localhost:7137/Mariri';



  constructor(public http:HttpClient){ }

   getMariri(): Observable<Mariri[]>{

    return this.http.get<Mariri[]>(this.baseUrl);
  }
  addMariri(mariri:Mariri){
    return this.http.post(this.baseUrl, mariri);
}

updateMariri(mariri:Mariri){
    return this.http.put(this.baseUrl, mariri);
}

deleteMariri(id: number) {
    return this.http.delete(this.baseUrl + "/" + id);
}

}
