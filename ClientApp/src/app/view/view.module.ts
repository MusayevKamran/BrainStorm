import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TutorialRoutingModule } from './view-routing.module';
import { CategoryComponent } from './tutorials/category/category.component';
import { TutorialService } from '../core/services/tutorial.service';
import { CategoryService } from '../core/services/category.service';
import { TutorialHoverDirective } from '../shared/directives/tutorial-hover.directive';
import { SearchPipe } from '../shared/pipe/search.pipe';
import { FormsModule } from '@angular/forms';
import { ArticleComponent } from './tutorials/article/article.component';
import { SafeHtmlPipe } from '../shared/pipe/safeHtml.pipe';
import { BlogsComponent } from './blogs/blogs.component';
import { TutorialsComponent } from './tutorials/tutorials.component';
import { InputFormatDirective } from '../shared/directives/appInputFormat.directive';
import { ChatService } from '../core/services/chat.service';
import { ChatComponent } from '../shared/components/chat/chat.component';
import { HomeComponent } from './home/home.component';
import { AboutComponent } from './about/about.component';

@NgModule({
  imports: [
    CommonModule,
    TutorialRoutingModule,
    FormsModule
  ],
  declarations: [
    CategoryComponent,
    TutorialsComponent,
    ArticleComponent,
    BlogsComponent,
    HomeComponent,
    AboutComponent,

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
  exports: [
  ],
})
export class ViewModule { }
