import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ICategory } from '../interface/category';


@Injectable()
export class CategoryService {

  private _Url = 'http://localhost:2924/';

  constructor(private http: HttpClient) { }

  getCategory(): Observable<ICategory[]> {
    return this.http.get<ICategory[]>(this._Url + 'api/categories');
  }
}
