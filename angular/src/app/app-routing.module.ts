import { AuthGuard } from '@abpdz/ng.core';
import { MaterialApplicationLayoutComponent } from '@abpdz/ng.theme.material';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home.component';

const routes: Routes = [
  {
    path: 'auth',
    loadChildren: () =>
      import('@abpdz/ng.account').then((m) =>
        m.AccountModule.forLazy({ redirectUrl: '/' })
      ),
  },
  {
    path: '',
    // component: FuseApplicationLayoutComponent,
    component: MaterialApplicationLayoutComponent,
    children: [
      { path: '', component: HomeComponent },
      {
        path: 'account',
        loadChildren: () =>
          import('@abpdz/ng.account').then((m) =>
            m.AccountModule.forLazy({ redirectUrl: '/' })
          ),
      },
      {
        path: 'identity',
        loadChildren: () =>
          import('@abpdz/ng.identity').then((m) => m.IdentityModule.forLazy()),
      },

      {
        canActivate: [AuthGuard],
        path: 'customers',
        loadChildren: () =>
          import('@module/customers').then((m) => m.CustomersModule),
      },
      {
        canActivate: [AuthGuard],
        path: 'orders',
        loadChildren: () =>
          import('@module/orders').then((m) => m.OrdersModule),
      },
      {
        path: 'audit',
        loadChildren: () =>
          import('@abpdz/ng.audit').then((m) => m.AbpDzAuditModule.forLazy()),
      },
      {
        canActivate: [AuthGuard],
        path: 'demos',
        loadChildren: () =>
          import('@abpdz/ng.demos').then((m) => m.AbpDzDemosModule.forLazy()),
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
