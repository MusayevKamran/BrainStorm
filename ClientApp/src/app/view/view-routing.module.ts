import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { TutorialsComponent } from './tutorials/tutorials.component';
import { ArticleComponent } from './tutorials/article/article.component';


const routes: Routes = [
  {
    path: 'tutorial', children: [
      { path: '', component: TutorialsComponent },
      {
        path: 'category/:name',
        component: TutorialsComponent,
        children : [
          {
            path: '',
            component: ArticleComponent
          },
        ]
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class TutorialRoutingModule { }
