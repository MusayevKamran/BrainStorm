import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { TutorialService } from 'src/app/shared/services/tutorial.service';
import { ITutorial } from 'src/app/shared/interface/tutorial';

@Component({
  selector: 'app-article',
  templateUrl: './article.component.html',
  styleUrls: ['./article.component.scss']
})
export class ArticleComponent implements OnInit {
  articleId: number;
  article: ITutorial;

  constructor(private route: ActivatedRoute, private _tutorialService: TutorialService) { }

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.articleId = params.id;
    });

    this.getArticle(this.articleId);

  }
  getArticle(id: number){
    return this._tutorialService.getTutorialById(id).subscribe(response =>{
      this.article = response;
    });
  }
}
