import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../environment/environment';

@Injectable({
  providedIn: 'root'
})
export class AlarmsService {

  base_url:string = environment.apiHost + '/Alarms';
  constructor(private http: HttpClient) { }


}
