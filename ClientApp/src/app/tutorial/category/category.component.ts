import { OnInit, Component, Output, OnDestroy } from '@angular/core';
import { CategoryService } from '../../shared/services/category.service';
import { ICategory } from '../../shared/interface/category';
import { Subscription } from 'rxjs';
import { fade, slide } from 'src/app/shared/animation/animation';


@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.scss'],
  animations: [ fade ]
})
export class CategoryComponent implements OnInit {

  categories: ICategory[] = [];
  searchStr = '';
  subscription: Subscription;

  constructor(private _categoryService: CategoryService) { }

  ngOnInit() {
    this.getValue();
  }


  getValue() {
    this.subscription = this._categoryService.getCategories().subscribe(response => {
      this.categories = response,
        this.categories.forEach(category => {
          localStorage.setItem(category.name, JSON.stringify(category.id));
        }),
        console.log(response);
    }, error => console.log(error));
  }
}
