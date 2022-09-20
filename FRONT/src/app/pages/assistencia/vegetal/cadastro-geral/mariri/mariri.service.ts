import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Mariri } from './mariri.model';
import { environment } from 'src/environments/environment';

@Injectable()
export class MaririService {
    // public url = "api/users";
    public urlMariri = environment.apiURL + "/api/mariri";
    // public urlApi = "https://localhost:7137/api/mariri"
    constructor(public http:HttpClient) { }

    // getUsers(): Observable<User[]> {
    //     return this.http.get<User[]>(this.url);
    // }

    getMariri(): Observable<Mariri[]> {
      return this.http.get<Mariri[]>(this.urlMariri);
  }


    addMariri(mariri:Mariri){
      // const fileToUpload = mariri.arquivo;
      const formData = new FormData();
      formData.append('arquivo',mariri.arquivo);
      formData.append('descricao',mariri.descricao);
      formData.append('observacao',mariri.observacao);
      return this.http.post(this.urlMariri,formData);
  }


  updateMariri(mariri:Mariri){
    const formData = new FormData();
    formData.append('id',mariri.id.toString());
    formData.append('arquivo',mariri.arquivo);
    formData.append('descricao',mariri.descricao);
    formData.append('observacao',mariri.observacao);
    // return this.http.post(this.urlMariri,formData);
      return this.http.put(this.urlMariri, formData);
  }

  deleteMariri(id: number) {
      return this.http.delete(this.urlMariri + "/" + id);
  }

}
