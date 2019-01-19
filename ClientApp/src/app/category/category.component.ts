import { Component, OnInit } from '@angular/core';
import { ICategory } from '../interface/category';
import { CategoryService } from '../services/category.service';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.scss']
})
export class CategoryComponent implements OnInit {

  language = 'html';
  content = '<p>test</p>';
  
  
  // categories: ICategory[] = [];

  // constructor(private _categoryService: CategoryService) { }

  ngOnInit() {
    // this.getValue();
  }

  // getValue() {
  //   this._categoryService.getCategories().subscribe(response => {
  //     this.categories = response,
  //     console.log(response);
  //     }, error => console.log(error));
  // }

}
