import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { TutorialComponent } from './tutorial/tutorial.component';
import { HomeComponent } from './tutorial/common/header/home/home.component';
import { AboutComponent } from './tutorial/common/header/about/about.component';
import { BlogsComponent } from './tutorial/blogs/blogs.component';

const routes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'about', component: AboutComponent },
  { path: 'tutorial', component: TutorialComponent },
  { path: 'blog', component: BlogsComponent },
  { path: 'admin', redirectTo: 'admin', pathMatch: 'full'},

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
