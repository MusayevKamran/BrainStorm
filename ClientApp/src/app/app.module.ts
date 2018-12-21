import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { HeaderModule } from './common/header/header.module';
import { HeaderComponent } from './common/header/header.component';
import { TutorialModule } from './tutorial/tutorial.module';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,

    HeaderModule,
    TutorialModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
