import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map, catchError, tap } from 'rxjs/operators'

import { ITutorial } from './tutorial';


@Injectable()
export class TutorialService {

  private _url: string = "http://localhost:10425/api/articles";

  constructor(private http: HttpClient) { }

  getTutorial(): Observable {
    return this.http.get(this._url);
  }
}
