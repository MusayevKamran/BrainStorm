import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TutorialRoutingModule } from './tutorial-routing.module';
import { TutorialComponent } from './tutorial.component';
import { HtmlModule } from './html/html.module';
import { CategoryComponent } from './category/category.component';
import { ContextComponent } from './context/context.component';
import { TutorialService } from '../shared/services/tutorial.service';
import { CategoryService } from '../shared/services/category.service';
import { TutorialHoverDirective } from '../shared/directive/tutorial-hover.directive';
import { SearchPipe } from '../shared/pipe/search.pipe';
import { FormsModule } from '@angular/forms';

@NgModule({
  imports: [
    CommonModule,
    TutorialRoutingModule,
    HtmlModule,
    FormsModule
  ],
  declarations: [
    TutorialComponent,
    CategoryComponent,
    ContextComponent,
    TutorialHoverDirective,
    SearchPipe
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
