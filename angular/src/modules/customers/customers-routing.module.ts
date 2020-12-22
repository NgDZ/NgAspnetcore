import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CustomersAbpComponent } from './customers-abp/customers-abp.component';
import { CustomersComponent } from './customers/customers.component';

const routes: Routes = [
  { path: '', component: CustomersComponent },
  { path: 'abp', component: CustomersAbpComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class CustomersRoutingModule {}
