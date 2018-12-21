import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HtmlComponent } from './html.component';
import { HtmlRoutingModule } from './html-routing.module';
import { HtmlAttributesComponent } from './html-attributes/html-attributes.component';



@NgModule({
  imports: [
    CommonModule,
    HtmlRoutingModule
  ],
  declarations: [
    HtmlComponent,
    HtmlAttributesComponent
  ],
  exports: [
  ]
})
export class HtmlModule { }
