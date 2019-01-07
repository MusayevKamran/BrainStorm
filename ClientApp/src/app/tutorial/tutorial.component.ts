import { Component, OnInit } from '@angular/core';
import { CategoryService } from '../services/category.service';


@Component({
  selector: 'app-tutorial',
  templateUrl: './tutorial.component.html',
  styleUrls: ['./tutorial.component.scss']
})
export class TutorialComponent implements OnInit {

  public categories = [];
  public errorMsg;

  constructor(private _categoryService: CategoryService) { }

  ngOnInit() {
    this._categoryService.getCategory()
      .subscribe(data => this.categories = data);
  }
}
