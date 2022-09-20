import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Chacrona } from './chacrona.model';

@Injectable()
export class ChacronaService {
    // public url = "api/users";
    public urlChacrona = environment.apiURL + "/api/chacrona";
    // public urlApi = "https://localhost:7137/api/mariri"
    constructor(public http:HttpClient) { }

    // getUsers(): Observable<User[]> {
    //     return this.http.get<User[]>(this.url);
    // }

    getChacrona(): Observable<Chacrona[]> {
      return this.http.get<Chacrona[]>(this.urlChacrona);
  }


    addChacrona(chacrona:Chacrona){
      // const fileToUpload = chacrona.arquivo;
      const formData = new FormData();
      formData.append('arquivo',chacrona.arquivo);
      formData.append('descricao',chacrona.descricao);
      formData.append('observacao',chacrona.observacao);
      return this.http.post(this.urlChacrona,formData);
  }


  updateChacrona(chacrona:Chacrona){
    const formData = new FormData();
    formData.append('id',chacrona.id.toString());
    formData.append('arquivo',chacrona.arquivo);
    formData.append('descricao',chacrona.descricao);
    formData.append('observacao',chacrona.observacao);
    // return this.http.post(this.urlchacrona,formData);
      return this.http.put(this.urlChacrona, formData);
  }

  deleteChacrona(id: number) {
      return this.http.delete(this.urlChacrona + "/" + id);
  }

}
