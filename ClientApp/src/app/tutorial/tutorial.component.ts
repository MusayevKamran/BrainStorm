import { Component, OnInit } from '@angular/core';
import { TutorialService } from './tutorial.service';

@Component({
  selector: 'app-tutorial',
  templateUrl: './tutorial.component.html',
  styleUrls: ['./tutorial.component.scss']
})
export class TutorialComponent implements OnInit {

  public categories = [];

  constructor(private _tutorialService: TutorialService) { }

  ngOnInit() {
    this._tutorialService.getTutorial()
      .subscribe(data => this.categories = data);
  }

}
