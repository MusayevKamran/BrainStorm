import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './view/home/home.component';
import { AboutComponent } from './view/about/about.component';
import { BlogsComponent } from './view/blogs/blogs.component';
import { ChatComponent } from './shared/components/chat/chat.component';
import { TutorialsComponent } from './view/tutorials/tutorials.component';



const routes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'about', component: AboutComponent },
  { path: 'tutorial', component: TutorialsComponent },
  { path: 'blog', component: BlogsComponent },
  { path: 'chat', component: ChatComponent },
  { path: 'admin', redirectTo: 'admin', pathMatch: 'full'},

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
