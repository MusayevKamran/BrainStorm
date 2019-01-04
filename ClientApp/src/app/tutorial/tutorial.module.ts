import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TutorialRoutingModule } from './tutorial-routing.module';
import { TutorialComponent } from './tutorial.component';
import { HtmlModule } from './html/html.module';


@NgModule({
  imports: [
    CommonModule,
    TutorialRoutingModule,
    HtmlModule
  ],
  declarations: [
    TutorialComponent,
  ],
  exports: [
  ],
})
export class TutorialModule { }
