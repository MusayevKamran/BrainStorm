import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TutorialRoutingModule } from './tutorial-routing.module';
import { TutorialComponent } from './tutorial.component';
import { CategoryModule } from '../category/category.module';
import { HtmlModule } from './html/html.module';
import { TutorialService } from '../services/tutorial.service';


@NgModule({
  imports: [
    CommonModule,
    TutorialRoutingModule,
    CategoryModule,
    HtmlModule
  ],
  declarations: [
    TutorialComponent
  ],
  providers: [
    TutorialService
  ],
  schemas: [
    CUSTOM_ELEMENTS_SCHEMA
  ],
  exports: [
  ],
})
export class TutorialModule { }
