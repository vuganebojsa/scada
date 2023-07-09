import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { environment } from '../environment/environment';
import { Alarm, CreateAlarmDTO } from '../models/Alarm';

@Injectable({
  providedIn: 'root'
})
export class AlarmsService {

  base_url:string = environment.apiHost + 'api/Alarm/';
  constructor(private http: HttpClient) { }
  created$ = new BehaviorSubject(false);
  createdState$ = this.created$.asObservable();

  setCreated():void{
    this.created$.next(!this.created$);
  }

  getAllAlarms():Observable<Alarm[]>{
    return this.http.get<Alarm[]>(this.base_url);
  }

  createAlarm(alarm:CreateAlarmDTO):Observable<Alarm>{
    return this.http.post<Alarm>(this.base_url, alarm);

  }
}
