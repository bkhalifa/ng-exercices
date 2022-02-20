import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

// Imports for loading & configuring the in-memory web api
import { HttpClientInMemoryWebApiModule } from 'angular-in-memory-web-api';
import { ProductData } from './products/product-data';

import { AppRoutingModule } from './app-routing.module';

import { AppComponent } from './app.component';
import { ShellComponent } from './home/shell.component';
import { MenuComponent } from './home/menu.component';
import { WelcomeComponent } from './home/welcome.component';
import { PageNotFoundComponent } from './home/page-not-found.component';

/* Feature Modules */
import { UserModule } from './user/user.module';

/* NgRx */
import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';
import { metaReducers, reducers } from './store/reducers/index';
import { ProductEffect } from './store/effects/product.effects';
import { CarComponent } from './car/car.component';
import { CustomLogService } from './car/custom-log.service';
import { LogService } from './car/log.service';
import { CUSTOM_LOG, DATE_NOW, REST_API_URL } from './shared/token';
import { CustomLog } from './shared/CustomLog';

// return date
export function dateFactory() {
  return new Date();
}

export function nameFactory() {
  return 'Bilel Ben Khalifa';
}
let logger = new CustomLog();

const logService = new CustomLogService();

@NgModule({
  imports: [
    BrowserModule,
    HttpClientModule,
    HttpClientInMemoryWebApiModule.forRoot(ProductData),
    UserModule,
    AppRoutingModule,
    StoreModule.forRoot(reducers,{metaReducers}),
    EffectsModule.forRoot([ProductEffect])
  ],
  declarations: [
    AppComponent,
    ShellComponent,
    MenuComponent,
    WelcomeComponent,
    PageNotFoundComponent,
    CarComponent
  ],
  bootstrap: [AppComponent],
  providers:[
    LogService,
   // {provide: LogService, useValue: logService},
   // {provide: LogService, useValue: LogService},
    { provide: DATE_NOW, useFactory: dateFactory },
    { provide: 'BILEL_NAME', useFactory: nameFactory },
    { provide: REST_API_URL, useValue:'api/products' },
    { provide:'logger.config', useValue:{
      logLevel:'info',
      prefix: 'my-logger'
    }},
    { provide:CUSTOM_LOG, useValue:logger }
  ]
})
export class AppModule { }
