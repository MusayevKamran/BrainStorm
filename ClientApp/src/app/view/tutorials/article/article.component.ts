import { Component, OnInit, Input, Output, ViewEncapsulation } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { TutorialService } from 'src/app/core/services/tutorial.service';
import { Tutorial } from 'src/app/core/models/tutorial';


@Component({
  selector: 'app-article',
  templateUrl: './article.component.html',
  styleUrls: ['./article.component.scss'],
  encapsulation: ViewEncapsulation.None,
})
export class ArticleComponent implements OnInit {
  articleId: number;
  article: Tutorial;

  constructor(private route: ActivatedRoute, private _tutorialService: TutorialService) {}

  ngOnInit() {
    this.route.queryParams.subscribe(params => {
      this.articleId = params.id;
      this.getArticleByID();
    });
  }

  getArticleByID() {
    this._tutorialService.getTutorialById(this.articleId).subscribe(article => {
      this.article = article;
    });
  }
}
