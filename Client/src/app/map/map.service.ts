import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Marker } from '../shared/models/Marker';

@Injectable({
  providedIn: 'root'
})
export class MapService {

  apiUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getAllByUser()
  {
    const token = localStorage.getItem('token');

    let headers = new HttpHeaders();
    headers = headers.set("Authorization", `Bearer ${token}`);

    return this.http.get<Marker[]>(this.apiUrl + 'place/getAll', { headers: headers });
  }
  

  save(value: any)
  {
    const token = localStorage.getItem('token');

    let headers = new HttpHeaders();
    headers = headers.set("Authorization", `Bearer ${token}`);

    return this.http.post(this.apiUrl + 'place/save', value, { headers: headers });
  }
}
