import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ICategory } from '../interface/category';
import { environment } from 'src/environments/environment';


@Injectable()
export class CategoryService {

  private baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getCategories(): Observable<ICategory[]> {
    return this.http.get<ICategory[]>(this.baseUrl + 'categories', {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        'Access-Control-Allow-Origin': '*',
        'Access-Control-Allow-Headers' : 'Origin, X-Requested-With, Content-Type, Accept'
      })}
     );
  }

  getCategoryById(id): Observable<ICategory> {
    return this.http.get<ICategory>(this.baseUrl + 'categories' + id);
  }
}
