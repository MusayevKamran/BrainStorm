import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { AlertifyService } from './core/services/alertify.service';
import { CategoryService } from './core/services/category.service';
import { TutorialService } from './core/services/tutorial.service';
import { HeaderComponent } from './shared/layout/header/header.component';
import { ViewModule } from './view/view.module';
import { ViewComponent } from './view/view.component';

@NgModule({
   declarations: [
      AppComponent,
      ViewComponent,
      HeaderComponent,
   ],
   imports: [
      BrowserModule,
      BrowserAnimationsModule,
      HttpClientModule,
      AppRoutingModule,
      ViewModule,
   ],
   providers: [
      AlertifyService,
      CategoryService,
      TutorialService
   ],
   bootstrap: [
      AppComponent
   ],
   schemas: [
     CUSTOM_ELEMENTS_SCHEMA
   ]
})
export class AppModule { }
