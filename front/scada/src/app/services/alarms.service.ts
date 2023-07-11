import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { environment } from '../environment/environment';
import { ActivatedAlarm, Alarm, CreateAlarmDTO } from '../models/Alarm';

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
  getAllActivatedAlarms():Observable<ActivatedAlarm[]>{
    return this.http.get<ActivatedAlarm[]>(this.base_url + 'activated');
  }

  createAlarm(alarm:CreateAlarmDTO):Observable<Alarm>{
    return this.http.post<Alarm>(this.base_url, alarm);

  }
  deleteAlarm(id:string):Observable<boolean>{
    return this.http.delete<boolean>(this.base_url + '?id=' + id);
  }
}
