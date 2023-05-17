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
    return this.http.get<Marker[]>(this.apiUrl + 'place/getAll');
  }
  

  save(value: any)
  {
    return this.http.post(this.apiUrl + 'place/save', value);
  }
}
