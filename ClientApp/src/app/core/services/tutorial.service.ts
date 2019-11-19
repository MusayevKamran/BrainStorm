import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Tutorial } from '../models/tutorial';
import { environment } from 'src/environments/environment';
import { TutorialList } from '../models/tutorial-list';



@Injectable()
export class TutorialService {

  private baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getTutorial(): Observable<Tutorial[]> {
    return this.http.get<Tutorial[]>(this.baseUrl + 'api/' + 'articles/tutorials');
  }

  getTutorialById(id): Observable<Tutorial> {
    return this.http.get<Tutorial>(this.baseUrl + 'api/' + 'articles/' + id);
  }

  getTutorialsNameById(Id): Observable<TutorialList[]> {
    return this.http.get<TutorialList[]>(this.baseUrl + 'api/' + 'articles/tutorials/category/' + Id);
  }
}
