import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ITutorial } from 'src/app/shared/interface/tutorial';
import { TutorialService } from 'src/app/shared/services/tutorial.service';
import { IArticleCategory } from 'src/app/shared/interface/article-category';
import { CategoryService } from 'src/app/shared/services/category.service';
import { ICategory } from 'src/app/shared/interface/category';


@Component({
  selector: 'app-context',
  templateUrl: './context.component.html',
  styleUrls: ['./context.component.scss']
})
export class ContextComponent implements OnInit {

  searchStr = '';
  articleList: ITutorial[] = [];
  categoryName: string;
  categoryId: number;
  arcticlesOfCategory: IArticleCategory[] = [];

  constructor(private route: ActivatedRoute,
    private _categoryService: CategoryService,
    private _tutorialService: TutorialService) { }

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.categoryName = params.id;
    });

    this.getValue();
  }

  getValue() {
    this.categoryId = Number(localStorage.getItem(this.categoryName));
    this._categoryService.getCategoryById(this.categoryId)
      .subscribe(response => {
        this.arcticlesOfCategory = response.articleCategory;
        this.arcticlesOfCategory.forEach(artcle => {
          this._tutorialService.getTutorialById(artcle.articleId).subscribe(article => {
            this.articleList.push(article);
          }, error => console.log(error));
        });
      }, error => console.log(error));
  }
}
