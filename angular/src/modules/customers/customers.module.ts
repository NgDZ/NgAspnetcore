import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CustomersRoutingModule } from './customers-routing.module';
import { BreezeCommonModule } from '@module/breeze-common';
import { CustomersComponent } from './customers/customers.component';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSortModule } from '@angular/material/sort';
import { MatToolbarModule } from '@angular/material/toolbar';

@NgModule({
  declarations: [CustomersComponent],
  imports: [
    CommonModule,
    CustomersRoutingModule,
    BreezeCommonModule,
    MatTableModule,
    MatPaginatorModule,
    MatToolbarModule,
    MatSortModule,
  ],
})
export class CustomersModule {}
