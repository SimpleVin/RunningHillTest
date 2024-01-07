import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClient, HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {MatRadioModule} from '@angular/material/radio';
import {MatButtonToggleModule} from '@angular/material/button-toggle';
import { MatChipsModule} from '@angular/material/chips';
import {MatCardModule} from '@angular/material/card';
import {MatButtonModule} from '@angular/material/button';
import {MatDividerModule} from '@angular/material/divider';
import {MatListModule} from '@angular/material/list';
import {LiveAnnouncer} from '@angular/cdk/a11y';
import {MatIconModule} from '@angular/material/icon';
import {MatChipInputEvent} from '@angular/material/chips';
import {MatExpansionModule} from '@angular/material/expansion';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    MatRadioModule,MatButtonToggleModule,
    MatChipsModule,MatCardModule,MatButtonModule,MatDividerModule,MatListModule,MatIconModule,MatExpansionModule 
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
