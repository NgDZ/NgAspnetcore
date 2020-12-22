import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CustomersRoutingModule } from './customers-routing.module';
import { BreezeCommonModule } from '@module/breeze-common';
import { CustomersComponent } from './customers/customers.component';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSortModule } from '@angular/material/sort';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatMenuModule } from '@angular/material/menu';
import { MatButtonModule } from '@angular/material/button';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { CustomersAbpComponent } from './customers-abp/customers-abp.component';

@NgModule({
  declarations: [CustomersComponent, CustomersAbpComponent],
  imports: [
    CommonModule,
    CustomersRoutingModule,
    MatMenuModule,
    MatButtonModule,
    BreezeCommonModule,
    MatTableModule,
    MatPaginatorModule,
    MatToolbarModule,
    MatProgressSpinnerModule,
    MatSortModule,
  ],
})
export class CustomersModule {}
