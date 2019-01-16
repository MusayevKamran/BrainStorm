import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CategoryComponent } from './category.component';
import { CategoryRoutingModule } from './category-routing.module';
import { CategoryService } from '../services/category.service';


@NgModule({
  imports: [
    CommonModule,
    CategoryRoutingModule
  ],
  declarations: [
    CategoryComponent
  ],
  providers: [
    CategoryService
  ],
  schemas: [
    CUSTOM_ELEMENTS_SCHEMA
  ],
  exports: [
  ],
})
export class CategoryModule { }
