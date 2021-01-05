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
    ],
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
