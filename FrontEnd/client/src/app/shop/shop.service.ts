import { HttpClient, HttpParams, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IPetPagination } from '../shared/models/IPetPagination';
import { Observable, map, tap } from 'rxjs';
import { IAnimal } from '../shared/models/IAnimal';
import { PetRequestParams } from '../shared/models/PetRequestParams';

@Injectable({
  providedIn: 'root'
})
export class ShopService {

  baseUrl: string = 'https://localhost:5002/api/ShelterWithSpecs/'
  constructor(private httpClient: HttpClient) {

  }

  getPets(petRequestParams: PetRequestParams): Observable<IPetPagination | null> {
    let httpParams = new HttpParams();

    if (petRequestParams.animalsId && petRequestParams.animalsId > 0) {
      httpParams = httpParams.append('animalsId', petRequestParams.animalsId.toString());
    }

    if (petRequestParams.sort) {
      httpParams = httpParams.append('sort', petRequestParams.sort);
    }

    if (petRequestParams.search) {
      httpParams = httpParams.append('search', petRequestParams.search);
    }

    if (petRequestParams.vaccinationStatus !== undefined) {
      httpParams = httpParams.append('vaccinationStatus', petRequestParams.vaccinationStatus);
    }

    if (petRequestParams.pageIndex && petRequestParams.pageSize) {
      httpParams = httpParams.append('pageIndex', petRequestParams.pageIndex.toString());
      httpParams = httpParams.append('pageSize', petRequestParams.pageSize.toString());
    }

    //Get HttpResponse of type IPetPagination 
    let response: Observable<HttpResponse<IPetPagination>> =
      this.httpClient.get<IPetPagination>(this.baseUrl + 'pets',
        {
          //Observe body using params
          observe: 'response', params: httpParams
        });
    //Using Rxjs map() method through pipe() get a body of http response
    return response.pipe(
      map(response => {
        return response.body;
      })
    );
  }

  getAnimals(): Observable<IAnimal[]> {
    return this.httpClient.get<IAnimal[]>(this.baseUrl + 'animals');
  }
}
