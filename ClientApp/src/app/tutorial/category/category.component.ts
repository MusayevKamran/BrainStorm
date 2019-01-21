import { OnInit, Component } from '@angular/core';
import { CategoryService } from 'src/app/shared/services/category.service';
import { ICategory } from 'src/app/shared/interface/category';


@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.scss']
})
export class CategoryComponent implements OnInit {
  
  categories: ICategory[] = [];
  searchStr: string = "";
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
