import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ITutorial } from 'src/app/shared/interface/tutorial';
import { TutorialService } from 'src/app/shared/services/tutorial.service';
import { IArticleCategory } from 'src/app/shared/interface/article-category';
import { CategoryService } from 'src/app/shared/services/category.service';
import { ITutorialList } from 'src/app/shared/interface/tutorial-list';


@Component({
  selector: 'app-context',
  templateUrl: './context.component.html',
  styleUrls: ['./context.component.scss']
})
export class ContextComponent implements OnInit {

  searchStr = '';
  articleList: ITutorialList[] = [];
  article: ITutorialList;
  categoryName: string;
  categoryId: number;
  arcticlesOfCategory: IArticleCategory[] = [];

  constructor(private route: ActivatedRoute,
    private _categoryService: CategoryService,
    private _tutorialService: TutorialService) { }

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.categoryName = params.name;
    });
    this.getValue();
    console.log(this.articleList);
    console.log('sadsd');
  }

  getValue() {
    this.categoryId = Number(localStorage.getItem(this.categoryName));

    this._categoryService.getCategoryById(this.categoryId).subscribe(response => {
      
        this._tutorialService.getTutorialsCategoryById(response.id).subscribe(article => {
          article.forEach(element => {
            this.articleList.push(element);
          });
        });
      }, error => console.log(error));
  }
}
