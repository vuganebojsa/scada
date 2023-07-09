import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../environment/environment';
import { Alarm, AlarmPriorityDTO } from '../models/Alarm';
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
  public getLastValueOfAITags(sortType:number): Observable<TagReportTimePeriodDTO>{
    return this.http.get<TagReportTimePeriodDTO>(this.base_url + 'getLastValuesOfAiTags?sortType=' + String(sortType));
  }

  public getLastValueOfDITags(sortType:number): Observable<TagReportTimePeriodDTO>{
    return this.http.get<TagReportTimePeriodDTO>(this.base_url + 'getLastValuesOfDiTags?sortType=' + String(sortType));
  }
}
