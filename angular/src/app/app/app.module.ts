import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { StoreModule } from '@ngrx/store';
import { appReducers, appMetaReducers } from './reducers';
import { StoreDevtoolsModule } from '@ngrx/store-devtools';
import {
  StoreRouterConnectingModule,
  RouterState,
  routerReducer,
} from '@ngrx/router-store';

import { environment } from '../environments/environment';
import { CoreModule, registerLocale } from '@abpdz/ng.core';
import { ThemeBasicModule } from '@abpdz/ng.theme.basic';
import { ThemeSharedModule } from '@abpdz/ng.theme.shared';
import { ThemeMaterialModule } from '@abpdz/ng.theme.material';
import { HomeComponent } from './home.component';
import { IdentityConfigModule } from '@abpdz/ng.identity';
@NgModule({
  declarations: [AppComponent, HomeComponent],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    StoreModule.forRoot(
      { router: routerReducer },
      {
        metaReducers: appMetaReducers,
        runtimeChecks: {
          // strictStateImmutability and strictActionImmutability are enabled by default
          strictStateSerializability: true,
          strictActionSerializability: false,
          strictActionImmutability: true,
          strictStateImmutability: true,
          strictActionTypeUniqueness: true,
          strictActionWithinNgZone: true,
        },
      }
    ),
    !environment.production ? StoreDevtoolsModule.instrument() : [],
    /**
     * @ngrx/router-store keeps router state up-to-date in the store.
     */
    StoreRouterConnectingModule.forRoot({
      // routerState: RouterState.Full,
    }),

    CoreModule.forRoot({
      environment,
      registerLocaleFn: registerLocale(),
      sendNullsAsQueryParam: false,
      skipGetAppConfiguration: false,
    }),
    ThemeMaterialModule,
    ThemeSharedModule.forRoot(),
    ThemeBasicModule.forRoot(),

    IdentityConfigModule.forRoot(),
    // AccountConfigModule.forRoot(),
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
