import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';


import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { HeaderModule } from './common/header/header.module';
import { HeaderComponent } from './common/header/header.component';
import { TutorialModule } from './tutorial/tutorial.module';
import { TutorialService } from './services/tutorial.service';
import { CategoryService } from './services/category.service';
import { AlertifyService } from './services/alertify.service';
import { CUSTOM_ELEMENTS_SCHEMA } from '@angular/compiler/src/core';
import { CategoryModule } from './category/category.module';

@NgModule({
   declarations: [
      AppComponent,
      HeaderComponent
   ],
   imports: [
      BrowserModule,
      HttpClientModule,
      AppRoutingModule,
      HeaderModule,
      TutorialModule,
   ],
   providers: [
      AlertifyService,
      CategoryService,
      TutorialService
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
