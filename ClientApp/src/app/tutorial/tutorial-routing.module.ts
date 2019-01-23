import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HtmlComponent } from './html/html.component';
import { ContextComponent } from './context/context.component';
import { ArticleComponent } from './context/article/article.component';


const routes: Routes = [
  {
    path: 'tutorial', children: [
      { path: '', component: ContextComponent },
      {
        path: 'category/:name',
        component: ContextComponent,
      },
      {
        path: 'category/:name/:id',
        component: ContextComponent
      },
      
      { path: 'html', component: HtmlComponent }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class TutorialRoutingModule { }
