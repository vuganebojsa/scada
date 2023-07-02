import { Injectable } from '@angular/core';
import { environment } from '../environment/environment';

@Injectable({
  providedIn: 'root'
})
export class TagsService {

  base_url:string = environment.apiHost + 'Tags/';

  constructor() { }
}
