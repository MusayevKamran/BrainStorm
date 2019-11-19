import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';
import { Category } from '../models/category';

@Injectable({
  providedIn: 'root'
})
export class ArticleCategoryService {

  private baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getCategories(): Observable<Category[]> {
    return this.http.get<Category[]>(this.baseUrl + 'api/' + 'categories');
  }

  getCategoryById(id): Observable<Category> {
    return this.http.get<Category>(this.baseUrl + 'api/' + 'categories' + id);
  }

}
