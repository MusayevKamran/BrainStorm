import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TutorialRoutingModule } from './tutorial-routing.module';
import { TutorialComponent } from './tutorial.component';
import { CategoryComponent } from './category/category.component';
import { TutorialService } from '../shared/services/tutorial.service';
import { CategoryService } from '../shared/services/category.service';
import { TutorialHoverDirective } from '../shared/directive/tutorial-hover.directive';
import { SearchPipe } from '../shared/pipe/search.pipe';
import { FormsModule } from '@angular/forms';
import { ArticleComponent } from './tutorials/article/article.component';
import { SafeHtmlPipe } from '../shared/pipe/safeHtml.pipe';
import { BlogsComponent } from './blogs/blogs.component';
import { TutorialsComponent } from './tutorials/tutorials.component';
import { InputFormatDirective } from '../shared/directive/appInputFormat.directive';
import { ChatService } from '../shared/services/chat.service';
import { ChatComponent } from './chat/chat.component';

@NgModule({
  imports: [
    CommonModule,
    TutorialRoutingModule,
    FormsModule
  ],
  declarations: [
    TutorialComponent,
    CategoryComponent,
    TutorialsComponent,
    ArticleComponent,
    BlogsComponent,

    TutorialHoverDirective,
    InputFormatDirective,
    SearchPipe,
    SafeHtmlPipe,
    ChatComponent
  ],
  providers: [
    TutorialService,
    CategoryService,
    ChatService
  ],
  schemas: [
    CUSTOM_ELEMENTS_SCHEMA
  ],
  exports: [
  ],
})
export class TutorialModule { }
