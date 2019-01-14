import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ITutorial } from '../interface/tutorial';



@Injectable()
export class TutorialService {

  private _url: string = "http://localhost:2924/api/articles";

  constructor(private http: HttpClient) { }

  getTutorial(): Observable<ITutorial> {
    return this.http.get<ITutorial>(this._url);
  }
}
