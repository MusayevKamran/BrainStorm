import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { HtmlComponent } from './html.component';
import { HtmlAttributesComponent } from './html-attributes/html-attributes.component';


const routes: Routes = [
  {
    path: "tutorial/html", component: HtmlComponent, children: [
      { path: "html-attributes", component: HtmlAttributesComponent }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class HtmlRoutingModule { }
