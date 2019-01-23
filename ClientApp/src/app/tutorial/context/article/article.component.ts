import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ITutorial } from 'src/app/shared/interface/tutorial';


@Component({
  selector: 'app-article',
  templateUrl: './article.component.html',
  styleUrls: ['./article.component.scss']
})
export class ArticleComponent implements OnInit {
  articleId: number;
  @Output() article = new EventEmitter();
  @Output() outputIdToParent = new EventEmitter();

  constructor(private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.articleId = params.id;
    });
    this.outputIdToParent.emit(this.articleId);

    this.article.emit();
  }
}
