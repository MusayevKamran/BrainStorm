import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ITutorial } from '../interface/tutorial';
import { environment } from 'src/environments/environment';



@Injectable()
export class TutorialService {

  private baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getTutorial(): Observable<ITutorial[]> {
    return this.http.get<ITutorial[]>(this.baseUrl + 'articles');
  }

  getTutorialById(id): Observable<ITutorial> {
    return this.http.get<ITutorial>(this.baseUrl + 'articles' + id);
  }
}
