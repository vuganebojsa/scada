import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../environment/environment';
import { Alarm } from '../models/Alarm';

@Injectable({
  providedIn: 'root'
})
export class AlarmsService {

  base_url:string = environment.apiHost + 'api/Alarm/';
  constructor(private http: HttpClient) { }


  getAllAlarms():Observable<Alarm[]>{
    return this.http.get<Alarm[]>(this.base_url);
  }
}
