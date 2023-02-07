//Specify locale
import { NgModule, LOCALE_ID } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CoreModule } from './core/core.module';
import { HttpClientModule } from '@angular/common/http';
import { ShopModule } from './shop/shop.module';
//Add ru locale 
import localeRu from '@angular/common/locales/ru';
import { registerLocaleData } from '@angular/common';
import { TestingComponent } from './testing/testing/testing.component';

registerLocaleData(localeRu);
@NgModule({
  declarations: [
    AppComponent,
    TestingComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    CoreModule,
    ShopModule
  ],
  providers: 
  [{
    //provide locale
    provide: LOCALE_ID,
    useValue: 'ru_RU'
  }],
  bootstrap: [AppComponent]
})
export class AppModule {
}
