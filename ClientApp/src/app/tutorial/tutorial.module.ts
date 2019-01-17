import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TutorialRoutingModule } from './tutorial-routing.module';
import { TutorialComponent } from './tutorial.component';
import { HtmlModule } from './html/html.module';
import { TutorialService } from '../services/tutorial.service';
import { CategoryComponent } from './category/category.component';
import { CategoryService } from '../services/category.service';
import { ContextComponent } from './context/context.component';



@NgModule({
  imports: [
    CommonModule,
    TutorialRoutingModule,
    HtmlModule
  ],
  declarations: [
    TutorialComponent,
    CategoryComponent,
    ContextComponent
  ],
  providers: [
    TutorialService,
    CategoryService
  ],
  schemas: [
    CUSTOM_ELEMENTS_SCHEMA
  ],
  exports: [
  ],
})
export class TutorialModule { }
