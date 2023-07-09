import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { environment } from '../environment/environment';
import {OutTagsDTO, InTagsDTO, Tag, TagReportTimePeriodDTO,AnalogInput,AnalogInputDto, DigitalOutputDTO, DigitalInputDTO, AnalogOutput} from '../models/Tags';
import {AlarmPriorityDTO} from "../models/Alarm";

@Injectable({
  providedIn: 'root'
})
export class TagsService {

  base_url:string = environment.apiHost + 'api/Tag/';

  created$ = new BehaviorSubject(false);
  createdState$ = this.created$.asObservable();

  setCreated():void{
    this.created$.next(!this.created$);
  }
  constructor(private http: HttpClient) { }

  getOutputTags():Observable<OutTagsDTO[]>{

    return this.http.get<OutTagsDTO[]>(this.base_url + 'outTags');
  }
  getTags():Observable<Tag[]>{
    return this.http.get<Tag[]>(this.base_url);

  }
  createDigitalInputTag(digitalInputTag: DigitalInputDTO):Observable<any>{
    return this.http.post<any>(this.base_url + 'createDigitalInputTag',digitalInputTag);

  }
  createDigitalOutputTag(digitalOutputTag: DigitalOutputDTO):Observable<any>{
    return this.http.post<any>(this.base_url + 'createDigitalOutputTag',digitalOutputTag);

  }


  deleteOutTag(id:number, type:string):Observable<any[]>{

    return this.http.delete<any[]>(this.base_url + 'outTags?id=' + String(id) + '&type=' + type);
  }

  getInTags():Observable<InTagsDTO[]>{

    return this.http.get<InTagsDTO[]>(this.base_url + 'inTags');
  }

  createAITag(analogInput:AnalogInputDto):Observable<any>{
    return this.http.post<any>(this.base_url + "createAnalogInputTag", analogInput)
  }

  onOffTagScan(id:number, type:string, isOn: boolean):Observable<any[]>{

    return this.http.put<any[]>(this.base_url + 'inTagsScan', {
      "id":id,
      "type":type,
      "isOn":isOn
    });
  }

  createAOTag(newAnalogOutput: AnalogOutput):Observable<AnalogOutput>{
    return this.http.post<AnalogOutput>(this.base_url + 'createAnalogOutputTag', newAnalogOutput);
  }


}
