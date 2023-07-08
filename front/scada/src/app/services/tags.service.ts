import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../environment/environment';
import { OutTagsDTO, Tag } from '../models/Tags';

@Injectable({
  providedIn: 'root'
})
export class TagsService {

  base_url:string = environment.apiHost + 'api/Tags/';

  constructor(private http: HttpClient) { }

  getOutputTags():Observable<OutTagsDTO[]>{

    return this.http.get<OutTagsDTO[]>(this.base_url + '/outTags');
  }
}
