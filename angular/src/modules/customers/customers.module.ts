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
import { MatIconModule } from '@angular/material/icon';
import { MatDialogModule } from '@angular/material/dialog';
import { MatTabsModule } from '@angular/material/tabs';
import { TranslateModule } from '@ngx-translate/core';
import { MatFormFieldModule } from '@angular/material/form-field';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [CustomersComponent, CustomersAbpComponent],
  imports: [
    CommonModule,
    CustomersRoutingModule,
    MatMenuModule,
    MatButtonModule,
    MatIconModule,
    TranslateModule.forChild(),
    BreezeCommonModule,
    MatFormFieldModule,
    MatTabsModule,
  
    ReactiveFormsModule,
    FormsModule,
    MatTableModule,
    MatPaginatorModule,
    MatDialogModule,
    MatToolbarModule,
    MatProgressSpinnerModule,
    MatSortModule,
  ],
})
export class CustomersModule {}
