import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../environment/environment';
import { OutTagsDTO, Tag } from '../models/Tags';

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
}
