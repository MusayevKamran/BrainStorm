import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ICategory } from '../interface/category';


@Injectable()
export class CategoryService {

  private _url: string = "http://localhost:10425/api/categories";

  constructor(private http: HttpClient) { }

  getCategory(): Observable<ICategory[]> {
    return this.http.get<ICategory[]>(this._url);
  }
}
