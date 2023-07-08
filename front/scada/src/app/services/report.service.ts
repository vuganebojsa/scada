import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../environment/environment';
import { Alarm, AlarmPriorityDTO } from '../models/Alarm';

@Injectable({
  providedIn: 'root'
})
export class ReportService {

  base_url:string = environment.apiHost + 'api/Report/';

  constructor(private http:HttpClient) { }


  public getReportsByPriority(sortType:number, priority:number): Observable<AlarmPriorityDTO>{
    return this.http.get<AlarmPriorityDTO>(this.base_url + 'getAlarmsByPriority?priority=' + String(priority) + '&sortType=' + String(sortType));

  }
}
