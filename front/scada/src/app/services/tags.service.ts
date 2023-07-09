import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../environment/environment';
import {OutTagsDTO, InTagsDTO, Tag, TagReportTimePeriodDTO} from '../models/Tags';
import {AlarmPriorityDTO} from "../models/Alarm";

@Injectable({
  providedIn: 'root'
})
export class TagsService {

  base_url:string = environment.apiHost + 'api/Tag/';

  constructor(private http: HttpClient) { }

  getOutputTags():Observable<OutTagsDTO[]>{

    return this.http.get<OutTagsDTO[]>(this.base_url + 'outTags');
  }

  deleteOutTag(id:number, type:string):Observable<any[]>{

    return this.http.delete<any[]>(this.base_url + 'outTags?id=' + String(id) + '&type=' + type);
  }

  getInTags():Observable<InTagsDTO[]>{

    return this.http.get<InTagsDTO[]>(this.base_url + 'inTags');
  }

  onOffTagScan(id:number, type:string, isOn: boolean):Observable<any[]>{

    return this.http.put<any[]>(this.base_url + 'inTagsScan', {
      "id":id,
      "type":type,
      "isOn":isOn
    });
  }
}
