import { BrowserModule } from '@angular/platform-browser';
import { APP_INITIALIZER, NgModule } from '@angular/core';

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
import {
  CoreModule,
  eLayoutType,
  registerLocale,
  RoutesService,
} from '@abpdz/ng.core';
import { ThemeBasicModule } from '@abpdz/ng.theme.basic';
import {
  eThemeSharedRouteNames,
  ThemeSharedModule,
} from '@abpdz/ng.theme.shared';
import { ThemeMaterialModule } from '@abpdz/ng.theme.material';
import { HomeComponent } from './home.component';
import { IdentityConfigModule } from '@abpdz/ng.identity/config';
import { AccountConfigModule } from '@abpdz/ng.account/config';
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
    AccountConfigModule.forRoot(),
  ],
  providers: [
    {
      provide: APP_INITIALIZER,
      useFactory: configureRoutes,
      deps: [RoutesService],
      multi: true,
    },
    ,
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
// <a mat-list-item routerLink="/customers" href="#">Customers</a>
// <a mat-list-item routerLink="/customers/abp" href="#">Customers abp</a>
// <a mat-list-item routerLink="/orders" href="#">Orders</a>

export function configureRoutes(routes: RoutesService) {
  return () => {
    routes.add([
      {
        path: '/orders',
        name: 'Orders',
        parentName: eThemeSharedRouteNames.Administration,

        iconClass: 'local_grocery_store',
        layout: eLayoutType.application,
        order: 10,
      },
      {
        path: '/customers',
        name: 'Customers',
        iconClass: 'local_grocery_store',
        parentName: eThemeSharedRouteNames.Administration,
        layout: eLayoutType.application,
        // requiredPolicy: eIdentityPolicyNames.Users,
        order: 20,
      },
      ,
      {
        path: '/customers/abp',
        name: 'Customers abp',
        iconClass: 'local_grocery_store',
        parentName: eThemeSharedRouteNames.Administration,
        layout: eLayoutType.application,
        // requiredPolicy: eIdentityPolicyNames.Users,
        order: 20,
      },
    ]);
  };
}
