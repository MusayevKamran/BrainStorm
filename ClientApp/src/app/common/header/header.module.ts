import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home/home.component';
import { AboutComponent } from './about/about.component';
import { HeaderRoutingModule } from './header-routing.module';



@NgModule({
  imports: [
    CommonModule,
    HeaderRoutingModule,
  ],
  declarations: [
    HomeComponent, 
    AboutComponent,
  ]
})
export class HeaderModule { }
