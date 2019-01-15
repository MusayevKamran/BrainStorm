import { Component, OnInit } from '@angular/core';
import { CategoryService } from '../services/category.service';


@Component({
  selector: 'app-tutorial',
  templateUrl: './tutorial.component.html',
  styleUrls: ['./tutorial.component.scss']
})
export class TutorialComponent implements OnInit {

  public categories = [];
  public errorMsg: any;

  constructor(private _categoryService: CategoryService) { }

  ngOnInit() {
    this.getValue();
  }

  getValue() {
    this._categoryService.getCategory().subscribe(response => {
      this.categories = response, console.log(response);
      }, error => console.log(error));
  }
}
