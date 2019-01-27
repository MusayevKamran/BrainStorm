import { Component, OnInit, Input, Output, ViewEncapsulation } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { getQueryValue } from '@angular/core/src/view/query';
import { TutorialService } from 'src/app/shared/services/tutorial.service';
import { ITutorial } from 'src/app/shared/interface/tutorial';


@Component({
  selector: 'app-article',
  templateUrl: './article.component.html',
  styleUrls: ['./article.component.scss'],
  encapsulation: ViewEncapsulation.None,
})
export class ArticleComponent implements OnInit {
  articleId: number;
  article: ITutorial;

  constructor(private route: ActivatedRoute, private _tutorialService: TutorialService) {}

  ngOnInit() {
    this.route.queryParams.subscribe(params => {
      this.articleId = params.id;
      this.getValue();
    });
  }

  getValue() {
    this._tutorialService.getTutorialById(this.articleId).subscribe(article => {
      this.article = article;
    });
  }
}
