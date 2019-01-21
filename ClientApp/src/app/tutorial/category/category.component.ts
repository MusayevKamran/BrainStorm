import { OnInit, Component, Output } from '@angular/core';
import { CategoryService } from '../../shared/services/category.service';
import { ICategory } from '../../shared/interface/category';


@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.scss']
})
export class CategoryComponent implements OnInit {

  categories: ICategory[] = [];
  searchStr = '';

  constructor(private _categoryService: CategoryService) { }

  ngOnInit() {
    this.getValue();
  }

  getValue() {
    this._categoryService.getCategories().subscribe(response => {
      this.categories = response,
      this.categories.forEach(category => {
        localStorage.setItem(category.name, JSON.stringify(category.id));
      }),
        console.log(response);
    }, error => console.log(error));


  }
}
