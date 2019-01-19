import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';
import { ICategory } from '../interface/category';

@Injectable({
  providedIn: 'root'
})
export class ArticleCategoryService {

  private baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getCategories(): Observable<ICategory[]> {
    return this.http.get<ICategory[]>(this.baseUrl + 'categories');
  }

  getCategoryById(id): Observable<ICategory> {
    return this.http.get<ICategory>(this.baseUrl + 'categories' + id);
  }

}
