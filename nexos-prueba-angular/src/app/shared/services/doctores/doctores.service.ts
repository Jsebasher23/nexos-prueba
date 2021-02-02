import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class DoctoresService {

  constructor(private http: HttpClient) { }

  readonly apiURL = 'http://localhost:5000/api';

  getDoctores(){
    return this.http.get(`${this.apiURL}/dotores`);
  }
}
