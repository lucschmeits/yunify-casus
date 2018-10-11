import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import {RequestOptions, Request, RequestMethod} from '@angular/http';
import { OfficeDetail } from '../models/office-detail';
import { CreateOffice } from '../models/create-office';
import { environment } from '../../environments/environment';
import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class OfficeService {
  

  constructor(private http: HttpClient) { }

  public getOffices(): Observable<OfficeDetail[]> {
      return this.http.get<OfficeDetail[]>(environment.BASE_API_URL + 'office').pipe(
        map(res => res)
      );
  } 

  public addOffice(office){
    office.OpenHour = new Date("10/11/2018 " + office.OpenHour + ":00");
    office.CloseHour = new Date("10/11/2018 " + office.CloseHour + ":00");

    return this.http.post(environment.BASE_API_URL + 'office', office).pipe(
        map(res => res)
      );
  }
}
