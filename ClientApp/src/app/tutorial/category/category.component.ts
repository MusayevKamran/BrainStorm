import { ICategory } from '../../interface/category';
import { OnInit, Component } from '@angular/core';
import { CategoryService } from '../../services/category.service';


@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.scss']
})
export class CategoryComponent implements OnInit {

  public categories: ICategory[] = [];

  constructor(private _categoryService: CategoryService) { }

  ngOnInit() {
    this.getValue();
  }

  getValue() {
    this._categoryService.getCategories().subscribe(response => {
      this.categories = response,
      console.log(response);
      }, error => console.log(error));
  }

}
