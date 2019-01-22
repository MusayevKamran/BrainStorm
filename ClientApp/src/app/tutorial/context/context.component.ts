import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ArticlecategoryService } from '../../shared/services/articlecategory.service';
import { IArticleCategory } from '../../shared/interface/articlecategory';
import { ITutorial } from 'src/app/shared/interface/tutorial';
import { TutorialService } from 'src/app/shared/services/tutorial.service';


@Component({
  selector: 'app-context',
  templateUrl: './context.component.html',
  styleUrls: ['./context.component.scss']
})
export class ContextComponent implements OnInit {

  articleList: ITutorial[] = [];
  searchStr = '';

  articleCategory: IArticleCategory[] = [];
  categoryName: string;
  categoryId: number;

  constructor(private route: ActivatedRoute,
    private _articleCategoryService: ArticlecategoryService,
    private _tutorialService: TutorialService) { }



  ngOnInit() {
    this.route.params.subscribe(params => {
      this.categoryName = params.id;
    });

    this.getValue();
  }

  getValue() {
    this.categoryId = Number(localStorage.getItem(this.categoryName));

    this._articleCategoryService.getArticlesByCategoryId(this.categoryId)
      .subscribe(response => {
        console.log(response);
        this.articleCategory.push(response);
        console.log(this.articleCategory);

        this.articleCategory.forEach(artclCategory => {
          console.log(artclCategory.articleId);

          this._tutorialService.getTutorialById(artclCategory.articleId).subscribe(article => {
            this.articleList.push(article),
              console.log(this.articleList);
          }, error => console.log(error));
        });

      }, error => console.log(error));
  }
}
