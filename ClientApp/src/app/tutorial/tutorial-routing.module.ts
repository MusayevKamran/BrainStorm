import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HtmlComponent } from './html/html.component';


const routes: Routes = [
  {
    path: "tutorial", children: [
      { path: "html", component: HtmlComponent }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class TutorialRoutingModule { }
