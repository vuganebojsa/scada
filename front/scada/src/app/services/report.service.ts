import {HttpClient, HttpParams} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../environment/environment';
import {Alarm, AlarmDTO, AlarmPriorityDTO} from '../models/Alarm';
import { TagReportTimePeriodDTO } from '../models/Tags';

@Injectable({
  providedIn: 'root'
})
export class ReportService {

  base_url:string = environment.apiHost + 'api/Report/';

  constructor(private http:HttpClient) { }


  public getReportsByPriority(sortType:number, priority:number): Observable<AlarmPriorityDTO>{
    return this.http.get<AlarmPriorityDTO>(this.base_url + 'getAlarmsByPriority?priority=' + String(priority) + '&sortType=' + String(sortType));

  }
  public getTagsInTimePeriod(from:Date, to:Date, sortType: number): Observable<TagReportTimePeriodDTO>{
    return this.http.get<TagReportTimePeriodDTO>(this.base_url + 'getTagsInTimePeriod?from=' + String(from) + '&to=' + String(to) + '&sortType=' + String(sortType));

  }

  public getAlarmsInTimePeriod(from: Date, to: Date, sortType: number): Observable<AlarmDTO>{
      return this.http.get<AlarmDTO>(this.base_url + 'getAlarmsInTimePeriod?from=' + String(from) + '&to=' + String(to) + '&sortType=' + String(sortType));
  }

  getTagValues(id:number):Observable<TagReportTimePeriodDTO>{
    // return this.http.get<AlarmPriorityDTO>(this.base_url + 'getAlarmsByPriority?priority=' + String(priority) + '&sortType=' + String(sortType));
    const params = new HttpParams()
      .set('tagId', id)
      .set('sortType', 4);
    return this.http.get<TagReportTimePeriodDTO>(this.base_url + 'getAllTagsById', { params });
  }
}
