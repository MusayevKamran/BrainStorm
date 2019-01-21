import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ArticlecategoryService } from '../../shared/services/articlecategory.service';
import { IArticleCategory } from '../../shared/interface/IArticleCategory';


@Component({
  selector: 'app-context',
  templateUrl: './context.component.html',
  styleUrls: ['./context.component.scss']
})
export class ContextComponent implements OnInit {
  articleCategory: IArticleCategory[] = [];
  searchStr = '';

  constructor(private route: ActivatedRoute, private _articleCategory: ArticlecategoryService) { }
  categoryName: string;
  categoryId: number;

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.categoryName = params.id;
      console.log(params);
    });

    this.getValue();
  }

  getValue() {
    this.categoryId = Number(localStorage.getItem(this.categoryName));
    localStorage.key(this.categoryId);
    console.log(this.categoryId);

    this._articleCategory.getArticlesByCategoryId(this.categoryId)
      .subscribe(response => {
          this.articleCategory = response,
          console.log(response);
      }, error => console.log(error));
  }
}
