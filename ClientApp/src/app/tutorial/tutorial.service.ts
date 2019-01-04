import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';


@Injectable()
export class TutorialService {

  private _url: string = "http://localhost:10425/api/categories";

  constructor(private http: HttpClient) { }

  getTutorial(): Observable {
    return this.http.get(this._url);
  }
}
