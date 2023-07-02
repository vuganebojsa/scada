import { Injectable } from '@angular/core';
import { environment } from '../environment/environment';

@Injectable({
  providedIn: 'root'
})
export class ReportService {

  base_url:string = environment.apiHost + 'Reports/';

  constructor() { }
}
