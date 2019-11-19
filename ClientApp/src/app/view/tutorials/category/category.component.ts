import { OnInit, Component } from '@angular/core';
import { Subscription } from 'rxjs';
import { fade } from 'src/app/shared/animations/animation';
import { Category } from 'src/app/core/models/category';
import { CategoryService } from 'src/app/core/services/category.service';


@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.scss'],
  animations: [ fade ]
})
export class CategoryComponent implements OnInit {

  categories: Category[] = [];
  searchStr = '';
  subscription: Subscription;

  constructor(private _categoryService: CategoryService) { }

  ngOnInit() {
    this.getCategoryList();
  }


  getCategoryList() {
    this.subscription = this._categoryService.getCategories()
    .subscribe(response => {
      this.categories = response,
        this.categories.forEach(category => {
          localStorage.setItem(category.name, JSON.stringify(category.id));
          console.log(this.categories);
        });
    }, error => console.log(error));
  }
}
