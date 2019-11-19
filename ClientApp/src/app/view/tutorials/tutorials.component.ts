import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { TutorialService } from 'src/app/core/services/tutorial.service';
import { ArticleCategory } from 'src/app/core/models/article-category';
import { CategoryService } from 'src/app/core/services/category.service';
import { TutorialList } from 'src/app/core/models/tutorial-list';


@Component({
  selector: 'app-tutorials',
  templateUrl: './tutorials.component.html',
  styleUrls: ['./tutorials.component.scss']
})
export class TutorialsComponent implements OnInit {

  searchStr = '';

  articleId: number;
  categoryId: number;

  article: TutorialList;
  articleList: TutorialList[] = [];

  categoryName: string;
  arcticlesOfCategory: ArticleCategory[] = [];

  constructor(private route: ActivatedRoute,
    private _categoryService: CategoryService,
    private _tutorialService: TutorialService) { }

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.categoryName = params.name;
    });

    this.getValue();
    console.log(this.articleList);
  }

  getValue() {
    this.categoryId = Number(localStorage.getItem(this.categoryName));

    this._categoryService.getCategoryById(this.categoryId).subscribe(response => {

        this._tutorialService.getTutorialsNameById(response.id).subscribe(article => {

          article.forEach(element => {
            this.articleList.push(element);
          });
        }, error => console.log(error));

      }, error => console.log(error));
  }
}
