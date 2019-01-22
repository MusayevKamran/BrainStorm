import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { TutorialModule } from './tutorial/tutorial.module';
import { AlertifyService } from './shared/services/alertify.service';
import { CategoryService } from './shared/services/category.service';
import { TutorialService } from './shared/services/tutorial.service';
import { HeaderComponent } from './tutorial/common/header/header.component';
import { HeaderModule } from './tutorial/common/header/header.module';
import { FormsModule } from '@angular/forms';

@NgModule({
   declarations: [
      AppComponent,
      HeaderComponent,
   ],
   imports: [
      BrowserModule,
      HttpClientModule,
      AppRoutingModule,
      HeaderModule,
      TutorialModule,
      FormsModule
   ],
   providers: [
      AlertifyService,
      CategoryService,
      TutorialService,
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
