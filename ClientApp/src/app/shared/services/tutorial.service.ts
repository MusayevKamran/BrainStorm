import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ITutorial } from '../interface/tutorial';
import { environment } from 'src/environments/environment';
import { ITutorialList } from '../interface/tutorial-list';



@Injectable()
export class TutorialService {

  private baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getTutorial(): Observable<ITutorial[]> {
    return this.http.get<ITutorial[]>(this.baseUrl + 'articles/tutorials');
  }

  getTutorialById(id): Observable<ITutorial> {
    return this.http.get<ITutorial>(this.baseUrl + 'articles/' + id);
  }

  getTutorialsNameById(Id): Observable<ITutorialList[]> {
    return this.http.get<ITutorialList[]>(this.baseUrl + 'articles/tutorials/category/' + Id);
  }
}
