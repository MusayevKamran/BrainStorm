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
<<<<<<< HEAD
    HtmlModule,
    ],
=======
    HtmlModule
  ],
>>>>>>> ecb1ce4e4edece5a6e9474134e0691ba56b12c0f
  declarations: [
    TutorialComponent,
    CategoryComponent,
    ContextComponent
  ],
  providers: [
<<<<<<< HEAD

=======
    TutorialService,
    CategoryService
>>>>>>> ecb1ce4e4edece5a6e9474134e0691ba56b12c0f
  ],
  schemas: [
    CUSTOM_ELEMENTS_SCHEMA
  ],
  exports: [
  ],
})
export class TutorialModule { }
