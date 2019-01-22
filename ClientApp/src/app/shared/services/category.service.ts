import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ICategory } from '../interface/category';
import { environment } from 'src/environments/environment';
import { IArticleCategory } from '../interface/article-category';


@Injectable()
export class CategoryService {

  private baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getCategories(): Observable<ICategory[]> {
    return this.http.get<ICategory[]>(this.baseUrl + 'categories');
  }

  getCategoryById(id): Observable<ICategory> {
    return this.http.get<ICategory>(this.baseUrl + 'categories/' + id);
  }
}
