import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Category } from '../models/category';
import { environment } from 'src/environments/environment';


@Injectable()
export class CategoryService {

  private baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getCategories(): Observable<Category[]> {
    return this.http.get<Category[]>(this.baseUrl + 'api/' + 'categories');
  }

  getCategoryById(id): Observable<Category> {
    return this.http.get<Category>(this.baseUrl + 'api/' + 'categories/' + id);
  }
}
