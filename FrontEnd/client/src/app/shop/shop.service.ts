import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IPetPagination } from '../shared/models/IPetPagination';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ShopService {

  baseUrl: string = 'https://localhost:5002/api/ShelterWithSpecs/'
  constructor(private httpClient: HttpClient) {

  }

  getPets(): Observable<IPetPagination> {
    return this.httpClient.get<IPetPagination>(this.baseUrl + 'pets')
  }
}
