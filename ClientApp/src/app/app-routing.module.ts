import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { HomeComponent } from './common/header/home/home.component';
import { AboutComponent } from './common/header/about/about.component';
import { TutorialComponent } from './tutorial/tutorial.component';

const routes: Routes = [
  { path: "home", component: HomeComponent },
  { path: "about", component: AboutComponent },
  { path: "tutorial", component: TutorialComponent },
  { path: "admin", redirectTo: "admin", pathMatch: 'full'},
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
