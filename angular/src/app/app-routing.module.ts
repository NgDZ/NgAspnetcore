import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  {
    path: 'customers',
    loadChildren: () =>
      import('@module/customers').then((m) => m.CustomersModule),
  },
  {
    path: 'orders',
    loadChildren: () =>
      import('@module/orders').then((m) => m.OrdersModule),
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
