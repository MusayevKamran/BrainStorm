import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TutorialRoutingModule } from './tutorial-routing.module';
import { TutorialComponent } from './tutorial.component';
import { HtmlModule } from './html/html.module';
import { CategoryComponent } from './category/category.component';
import { ContextComponent } from './context/context.component';
import { TutorialService } from '../shared/services/tutorial.service';
import { CategoryService } from '../shared/services/category.service';



@NgModule({
  imports: [
    CommonModule,
    TutorialRoutingModule,
    HtmlModule,
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
