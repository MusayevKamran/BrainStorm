import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { IArticleCategory } from '../interface/IArticleCategory';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ArticlecategoryService {

  private baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getArticleCategory(): Observable<IArticleCategory[]> {
    return this.http.get<IArticleCategory[]>(this.baseUrl + 'articlecategories');
  }

  getCategoriesByArticleId(id: number): Observable<IArticleCategory[]> {
    return this.http.get<IArticleCategory[]>(this.baseUrl + 'articlecategories/category/' + id);
  }

  getArticlesByCategoryId(id: number): Observable<IArticleCategory> {
    return this.http.get<IArticleCategory>(this.baseUrl + 'articlecategories/article/' + id);
  }
}
